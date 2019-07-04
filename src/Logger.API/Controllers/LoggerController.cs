using System;
using Microsoft.AspNetCore.Mvc;

namespace Logger.API.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> Get()
        {
            var logger = new nk.logger.csv.Logger();

            // inner exception should be logged
            var exception = new ArgumentNullException("arg-1", new Exception("args-2"));
            logger.Error(exception);

            // comma should not be logged
            logger.Info("sample info text,");

            // should not be logged
            logger.Error("");

            // should not be logged
            logger.Fatal(ex:null);

            return "Completed";
        }
    }
}
