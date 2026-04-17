using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace XDASCommunicationApp
{
    /// <summary>
    /// X-DAS 클라이언트 클래스
    /// </summary>
    public class XDASClient
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private bool isConnected = false;
        private List<string> monitoringTags = new List<string>();

        public event EventHandler<string> ConnectionStatusChanged;
        public event EventHandler<XDASTagValue> DataReceived;
        public event EventHandler<string> ErrorOccurred;

        public bool IsConnected => isConnected && tcpClient?.Connected == true;
        public bool HasMonitoringTags => monitoringTags.Count > 0;

        /// <summary>
        /// 연결
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<bool> ConnectAsync(string ip, int port, int timeoutMs = 5000)
        {
            try
            {
                tcpClient = new TcpClient();
                var connectTask =tcpClient.ConnectAsync(ip, port);
                if (await Task.WhenAny(connectTask, Task.Delay(timeoutMs)) != connectTask)
                    throw new TimeoutException("연결 타임아웃 발생");

                networkStream = tcpClient.GetStream();

                isConnected = true;

                Logger.Log($"[CONNECT] X-DAS 서버 연결됨: {ip}:{port}");
                ConnectionStatusChanged?.Invoke(this, "연결됨");

                return true;
            }
            catch (Exception ex)
            {
                isConnected = false;

                Logger.Log($"연결 실패: {ex.Message}");

                ConnectionStatusChanged?.Invoke(this, "연결실패");
                ErrorOccurred?.Invoke(this, $"연결 실패: {ex.Message}");

                return false;
            }
        }

        /// <summary>
        /// 연결해제
        /// </summary>
        public void Disconnect()
        {
            try
            {
                isConnected = false;
                monitoringTags.Clear();

                networkStream?.Close();
                tcpClient?.Close();

                Logger.Log("[DISCONNECT] X-DAS 서버 연결 해제됨");
                ConnectionStatusChanged?.Invoke(this, "연결해제됨");
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] Disconnect: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"연결 해제 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 태그 읽기
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public async Task<XDASTagValue> ReadTagAsync(string tagName)
        {
            if (!IsConnected)
                throw new InvalidOperationException("X-DAS 서버에 연결되지 않았습니다.");

            try
            {
                //실제 프로토콜이 명확해지면 파싱 로직 수정. 현재는 response에 원문 응답 그대로 저장
                string response = await SendCommandAsync($"READ {tagName}");

                return new XDASTagValue
                {
                    TagName = tagName,
                    Value = response,
                    Quality = "GOOD",
                    Timestamp = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] ReadTagAsync: {ex.Message}");

                return new XDASTagValue
                {
                    TagName = tagName,
                    Value = null,
                    Quality = "BAD",
                    Timestamp = DateTime.Now,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// 태그 쓰기
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteTagAsync(string tagName, object value)
        {
            if (!IsConnected)
                throw new InvalidOperationException("X-DAS 서버에 연결되지 않았습니다.");

            try
            {
                string response = await SendCommandAsync($"WRITE {tagName} {value}");

                return response.IndexOf("OK", StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] WriteTagAsync: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"태그 '{tagName}' 쓰기 오류: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 명령어를 전송합니다
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> SendCommandAsync(string command)
        {
            if (!IsConnected || networkStream == null)
                throw new InvalidOperationException("X-DAS 서버에 연결되지 않았습니다.");

            try
            {
                byte[] request = Encoding.ASCII.GetBytes(command + "\n");
                await networkStream.WriteAsync(request, 0, request.Length);
                Logger.Log($"[SEND] {command}");

                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                Logger.Log($"[RECV] {response}");

                return response;
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] SendCommandAsync: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 모니터링 태그 설정
        /// </summary>
        /// <param name="tagNames"></param>
        public void SetMonitoringTags(string[] tagNames)
        {
            monitoringTags.Clear();
            monitoringTags.AddRange(tagNames);
            Logger.Log($"[MONITOR] {monitoringTags.Count}개 태그 등록됨");
        }

        /// <summary>
        /// 모니터링 중지
        /// </summary>
        public void StopMonitoring()
        {
            monitoringTags.Clear();
            Logger.Log("[MONITOR] 태그 모니터링 중지됨");
        }

        /// <summary>
        /// 모니터링 데이터 갱신
        /// </summary>
        /// <returns></returns>
        public async Task RefreshMonitoringData()
        {
            if (!IsConnected || monitoringTags.Count == 0)
                return;

            try
            {
                var tasks = monitoringTags.Select(async tagName =>
                {
                    var tagValue = await ReadTagAsync(tagName);
                    DataReceived?.Invoke(this, tagValue);
                });
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] RefreshMonitoringData: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"모니터링 데이터 갱신 오류: {ex.Message}");
            }
        }
        
        
    }
}
