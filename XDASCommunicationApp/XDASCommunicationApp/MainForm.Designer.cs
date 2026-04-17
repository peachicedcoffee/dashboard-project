namespace XDASCommunicationApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpRead = new System.Windows.Forms.GroupBox();
            this.lblReadTag = new System.Windows.Forms.Label();
            this.txtReadTag = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblReadResult = new System.Windows.Forms.Label();
            this.txtReadResult = new System.Windows.Forms.TextBox();
            this.grpWrite = new System.Windows.Forms.GroupBox();
            this.lblWriteTag = new System.Windows.Forms.Label();
            this.txtWriteTag = new System.Windows.Forms.TextBox();
            this.lblWriteValue = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lblWriteResult = new System.Windows.Forms.Label();
            this.txtWriteResult = new System.Windows.Forms.TextBox();
            this.grpMonitor = new System.Windows.Forms.GroupBox();
            this.lblMonitorTags = new System.Windows.Forms.Label();
            this.txtMonitorTags = new System.Windows.Forms.TextBox();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.btnStopMonitor = new System.Windows.Forms.Button();
            this.lstMonitorData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpConnection.SuspendLayout();
            this.grpRead.SuspendLayout();
            this.grpWrite.SuspendLayout();
            this.grpMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.lblStatus);
            this.grpConnection.Controls.Add(this.btnDisconnect);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Controls.Add(this.txtIP);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.lblIP);
            this.grpConnection.Location = new System.Drawing.Point(10, 10);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(760, 80);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "연결 설정";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.LightCoral;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(435, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(80, 30);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "연결해제";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.LightGreen;
            this.btnConnect.Location = new System.Drawing.Point(345, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 30);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(265, 23);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "2004";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(80, 23);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(120, 21);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.1.100";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(220, 25);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(40, 20);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "포트:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(15, 25);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(60, 20);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP 주소:";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(535, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "연결상태: 연결안됨";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRead
            // 
            this.grpRead.Controls.Add(this.txtReadResult);
            this.grpRead.Controls.Add(this.lblReadResult);
            this.grpRead.Controls.Add(this.btnRead);
            this.grpRead.Controls.Add(this.txtReadTag);
            this.grpRead.Controls.Add(this.lblReadTag);
            this.grpRead.Location = new System.Drawing.Point(10, 100);
            this.grpRead.Name = "grpRead";
            this.grpRead.Size = new System.Drawing.Size(370, 200);
            this.grpRead.TabIndex = 1;
            this.grpRead.TabStop = false;
            this.grpRead.Text = "태그 읽기";
            // 
            // lblReadTag
            // 
            this.lblReadTag.Location = new System.Drawing.Point(15, 25);
            this.lblReadTag.Name = "lblReadTag";
            this.lblReadTag.Size = new System.Drawing.Size(50, 20);
            this.lblReadTag.TabIndex = 1;
            this.lblReadTag.Text = "태그명:";
            this.lblReadTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadTag
            // 
            this.txtReadTag.Location = new System.Drawing.Point(70, 23);
            this.txtReadTag.Name = "txtReadTag";
            this.txtReadTag.Size = new System.Drawing.Size(150, 21);
            this.txtReadTag.TabIndex = 4;
            this.txtReadTag.Text = "TANK01.LEVEL";
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.LightBlue;
            this.btnRead.Location = new System.Drawing.Point(230, 20);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(60, 30);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "읽기";
            this.btnRead.UseVisualStyleBackColor = false;
            // 
            // lblReadResult
            // 
            this.lblReadResult.Location = new System.Drawing.Point(15, 60);
            this.lblReadResult.Name = "lblReadResult";
            this.lblReadResult.Size = new System.Drawing.Size(70, 20);
            this.lblReadResult.TabIndex = 7;
            this.lblReadResult.Text = "읽기 결과:";
            this.lblReadResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadResult
            // 
            this.txtReadResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReadResult.Location = new System.Drawing.Point(15, 85);
            this.txtReadResult.Multiline = true;
            this.txtReadResult.Name = "txtReadResult";
            this.txtReadResult.ReadOnly = true;
            this.txtReadResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReadResult.Size = new System.Drawing.Size(340, 100);
            this.txtReadResult.TabIndex = 8;
            // 
            // grpWrite
            // 
            this.grpWrite.Controls.Add(this.txtWriteResult);
            this.grpWrite.Controls.Add(this.lblWriteResult);
            this.grpWrite.Controls.Add(this.btnWrite);
            this.grpWrite.Controls.Add(this.txtWriteValue);
            this.grpWrite.Controls.Add(this.lblWriteValue);
            this.grpWrite.Controls.Add(this.txtWriteTag);
            this.grpWrite.Controls.Add(this.lblWriteTag);
            this.grpWrite.Location = new System.Drawing.Point(400, 100);
            this.grpWrite.Name = "grpWrite";
            this.grpWrite.Size = new System.Drawing.Size(370, 200);
            this.grpWrite.TabIndex = 2;
            this.grpWrite.TabStop = false;
            this.grpWrite.Text = "태그 쓰기";
            // 
            // lblWriteTag
            // 
            this.lblWriteTag.Location = new System.Drawing.Point(15, 25);
            this.lblWriteTag.Name = "lblWriteTag";
            this.lblWriteTag.Size = new System.Drawing.Size(50, 20);
            this.lblWriteTag.TabIndex = 2;
            this.lblWriteTag.Text = "태그명:";
            this.lblWriteTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWriteTag
            // 
            this.txtWriteTag.Location = new System.Drawing.Point(70, 23);
            this.txtWriteTag.Name = "txtWriteTag";
            this.txtWriteTag.Size = new System.Drawing.Size(150, 21);
            this.txtWriteTag.TabIndex = 5;
            this.txtWriteTag.Text = "SETPOINT01";
            // 
            // lblWriteValue
            // 
            this.lblWriteValue.Location = new System.Drawing.Point(15, 55);
            this.lblWriteValue.Name = "lblWriteValue";
            this.lblWriteValue.Size = new System.Drawing.Size(30, 20);
            this.lblWriteValue.TabIndex = 6;
            this.lblWriteValue.Text = "값:";
            this.lblWriteValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(70, 53);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(150, 21);
            this.txtWriteValue.TabIndex = 7;
            this.txtWriteValue.Text = "100.5";
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.LightYellow;
            this.btnWrite.Location = new System.Drawing.Point(230, 35);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(60, 30);
            this.btnWrite.TabIndex = 8;
            this.btnWrite.Text = "쓰기";
            this.btnWrite.UseVisualStyleBackColor = false;
            // 
            // lblWriteResult
            // 
            this.lblWriteResult.Location = new System.Drawing.Point(15, 85);
            this.lblWriteResult.Name = "lblWriteResult";
            this.lblWriteResult.Size = new System.Drawing.Size(70, 20);
            this.lblWriteResult.TabIndex = 9;
            this.lblWriteResult.Text = "쓰기 결과:";
            this.lblWriteResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWriteResult
            // 
            this.txtWriteResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWriteResult.Location = new System.Drawing.Point(15, 110);
            this.txtWriteResult.Multiline = true;
            this.txtWriteResult.Name = "txtWriteResult";
            this.txtWriteResult.ReadOnly = true;
            this.txtWriteResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWriteResult.Size = new System.Drawing.Size(340, 75);
            this.txtWriteResult.TabIndex = 10;
            // 
            // grpMonitor
            // 
            this.grpMonitor.Controls.Add(this.lstMonitorData);
            this.grpMonitor.Controls.Add(this.btnStopMonitor);
            this.grpMonitor.Controls.Add(this.btnStartMonitor);
            this.grpMonitor.Controls.Add(this.txtMonitorTags);
            this.grpMonitor.Controls.Add(this.lblMonitorTags);
            this.grpMonitor.Location = new System.Drawing.Point(10, 320);
            this.grpMonitor.Name = "grpMonitor";
            this.grpMonitor.Size = new System.Drawing.Size(760, 220);
            this.grpMonitor.TabIndex = 3;
            this.grpMonitor.TabStop = false;
            this.grpMonitor.Text = "실시간 모니터링";
            // 
            // lblMonitorTags
            // 
            this.lblMonitorTags.Location = new System.Drawing.Point(15, 25);
            this.lblMonitorTags.Name = "lblMonitorTags";
            this.lblMonitorTags.Size = new System.Drawing.Size(180, 20);
            this.lblMonitorTags.TabIndex = 10;
            this.lblMonitorTags.Text = "모니터링 태그 (쉼표로 구분):";
            this.lblMonitorTags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonitorTags
            // 
            this.txtMonitorTags.Location = new System.Drawing.Point(200, 23);
            this.txtMonitorTags.Name = "txtMonitorTags";
            this.txtMonitorTags.Size = new System.Drawing.Size(350, 21);
            this.txtMonitorTags.TabIndex = 11;
            this.txtMonitorTags.Text = "TANK01.LEVEL,TANK01.TEMP,PUMP01.STATUS";
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartMonitor.Location = new System.Drawing.Point(560, 20);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(90, 30);
            this.btnStartMonitor.TabIndex = 12;
            this.btnStartMonitor.Text = "모니터링 시작";
            this.btnStartMonitor.UseVisualStyleBackColor = false;
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.BackColor = System.Drawing.Color.LightCoral;
            this.btnStopMonitor.Enabled = false;
            this.btnStopMonitor.Location = new System.Drawing.Point(660, 20);
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.Size = new System.Drawing.Size(90, 30);
            this.btnStopMonitor.TabIndex = 13;
            this.btnStopMonitor.Text = "모니터링 중지";
            this.btnStopMonitor.UseVisualStyleBackColor = false;
            // 
            // lstMonitorData
            // 
            this.lstMonitorData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstMonitorData.FullRowSelect = true;
            this.lstMonitorData.GridLines = true;
            this.lstMonitorData.Location = new System.Drawing.Point(15, 60);
            this.lstMonitorData.Name = "lstMonitorData";
            this.lstMonitorData.Size = new System.Drawing.Size(730, 145);
            this.lstMonitorData.TabIndex = 14;
            this.lstMonitorData.UseCompatibleStateImageBehavior = false;
            this.lstMonitorData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "태그명";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "값";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "품질";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "시간";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "상태";
            this.columnHeader5.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grpMonitor);
            this.Controls.Add(this.grpWrite);
            this.Controls.Add(this.grpRead);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "자이솜 X-DAS 통신 프로그램";
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpRead.ResumeLayout(false);
            this.grpRead.PerformLayout();
            this.grpWrite.ResumeLayout(false);
            this.grpWrite.PerformLayout();
            this.grpMonitor.ResumeLayout(false);
            this.grpMonitor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpRead;
        private System.Windows.Forms.TextBox txtReadTag;
        private System.Windows.Forms.Label lblReadTag;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblReadResult;
        private System.Windows.Forms.TextBox txtReadResult;
        private System.Windows.Forms.GroupBox grpWrite;
        private System.Windows.Forms.TextBox txtWriteTag;
        private System.Windows.Forms.Label lblWriteTag;
        private System.Windows.Forms.Label lblWriteValue;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label lblWriteResult;
        private System.Windows.Forms.TextBox txtWriteResult;
        private System.Windows.Forms.GroupBox grpMonitor;
        private System.Windows.Forms.Label lblMonitorTags;
        private System.Windows.Forms.TextBox txtMonitorTags;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.Button btnStopMonitor;
        private System.Windows.Forms.ListView lstMonitorData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

