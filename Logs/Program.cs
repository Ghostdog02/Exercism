using System;

namespace Logs
{
    static class LogLine
    {
        public static void Main()
        {

        }

        enum LogLevel
        {
            Unknown = 0,
            Trace = 1,
            Debug = 2,
            Info = 4,
            Warning = 5,
            Error = 6,
            Fatal = 42


        }

        static LogLevel ParseLogLevel(string logLine)
        {
            int firstBracketIndex = logLine.IndexOf("[") + 1;
            int secondBracketIndex = logLine.IndexOf("]");
            int logLenght = secondBracketIndex - firstBracketIndex;
            string loglevel = logLine.Substring(firstBracketIndex, logLenght);
            switch (loglevel)
            {
                case "TRC":
                    return LogLevel.Trace;
                case "DBG":
                    return LogLevel.Debug;
                case "INF":
                    return LogLevel.Info;
                case "WRN":
                    return LogLevel.Warning;
                case "ERR":
                    return LogLevel.Error;
                case "FTL":
                    return LogLevel.Fatal;
                default:
                    return LogLevel.Unknown;
            }
        }

        static string OutputForShortLog(LogLevel logLevel, string message)
        {
            return $"{(int)logLevel}:{message}";
        }
    }
}
