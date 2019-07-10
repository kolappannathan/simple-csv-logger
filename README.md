# Simple CSV Logger

[![Website](https://img.shields.io/badge/view-website-blue.svg?logo=mozilla%20firefox&style=flat-square)](https://kolappannathan.github.io/projects/simple-csv-logger/index.html)
[![GitHub](https://img.shields.io/github/license/kolappannathan/simple-csv-logger.svg?style=flat-square)](#)
[![GitHub issues](https://img.shields.io/github/issues/kolappannathan/simple-csv-logger.svg?style=flat-square)](#)
[![GitHub contributors](https://img.shields.io/github/contributors/kolappannathan/simple-csv-logger.svg?color=orange&style=flat-square)](#)

This is a simple logger for logging errors in a c# application. But instead of writing the logs to a txt file this logger writes them into a CSV file.

### Downloads

[![Nuget](https://img.shields.io/nuget/v/nk.logger.csv.svg?logo=nuget&style=flat-square)](https://www.nuget.org/packages/nk.logger.csv/)

### Usage
 1. Install the [nuget package](https://www.nuget.org/packages/nk.logger.csv/).
 2. Create an instance for `nk.logger.csv.Logger` in your base class.
 3. Edit the configuration according to your application needs.
 4. Create wrapper functions for the functions you need from csv.logger.
 5. Inherit this base class in your other classes.

#### Sample

Below is a sample base class with configurations,

```csharp
using System;

namespace Core.Lib
{
    public class Logger
    {
        private nk.logger.csv.Logger csvLogger;

        public Logger(string dateFormat, string fileName, string relativePath = "", char replacementValue = ';')
        {
            var config = new nk.logger.csv.LoggerConfig();
            
            // adding configuration
            config.SetDateTimeFormat(dateFormat)
                .SetFileName(fileName)
                .SetRelativePath(relativePath)
                .SetReplacementValue(replacementValue);
            
            csvLogger = new nk.logger.csv.Logger(config);
        }

        #region [Public Logger functions]

        public void Error(Exception ex) => csvLogger.Error(ex);

        public void Fatal(Exception ex) => csvLogger.Fatal(ex);

        public void Debug(string text) => csvLogger.Debug(text);

        public void Error(string text) => csvLogger.Error(text);

        public void Fatal(string text) => csvLogger.Fatal(text);

        #endregion [Public Logger functions]
    }
}
```
