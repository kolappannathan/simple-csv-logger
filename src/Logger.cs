using System;
using System.IO;
using System.Text;

namespace Core.Library
{
    public class Logger
    {
        private readonly string datetimeFormat;
        private readonly string logFilename;
        private readonly Encoding encoding;

        /// <summary>
        /// Initiate an instance of Logger class.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public Logger()
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            logFilename = "Log.csv";
            encoding = Encoding.UTF8;

            if (!File.Exists(logFilename))
            {
                WriteLine("Time,Error Level,Error Message", false);
            }
        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.FATAL, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.TRACE, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(LogLevel.WARNING, text);
        }

        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext = DateTime.Now.ToString(datetimeFormat);
            switch (level)
            {
                case LogLevel.TRACE:
                    pretext += ",TRACE,";
                    break;
                case LogLevel.INFO:
                    pretext += ",INFO,";
                    break;
                case LogLevel.DEBUG:
                    pretext += ",DEBUG,";
                    break;
                case LogLevel.WARNING:
                    pretext += ",WARNING,";
                    break;
                case LogLevel.ERROR:
                    pretext += ",ERROR,";
                    break;
                case LogLevel.FATAL:
                    pretext += ",FATAL,";
                    break;
                default:
                    pretext += ",,";
                    break;
            }
            WriteLine(pretext + text);
        }

        private void WriteLine(string text, bool append = true)
        {
            using (var writer = new StreamWriter(logFilename, append, encoding))
            {
                if (text != "")
                {
                    writer.WriteLine(text);
                }
            }
        }

        private enum LogLevel
        {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            FATAL
        }
    }
}
