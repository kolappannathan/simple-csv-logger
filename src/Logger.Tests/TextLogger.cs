using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    public class TextLogger
    {

        #region [Declarations]

        private nk.logger.csv.Logger csvLogger;
        private static class MyVariables
        {
            public const string fileName = "ErrorLog.csv";
            public const string innerException = "System.ArgumentNullException: arg-1 ---> System.Exception: args-2   --- End of inner exception stack trace ---";
            public const string commaReplacedTxt = "sample info text;";
            public const string commaReplaceFailedTxt = "sample info text,";
        }

        #endregion [Declarations]

        [SetUp]
        public void Setup()
        {
            if (File.Exists(MyVariables.fileName))
            {
                File.Delete(MyVariables.fileName);
            }
            csvLogger = new nk.logger.csv.Logger();
        }

        /// <summary>
        /// Checks if ErrorLog file is created
        /// </summary>
        [Test]
        public void TestFileCreation()
        {
            FileAssert.Exists(MyVariables.fileName);
        }

        /// <summary>
        /// Checks if exceptions and inner exceptions are recorded properly
        /// </summary>
        [Test]
        public void TestExceptionLogging()
        {
            var exception = new ArgumentNullException("arg-1", new Exception("args-2"));
            var isLogged = false;

            csvLogger.Error(exception);
            
            var lines = File.ReadLines(MyVariables.fileName);
            foreach (var line in lines)
            {
                if(line.Split(',').Any(x => x == MyVariables.innerException))
                {
                    isLogged = true;
                }
            }

            Assert.IsTrue(isLogged);
        }

        /// <summary>
        /// Checks if comma is replaced properly
        /// </summary>
        [Test]
        public void TestCommaReplacement()
        {
            var isReplaced = false;

            csvLogger.Info("sample info text,");

            var lines = File.ReadLines(MyVariables.fileName);
            foreach (var line in lines)
            {
                if(line.Split(',').Any(x => x == MyVariables.commaReplacedTxt))
                {
                    isReplaced = true;
                }

                if (line.Split(',').Any(x => x == MyVariables.commaReplaceFailedTxt))
                {
                    isReplaced = false;
                }
            }

            Assert.IsTrue(isReplaced);
        }


    }
}
