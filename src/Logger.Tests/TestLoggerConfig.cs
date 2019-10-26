using NUnit.Framework;
using System;

namespace Logger.Tests
{
    public class TestLoggerConfig
    {
        #region [Declarations]

        private const string relativePath = "logs";
        private const string fileName = "ErrorLog";
        private const string dateFormat = "DD-MM-YYYY HH:MM:SS";
        private const char replacementValue = ';';

        #endregion [Declarations]

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test setting config with improper values and asserts the exceptions thrown
        /// </summary>
        [Test]
        public void TestConfigSetters()
        {
            var config = new nk.logger.csv.LoggerConfig();
            Assert.Throws<ArgumentNullException>(() => config.SetDateTimeFormat(null));
            Assert.Throws<ArgumentNullException>(() => config.SetDateTimeFormat(" "));

            Assert.Throws<ArgumentNullException>(() => config.SetFileName(null));
            Assert.Throws<ArgumentNullException>(() => config.SetFileName(" "));

            Assert.Throws<ArgumentNullException>(() => config.SetRelativePath(null));

            Assert.Throws<ArgumentNullException>(() => config.SetReplacementValue(' '));
        }

        /// <summary>
        /// Test setting config and checks if the get function returns same value
        /// </summary>
        [Test]
        public void TestConfigGetters()
        {
            var config = new nk.logger.csv.LoggerConfig()
                .SetReplacementValue(replacementValue)
                .SetFileName(fileName)
                .SetDateTimeFormat(dateFormat)
                .SetRelativePath(relativePath);

            Assert.AreEqual(config.GetReplacementValue(), replacementValue);
            Assert.AreEqual(config.GetFileName(), fileName);
            Assert.AreEqual(config.GetDateTimeFormat(), dateFormat);
            Assert.AreEqual(config.GetRelativePath(), relativePath);

            Assert.Pass();
        }
    }
}