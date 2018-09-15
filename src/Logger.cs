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
            logFilename = AppDomain.CurrentDomain.BaseDirectory + "Log.csv";
            encoding = Encoding.UTF8;

            if (!File.Exists(logFilename))
            {
                WriteLine("Time,Error Level,Error Message", false);
            }
        }

        #region Public Logger functions

        #region Exception Logs

        public void Debug(Exception ex)
        {
            WriteLog(LogLevel.DEBUG, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        public void Error(Exception ex)
        {
            WriteLog(LogLevel.ERROR, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        public void Fatal(Exception ex)
        {
            WriteLog(LogLevel.FATAL, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        public void Info(Exception ex)
        {
            WriteLog(LogLevel.INFO, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        public void Trace(Exception ex)
        {
            WriteLog(LogLevel.TRACE, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        public void Warning(Exception ex)
        {
            WriteLog(LogLevel.WARNING, $"Message: {ex.Message.Replace(',', ";")}; StackTrace: {ex.StackTrace.Replace(',', ";")}; InnerException:{ex.InnerException.Replace(',', ";")}");
        }

        #endregion Exception Logs

        #region Error message logs

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteLog(LogLevel.DEBUG, text.Replace(',', ';'));
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteLog(LogLevel.ERROR, text.Replace(',', ';'));
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteLog(LogLevel.FATAL, text.Replace(',', ';'));
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteLog(LogLevel.INFO, text.Replace(',', ';'));
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteLog(LogLevel.TRACE, text.Replace(',', ';'));
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteLog(LogLevel.WARNING, text.Replace(',', ';'));
        }

        #endregion Error message logs

        #endregion Public Logger functions

        #region Write functions

        private void WriteLog(string logLevel, string text)
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
            if (text != null || text != "")
            {
                using (var writer = new StreamWriter(logFilename, append, encoding))
                {
                    writer.WriteLine(text);
                }
            }
        }

        #endregion Write Functions
    }
}
