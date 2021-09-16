# Simple CSV Logger
![Targets .Net standard 2.0](https://img.shields.io/badge/Targets-.Net%20Standard%202.1-blue?logo=.net&style=flat-square)
[![GitHub](https://img.shields.io/github/license/kolappannathan/simple-csv-logger.svg?style=flat-square)](#)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/kolappannathan/simple-csv-logger/CI?logo=github&style=flat-square&label=CI)](https://github.com/kolappannathan/simple-csv-logger/actions?query=workflow%3ACI)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/kolappannathan/simple-csv-logger/CD?logo=github&style=flat-square&label=CD)](https://github.com/kolappannathan/simple-csv-logger/actions?query=workflow%3ACD)

This is a simple logger for logging errors in a c# application. But instead of writing the logs to a txt file this logger writes them into a CSV file.

**Downloads:** [![Nuget](https://img.shields.io/nuget/v/nk.logger.csv.svg?logo=nuget&style=flat-square)](https://www.nuget.org/packages/nk.logger.csv/)

### Usage
 1. Install the [nuget package](https://www.nuget.org/packages/nk.logger.csv/).
 2. Create an instance for `nk.logger.csv.Logger` in your base class.
 3. Edit the configuration according to your application needs.
 4. Create wrapper functions for the functions you need from csv.logger.
 5. Inherit this base class in your other classes.

#### Example

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
