using System;
using System.Text;

namespace LogLevels
{
    public class LogLine
    {
        public static string Message(string logLine)
        {
            int indexMessage = logLine.IndexOf(':') + 1;
            logLine = logLine.Substring(indexMessage).Trim();
            return logLine;

        }

        public static string LogLevel(string logLine)
        {
            int indexLevel = logLine.IndexOf(']') - 1;
            logLine = logLine.Substring(1, indexLevel).ToLower();
            return logLine;
        }

        public static string Reformat(string logLine)
        {
            string result = $"{Message(logLine)} ({LogLevel(logLine)})";
            return result;

        }

        public static void Main()
        {
            Message("[WARNING]:  Disk almost full\r\n");
            LogLevel("[WARNING]:  Disk almost full\r\n");
            Reformat("[INFO]: Operation completed");
        }
    }
}
