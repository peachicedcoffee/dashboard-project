using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplication1.Models;
using System.Xml;

namespace WindowsFormsApplication1.Helper
{
    /// <summary>
    /// 프로그램 시작/종료 로그 기록을 남깁니다
    /// </summary>
    public class LogHelper
    {
        private static readonly string logDirectoryPath = Path.Combine(Application.StartupPath, "Logs");
        private static string logFilePath;

        public LogHelper()
        {
            EnsureLogFilePath();
        }

        private static LogHelper logHelper;
        public static LogHelper Default
        {
            get
            {
                if (logHelper == null)
                    logHelper = new LogHelper();
                return logHelper;
            }
        }

        private void EnsureLogFilePath()
        {
            if (!Directory.Exists(logDirectoryPath))
                Directory.CreateDirectory(logDirectoryPath);

            string today = DateTime.Today.ToString("yyyyMMdd");
            logFilePath = Path.Combine(logDirectoryPath, string.Format("Log_{0}.xml", today));

            //없으면 새로운 파일 생성
            if (!File.Exists(logFilePath))
            {
                using (XmlTextWriter writer = new XmlTextWriter(logFilePath, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Log");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public void LogProgramStart()
        {
            WriteLogEntry(new StateLog()
            {  
                Status = "Start",
                Message = "Program started",
                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        public void LogProgramEnd()
        {
            WriteLogEntry(new StateLog()
            {
                Status = "End",
                Message = "Program ended normally",
                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        public void WriteLogEntry(StateLog slog)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(logFilePath);

            XmlNode root = doc.DocumentElement;

            XmlElement logEntry = doc.CreateElement("Log");
            logEntry.SetAttribute("Status", slog.Status);
            logEntry.SetAttribute("DateTime", slog.DateTime);

            XmlElement msg = doc.CreateElement("Message");
            msg.InnerText = slog.Message;

            logEntry.AppendChild(msg);

            root.AppendChild(logEntry);

            doc.Save(logFilePath);
        }
         
    }
}
