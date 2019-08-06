For full documentation view in: https://kolappannathan.github.io/projects/simple-csv-logger/

## Usage

 - Install the NuGet package.
 - Create a csvlogger instance in your base class.
 - Pass the filename, datetime, relative path and other parameters according to your application.
 - Create wrapper functions for the functions you need from csv.logger.
 - Inherit this base class in your other classes.

## Code Sample

````
public class Base
{
  private nk.logger.csv.Logger csvLogger;
 
  public Base()
  {
     csvLogger = new nk.logger.csv.Logger();
  }
            
  public void Error(Exception ex)
  {
     csvLogger.Error(ex);
  }
}
````