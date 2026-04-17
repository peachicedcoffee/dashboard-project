using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
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

        public async Task<bool> ConnectAsync(string ip, int port)
        {
            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(ip, port);
                networkStream = tcpClient.GetStream();

                isConnected = true;
                ConnectionStatusChanged?.Invoke(this, "연결됨");
                return true;
            }
            catch (Exception ex)
            {
                isConnected = false;
                ConnectionStatusChanged?.Invoke(this, "연결실패");
                ErrorOccurred?.Invoke(this, $"연결 실패: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                isConnected = false;
                monitoringTags.Clear();

                networkStream?.Close();
                tcpClient?.Close();

                ConnectionStatusChanged?.Invoke(this, "연결해제됨");
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"연결 해제 오류: {ex.Message}");
            }
        }
    }
