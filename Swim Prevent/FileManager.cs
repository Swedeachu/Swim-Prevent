using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim_Prevent {
    class FileManager {

        private static string logFilePath;
        private static string logDir;

        public static void createLogs() {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            logDir = appdataPath + "\\swim_prevent_logs";
            DateTime now = DateTime.UtcNow;
            long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
            logFilePath = logDir + "\\" + unixTimeMilliseconds + ".log";
            if (!Directory.Exists(logDir)) {
                Directory.CreateDirectory(logDir);
            }
            if (!File.Exists(logFilePath)) {
                File.Create(logFilePath).Dispose();
            }
        }

        public static void appendLogs(string msg) {
            if (!Directory.Exists(logDir)) {
                createLogs();
                return;
            }
            if (!File.Exists(logFilePath)) {
                createLogs();
                return;
            }
            try {
                using StreamWriter sw = File.AppendText(logFilePath);
                sw.WriteLine(msg);
                sw.Close();
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
