using System;
using System.IO;

namespace nk.logger.csv
{
    public class Logger
    {
        #region [Declarations]

        private readonly LoggerConfig config;

        #endregion [Declarations]

        #region [Initialization]

        /// <summary>
        /// Initiate an instance of Logger class with default config
        /// </summary>
        public Logger()
        {
            config = new LoggerConfig();
            InitializeLogFile();
        }

        /// <summary>
        /// Initiate an instance of Logger class with custom config
        /// </summary>
        /// <param name="loggerConfig">Custom configuration</param>
        public Logger(LoggerConfig loggerConfig)
        {
            config = loggerConfig;
            InitializeLogFile();
        }

        /// <summary>
        /// Checks if a file previously exists, if not creates the file with headings
        /// </summary>
        private void InitializeLogFile()
        {
            if (!File.Exists(config.GetFullFileName()))
            {
                WriteLine("Time,Error Level,Error Message", false);
            }
        }

        #endregion [Initialization]

        #region [Public Logger functions]

        #region [Exception Logs]

        /// <summary>
        /// Log an <see cref="Exception"/> as DEBUG
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public void Debug(Exception ex) => WriteLog(LogLevels.DEBUG, ex?.ToString());

        /// <summary>
        /// Log an <see cref="Exception"/> as ERROR
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public void Error(Exception ex) => WriteLog(LogLevels.ERROR, ex?.ToString());

        /// <summary>
        /// Log an <see cref="Exception"/> as Fatal
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public void Fatal(Exception ex) => WriteLog(LogLevels.FATAL, ex?.ToString());

        #endregion [Exception Logs]

        #region [Error message logs]

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Debug(string text) => WriteLog(LogLevels.DEBUG, text);

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Error(string text) => WriteLog(LogLevels.ERROR, text);

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Fatal(string text) => WriteLog(LogLevels.FATAL, text);

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Info(string text) => WriteLog(LogLevels.INFO, text);

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Trace(string text) => WriteLog(LogLevels.TRACE, text);

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message to log</param>
        public void Warning(string text) => WriteLog(LogLevels.WARNING, text);

        #endregion [Error message logs]

        #endregion [Public Logger functions]

        #region [Write functions]

        /// <summary>
        /// Adds date time, loglevel to error text and calls <see cref="WriteLine(string, bool)"/>
        /// </summary>
        private void WriteLog(string logLevel, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace(',', config.GetReplacementValue());
                text = RemoveLineEndings(text);
                string pretext = $"{DateTime.Now.ToString(config.GetDateTimeFormat())},{logLevel},";
                WriteLine(pretext + text);
            }
        }

        /// <summary>
        /// Writes the input text into log file
        /// </summary>
        /// <param name="text">Input text</param>
        /// <param name="append">Whether to append the old text or replace it</param>
        private void WriteLine(string text, bool append = true)
        {
            using (var writer = new StreamWriter(config.GetFullFileName(), append, config.encoding))
            {
                writer.WriteLine(text);
            }
        }

        #endregion [Write Functions]

        #region [Helper Functions]

        /// <summary>
        /// Removes all line endings from the text
        /// Ref: https://stackoverflow.com/a/6765676/5407188
        /// </summary>
        private static string RemoveLineEndings(string value)
        {
            return value.Replace("\r\n", string.Empty)
                        .Replace("\n", string.Empty)
                        .Replace("\r", string.Empty)
                        .Replace(((char)0x2028).ToString(), string.Empty) // line separator
                        .Replace(((char)0x2029).ToString(), string.Empty); // paragraph separator
        }

        #endregion [Helper Functions]
    }
}
