using System;
using System.IO;
using System.Text;

namespace nk.logger.csv
{
    public class Logger
    {
        #region Declarations

        private static class LogLevel
        {
            public const string TRACE = "TRACE";
            public const string INFO = "INFO";
            public const string DEBUG = "DEBUG";
            public const string WARNING = "WARNING";
            public const string ERROR = "ERROR";
            public const string FATAL = "FATAL";
        }

        private readonly Encoding encoding = Encoding.UTF8;
        private readonly string datetimeFormat;
        private readonly string logFilename;
        private readonly char replacementVal;

        #endregion Declarations

        /// <summary>
        /// Initiate an instance of Logger class.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public Logger()
        {
            var loggerConfig = new LoggerConfig();
            datetimeFormat = loggerConfig.GetDateTimeFormat();
            replacementVal = loggerConfig.GetReplacementValue();
            logFilename = GetFullFileName(loggerConfig);
            InitializeLogger();
        }

        public Logger(LoggerConfig loggerConfig)
        {
            datetimeFormat = loggerConfig.GetDateTimeFormat();
            replacementVal = loggerConfig.GetReplacementValue();
            logFilename = GetFullFileName(loggerConfig);
            InitializeLogger();
        }

        private string GetFullFileName(LoggerConfig loggerConfig)
        {
            var fullFilename = AppDomain.CurrentDomain.BaseDirectory;
            if (loggerConfig.GetRelativePath() != "")
            {
                fullFilename += $"{loggerConfig.GetRelativePath()}/";
            }
            fullFilename += $"{loggerConfig.GetFileName()}.csv";
            return fullFilename;
        }

        /// <summary>
        /// Checks if a file previously exists, if not creates the file with headings
        /// </summary>
        private void InitializeLogger()
        {
            if (!File.Exists(logFilename))
            {
                WriteLine("Time,Error Level,Error Message", false);
            }
        }

        #region Public Logger functions

        #region Exception Logs

        /// <summary>
        /// Log an <see cref="Exception"/> as DEBUG
        /// </summary>
        /// <param name="ex"></param>
        public void Debug(Exception ex)
        {
            if (ex != null)
            {
                WriteLog(LogLevel.DEBUG, ExceptionToErrorString(ex));
            }
        }

        /// <summary>
        /// Log an <see cref="Exception"/> as ERROR
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex)
        {
            if (ex != null)
            {
                WriteLog(LogLevel.ERROR, ExceptionToErrorString(ex));
            }
        }

        /// <summary>
        /// Log an <see cref="Exception"/> as Fatal
        /// </summary>
        /// <param name="ex"></param>
        public void Fatal(Exception ex)
        {
            if (ex != null)
            {
                WriteLog(LogLevel.FATAL, ExceptionToErrorString(ex));
            }
        }

        #endregion Exception Logs

        #region Error message logs

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.DEBUG, text.Replace(',', replacementVal));
            }
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.ERROR, text.Replace(',', replacementVal));
            }
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.FATAL, text.Replace(',', replacementVal));
            }
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.INFO, text.Replace(',', replacementVal));
            }
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.TRACE, text.Replace(',', replacementVal));
            }
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            if (text != null)
            {
                WriteLog(LogLevel.WARNING, text.Replace(',', replacementVal));
            }
        }

        #endregion Error message logs

        #endregion Public Logger functions

        #region Write functions

        /// <summary>
        /// Adds date time, loglevel to error text and calls <see cref="WriteLine(string, bool)"/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="text"></param>
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

        #region Helper Functions

        /// <summary>
        /// Builds error text from an <see cref="Exception"/>
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string ExceptionToErrorString(Exception ex)
        {
            string error = "";
            if (!string.IsNullOrEmpty(ex.Message))
            {
                error += $"Message: {ex.Message.Replace(',', replacementVal)};";
            }
            if (!string.IsNullOrEmpty(ex.StackTrace))
            {
                error += $"StackTrace: {ex.StackTrace.Replace(',', replacementVal)};";
            }
            if (ex.InnerException != null)
            {
                error += $"InnerException:{ex.InnerException.Message.Replace(',', replacementVal)}";
            }
            return error;
        }

        #endregion Helper Functions
    }
}
