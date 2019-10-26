using System;
using System.Text;

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

        public readonly Encoding encoding;

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
            encoding = Encoding.UTF8;
        }

        #region [Config variables getter and setters]

        #region [Date Format]

        public LoggerConfig SetDateTimeFormat(string dateTimeFormat)
        {
            if (string.IsNullOrWhiteSpace(dateTimeFormat))
            {
                throw new ArgumentNullException("Date Format cannot be empty");
            }
            DateTimeFormat = dateTimeFormat;
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
            FileName = fileName;
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
            RelativePath = relativePath.Trim();
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
            if (replacementVal == ' ')
            {
                throw new ArgumentNullException("Replacement Value cannot be empty");
            }
            ReplacementValue = replacementVal;
            return this;
        }

        public char GetReplacementValue()
        {
            return ReplacementValue;
        }

        #endregion [Replacement Value]

        #endregion [Config variables getter and setters]

        #region [Other Getter functions]

        #region [Full file path]

        /// <summary>
        /// Combaines base direstory, relative path returns full file path
        /// </summary>
        public string GetFullFilePath()
        {
            var fullFilePath = AppDomain.CurrentDomain.BaseDirectory;
            if (RelativePath != "")
            {
                fullFilePath += $"{RelativePath}/";
            }
            return fullFilePath;
        }

        #endregion [Full file path]

        #region [Full File Name]

        /// <summary>
        /// Returns full file name with path(base directory + relative path) and extension
        /// </summary>
        public string GetFullFileName()
        {
            var fullFilename = $"{GetFullFilePath()}{FileName}.csv";
            return fullFilename;
        }
        #endregion [Full File Name]

        #endregion [Other Getter functions]

    }
}
