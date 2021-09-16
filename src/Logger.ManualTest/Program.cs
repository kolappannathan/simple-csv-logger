using System;

namespace Logger.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialization

            var config = new nk.logger.csv.LoggerConfig()
                .SetReplacementValue(';')
                .SetRelativePath("logs");
            var logger = new nk.logger.csv.Logger(config);

            #endregion Initialization

            #region Logging

            // inner exception should be logged
            var exception = new ArgumentNullException("arg-1", new Exception("args-2"));
            logger.Error(exception);

            // comma should not be logged
            logger.Info("sample info text,");

            // should not be logged
            logger.Error("");

            // should not be logged
            logger.Fatal(ex: null);

            #endregion Logging

            Console.WriteLine("Completed Test");
            Console.WriteLine("Check if the Excel file is created");
        }
    }
}
