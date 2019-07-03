using System;

namespace nk.logger.csv
{
    public class LoggerConfig
    {
        #region [Variable Declarations]

        /// <summary>
        /// Format for the date time recorded in error log.
        /// Ex: "yyyy-MM-dd HH:mm:ss.fff" 
        /// </summary>
        private string DateTimeFormat { get; set; }

        /// <summary>
        /// Name of the log file (without extension).
        /// Ex: "ErrorLog"
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Relative path from Base directory.
        /// Ex: "logs"
        /// </summary>
        private string RelativePath { get; set; }

        /// <summary>
        /// Value to replace comma (,) with.
        /// Ex: ";"
        /// </summary>
        private char ReplacementValue { get; set; }

        #endregion [Variable Declarations]

        /// <summary>
        /// Assigns default values to all configuration variables
        /// </summary>
        public LoggerConfig()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            FileName = "ErrorLog";
            RelativePath = "";
            ReplacementValue = ';';
        }

        #region [Date Format]

        public LoggerConfig SetDateTimeFormat(string dateTimeFormat)
        {
            if (string.IsNullOrWhiteSpace(dateTimeFormat))
            {
                throw new ArgumentNullException("Date Format cannot be empty");
            }
            this.DateTimeFormat = dateTimeFormat;
            return this;
        }

        public string GetDateTimeFormat()
        {
            return DateTimeFormat;
        }

        #endregion [Date Format]

        #region [File Name]

        public LoggerConfig SetFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("File name cannot be empty");
            }
            this.FileName = fileName;
            return this;
        }

        public string GetFileName()
        {
            return FileName;
        }

        #endregion [File Name]

        #region [Relative Path]

        public LoggerConfig SetRelativePath(string relativePath)
        {
            if (relativePath == null)
            {
                throw new ArgumentNullException("Relative path cannot be null");
            }
            this.RelativePath = relativePath;
            return this;
        }

        public string GetRelativePath()
        {
            return RelativePath;
        }

        #endregion [Relative Path]

        #region [Replacement Value]

        public LoggerConfig SetReplacementValue(char replacementVal)
        {
            if (replacementVal != ' ')
            {
                throw new ArgumentNullException("Replacement Value cannot be empty");
            }
            this.ReplacementValue = replacementVal;
            return this;
        }

        public char GetReplacementValue()
        {
            return ReplacementValue;
        }

        #endregion [Replacement Value]

    }
}
