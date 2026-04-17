using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDASCommunicationApp
{
    /// <summary>
    /// 로그를 남길 때 사용합니다
    /// </summary>
    public static class Logger
    {
        private static readonly object _lock = new object();

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {message}";
            lock (_lock)
            {
                File.AppendAllText(GetLogPath(), logEntry + Environment.NewLine);
            }
        }

        private static string GetLogPath()
        {
            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(dirPath);

            return Path.Combine(dirPath, "app.log");
        }

    }
}
