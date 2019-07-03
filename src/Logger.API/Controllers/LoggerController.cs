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
            var logger = new nk.logger.csv.Logger("yyyy-MM-dd HH:mm:ss.fff", "ErrorLog");
            var exception = new ArgumentNullException("arg-1");
            logger.Error(exception);
            logger.Info("sample info text");
            return "Completed";
        }
    }
}
