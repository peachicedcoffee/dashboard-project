using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XDASCommunicationApp
{
    public partial class MainForm : Form
    {
        private XDASClient xdasClient;
        private System.Windows.Forms.Timer refreshTimer;

        /// <summary>
        /// IP 주소 
        /// </summary>
        public string IpAddress { get { return txtIP.Text; } private set { txtIP.Text = value; } }

        /// <summary>
        /// 포트
        /// </summary>
        public string PortNumber { get { return txtPort.Text; } private set { txtPort.Text = value; } }

        /// <summary>
        /// 연결상태
        /// </summary>
        public string Status { get { return lblStatus.Text; } private set { lblStatus.Text = value; } }

        /// <summary>
        /// 읽기 태그
        /// </summary>
        public string ReadTag { get { return txtReadTag.Text; } private set { txtReadTag.Text = value; } }

        /// <summary>
        /// 읽기 결과
        /// </summary>
        public string ReadResult { get { return txtReadResult.Text; } private set { txtReadResult.Text = value; } }

        /// <summary>
        /// 쓰기 태그
        /// </summary>
        public string WriteTag { get { return txtWriteTag.Text; } private set { txtWriteTag.Text = value; } }

        /// <summary>
        /// 쓰기 태그 값
        /// </summary>
        public string WriteValue { get { return txtWriteValue.Text; } private set { txtWriteValue.Text = value; } }

        /// <summary>
        /// 쓰기 태그 결과
        /// </summary>
        public string WriteResult { get { return txtWriteResult.Text; } private set { txtWriteResult.Text = value; } }

        /// <summary>
        /// 모니터링 태그 
        /// </summary>
        public string MonitoringTags { get { return txtMonitorTags.Text; } private set { txtMonitorTags.Text = value; } }




        public MainForm()
        {
            InitializeComponent();

            AddEventhandlers();

            InitializeXDASClient();

            SetupRefreshTimer();
        }


        /// <summary>
        ///  이벤트 핸들러를 추가합니다.
        /// </summary>
        private void AddEventhandlers()
        {
            FormClosing += MainForm_FormClosing;
            btnConnect.Click += BtnConnect_Click;
            btnDisconnect.Click += BtnDisconnect_Click;
            btnRead.Click += BtnRead_Click;
            btnWrite.Click += BtnWrite_Click;
            btnStartMonitor.Click += BtnStartMonitor_Click;
            btnStopMonitor.Click += BtnStopMonitor_Click;            
        }


        /// <summary>
        /// XDAS 클라이언트를 생성하고 XDAS 내부 이벤트를 구현합니다
        /// </summary>
        private void InitializeXDASClient()
        {
            xdasClient = new XDASClient();
            xdasClient.ConnectionStatusChanged += XdasClient_ConnectionStatusChanged;
            xdasClient.DataReceived += XdasClient_DataReceived;
            xdasClient.ErrorOccurred += XdasClient_ErrorOccurred;
        }

        /// <summary>
        /// 타이머 초기설정 및 내부 이벤트를 구현합니다
        /// </summary>
        private void SetupRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 1000; // 1초마다
            refreshTimer.Tick += RefreshTimer_Tick;
        }
        

        #region 폼 내부 이벤트핸들러 

        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            Logger.Log("[ACTION] 연결 버튼 클릭"); 

            var btnConnect = sender as Button;
            var btnDisconnect = this.Controls.Find("btnDisconnect", true).FirstOrDefault() as Button;

            if (btnConnect == null || btnDisconnect == null) return;

            try
            {
                btnConnect.Enabled = false;
                string ip = IpAddress.Trim();
                int port = int.Parse(PortNumber.Trim());

                bool connected = await xdasClient.ConnectAsync(ip, port);

                if (connected)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    MessageBox.Show("X-DAS 서버에 연결되었습니다.", "연결 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnConnect.Enabled = true;
                    MessageBox.Show("X-DAS 서버 연결에 실패했습니다.", "연결 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btnConnect.Enabled = true;
                Logger.Log($"[ERROR] 연결 시도 중 오류: {ex.Message}"); 
                MessageBox.Show($"연결 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            Logger.Log("[ACTION] 연결 해제 버튼 클릭"); 

            var btnConnect = this.Controls.Find("btnConnect", true).FirstOrDefault() as Button;
            var btnDisconnect = sender as Button;
            var btnStopMonitor = this.Controls.Find("btnStopMonitor", true).FirstOrDefault() as Button;

            if (btnConnect == null 
                || btnDisconnect == null
                || btnStopMonitor == null) return;

            xdasClient.Disconnect();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;

            if (refreshTimer.Enabled)
            {
                btnStopMonitor.PerformClick();
            }
        }

        private async void BtnRead_Click(object sender, EventArgs e)
        {
            Logger.Log($"[ACTION] 태그 읽기 요청: {ReadTag}");

            var txtReadResult = this.Controls.Find("txtReadResult", true).FirstOrDefault() as TextBox;
            var btnRead = sender as Button;

            if (!xdasClient.IsConnected)
            {
                MessageBox.Show("X-DAS 서버에 연결되지 않았습니다.", "연결 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnRead.Enabled = false;
                string tagName = ReadTag.Trim();

                if (string.IsNullOrEmpty(tagName))
                {
                    MessageBox.Show("태그명을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = await xdasClient.ReadTagAsync(tagName);

                ReadResult = $"태그: {result.TagName}\r\n" +
                                   $"값: {result.Value}\r\n" +
                                   $"품질: {result.Quality}\r\n" +
                                   $"시간: {result.Timestamp:yyyy-MM-dd HH:mm:ss}\r\n" +
                                   $"읽기 시간: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                ReadResult = $"읽기 오류: {ex.Message}\r\n시간: {DateTime.Now:HH:mm:ss}";
            }
            finally
            {
                btnRead.Enabled = true;
            }
        }

        private async void BtnWrite_Click(object sender, EventArgs e)
        {
            Logger.Log($"[ACTION] 태그 쓰기 요청: {WriteTag}={WriteValue}");

            var btnWrite = sender as Button;
            if (btnWrite == null) return;

            if (!xdasClient.IsConnected)
            {
                MessageBox.Show("X-DAS 서버에 연결되지 않았습니다.", "연결 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnWrite.Enabled = false;
                string tagName = WriteTag.Trim();
                string value = WriteValue.Trim();

                if (string.IsNullOrEmpty(tagName) || string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("태그명과 값을 모두 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = await xdasClient.WriteTagAsync(tagName, value);

                if (success)
                {
                    WriteResult = $"태그: {tagName}\r\n" +
                                        $"쓰기 값: {value}\r\n" +
                                        $"결과: 성공\r\n" +
                                        $"시간: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                }
                else
                {
                    WriteResult = $"태그: {tagName}\r\n" +
                                        $"쓰기 값: {value}\r\n" +
                                        $"결과: 실패\r\n" +
                                        $"시간: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                }
            }
            catch (Exception ex)
            {
                txtWriteResult.Text = $"쓰기 오류: {ex.Message}\r\n시간: {DateTime.Now:HH:mm:ss}";
            }
            finally
            {
                btnWrite.Enabled = true;
            }
        }

        private async void BtnStartMonitor_Click(object sender, EventArgs e)
        {
            Logger.Log("[ACTION] 모니터링 시작 버튼 클릭");

            var btnStartMonitor = sender as Button;
            var btnStopMonitor = this.Controls.Find("btnStopMonitor", true).FirstOrDefault() as Button;

            if (btnStartMonitor == null || btnStopMonitor == null)
                return;

            if (!xdasClient.IsConnected)
            {
                MessageBox.Show("X-DAS 서버에 연결되지 않았습니다.", "연결 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string[] tagNames = MonitoringTags.Split(',')
                    .Select(t => t.Trim())
                    .Where(t => !string.IsNullOrEmpty(t))
                    .ToArray();

                if (tagNames.Length == 0)
                {
                    MessageBox.Show("모니터링할 태그를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                xdasClient.SetMonitoringTags(tagNames);
                refreshTimer.Start();

                btnStartMonitor.Enabled = false;
                btnStopMonitor.Enabled = true;

                MessageBox.Show($"{tagNames.Length}개 태그 모니터링을 시작합니다.", "모니터링 시작", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"모니터링 시작 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnStopMonitor_Click(object sender, EventArgs e)
        {
            Logger.Log("[ACTION] 모니터링 중지 버튼 클릭"); 

            var btnStartMonitor = this.Controls.Find("btnStartMonitor", true).FirstOrDefault() as Button;
            var btnStopMonitor = sender as Button;
            
            refreshTimer.Stop();
            xdasClient.StopMonitoring();

            btnStartMonitor.Enabled = true;
            btnStopMonitor.Enabled = false;

            MessageBox.Show("모니터링을 중지했습니다.", "모니터링 중지", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 타이머 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (xdasClient.IsConnected && xdasClient.HasMonitoringTags)
            {
                await xdasClient.RefreshMonitoringData();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Log("[ACTION] 프로그램 종료");
            refreshTimer?.Stop();
            xdasClient?.Disconnect();
        }


        #endregion


        #region X-DAS 클라이언트 이벤트 핸들러, 메서드

        /// <summary>
        /// 커넥션 상태 변경됐을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void XdasClient_ConnectionStatusChanged(object sender, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, string>(XdasClient_ConnectionStatusChanged), sender, status);
                return;
            }
            
            string currentStatus = $"연결상태: {status}";
            Status = currentStatus;
            UpdateStautsColor(currentStatus);
        }

        /// <summary>
        /// 연결 상태에 따라 라벨 색상을 변경합니다
        /// </summary>
        /// <param name="status"></param>
        private void UpdateStautsColor(string status)
        {
            lblStatus.ForeColor = status.Contains("연결됨") ? Color.Green : Color.Red;
        }

        /// <summary>
        /// 데이터를 받았을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tagValue"></param>
        private void XdasClient_DataReceived(object sender, XDASTagValue tagValue)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, XDASTagValue>(XdasClient_DataReceived), sender, tagValue);
                return;
            }

            var lstMonitorData = this.Controls.Find("lstMonitorData", true).FirstOrDefault() as ListView;

            // 기존 항목 찾기
            var existingItem = lstMonitorData.Items.Cast<ListViewItem>()
                .FirstOrDefault(item => item.Text == tagValue.TagName);

            if (existingItem != null)
            {
                // 기존 항목 업데이트
                existingItem.SubItems[1].Text = tagValue.Value?.ToString() ?? "null";
                existingItem.SubItems[2].Text = tagValue.Quality ?? "Unknown";
                existingItem.SubItems[3].Text = tagValue.Timestamp.ToString("HH:mm:ss");
                existingItem.SubItems[4].Text = string.IsNullOrEmpty(tagValue.ErrorMessage) ? "정상" : "오류";
                existingItem.BackColor = string.IsNullOrEmpty(tagValue.ErrorMessage) ? Color.White : Color.LightPink;
            }
            else
            {
                // 새 항목 추가
                var item = new ListViewItem(tagValue.TagName);
                item.SubItems.Add(tagValue.Value?.ToString() ?? "null");
                item.SubItems.Add(tagValue.Quality ?? "Unknown");
                item.SubItems.Add(tagValue.Timestamp.ToString("HH:mm:ss"));
                item.SubItems.Add(string.IsNullOrEmpty(tagValue.ErrorMessage) ? "정상" : "오류");
                item.BackColor = string.IsNullOrEmpty(tagValue.ErrorMessage) ? Color.White : Color.LightPink;

                lstMonitorData.Items.Add(item);
            }
        }

        /// <summary>
        /// 에러 발생했을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="error"></param>
        private void XdasClient_ErrorOccurred(object sender, string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, string>(XdasClient_ErrorOccurred), sender, error);
                return;
            }

            MessageBox.Show(error, "X-DAS 통신 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

    }


    
}
