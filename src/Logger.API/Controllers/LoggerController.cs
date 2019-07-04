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
            var exception = new ArgumentNullException("arg-1");
            logger.Error(exception);
            logger.Info("sample info text,");
            logger.Error("");
            logger.Fatal(ex:null);
            return "Completed";
        }
    }
}
