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
        private string DateFormat { get; set; }

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
        private string ReplacementValue { get; set; }

        #endregion [Variable Declarations]

        /// <summary>
        /// Assigns default values to all configuration variables
        /// </summary>
        public LoggerConfig()
        {
            DateFormat = "yyyy-MM-dd HH:mm:ss.fff";
            FileName = "ErrorLog";
            RelativePath = "";
            ReplacementValue = ";";
        }

        #region [Date Format]

        public LoggerConfig SetDateFormat(string dateFormat)
        {
            if (string.IsNullOrWhiteSpace(dateFormat))
            {
                throw new ArgumentNullException("Date Format cannot be empty");
            }
            this.DateFormat = dateFormat;
            return this;
        }

        public string GetDateFormat()
        {
            return DateFormat;
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

        public LoggerConfig SetReplacementValue(string replacementVal)
        {
            if (string.IsNullOrEmpty(replacementVal))
            {
                throw new ArgumentNullException("Replacement Value cannot be empty");
            }
            this.ReplacementValue = replacementVal;
            return this;
        }

        public string GetReplacementValue()
        {
            return ReplacementValue;
        }

        #endregion [Replacement Value]

    }
}
