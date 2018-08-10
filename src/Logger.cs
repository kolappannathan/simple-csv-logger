using System;
using System.IO;
using System.Text;

namespace Core.Library
{
    public class Logger
    {
        #region Declarations

        private static class LogLevel
        {
            public static readonly string TRACE = "TRACE";
            public static readonly string INFO = "INFO";
            public static readonly string DEBUG = "DEBUG";
            public static readonly string WARNING = "WARNING";
            public static readonly string ERROR = "ERROR";
            public static readonly string FATAL = "FATAL";
        }

        private readonly string datetimeFormat;
        private readonly string logFilename;
        private readonly Encoding encoding;

        #endregion Declarations

        /// <summary>
        /// Initiate an instance of Logger class.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public Logger()
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            logFilename = System.AppDomain.CurrentDomain.BaseDirectory + "Log.csv";
            encoding = Encoding.UTF8;

            if (!File.Exists(logFilename))
            {
                WriteLine("Time,Error Level,Error Message", false);
            }
        }

        #region Public Logger functions

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

        #endregion Public Logger functions

        #region Write functions

        private void WriteFormattedLog(string logLevel, string text)
        {
            string pretext = $"{DateTime.Now.ToString(datetimeFormat)},{logLevel},";
            WriteLine(pretext + text);
        }

        /// <summary>
        /// Writes the input text into log file
        /// </summary>
        /// <param name="text">Input text</param>
        /// <param name="append">Whether to append the old text or replace it</param>
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

        #endregion Write Functions
    }
}
