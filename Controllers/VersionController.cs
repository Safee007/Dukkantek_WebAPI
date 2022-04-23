using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telematics_WebAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [Route("Version")]
        public IActionResult Version()
        {

            var test = HttpContext.Connection.RemoteIpAddress;

            IActionResult response = null;

            string version = "0.2.8";

            var result = version;
            response = Ok(result);

            Task.Factory.StartNew(() => { logger.Info(string.Format("API Started Successfully!! Version: {0}", version)); });

            return response;
        }
    }
}
