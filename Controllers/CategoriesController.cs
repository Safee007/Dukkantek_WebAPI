using Dukkantek_WebAPI.Repository.IDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using Dukkantek_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IProductCategoriesPost postRepository;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CategoriesController(IProductCategoriesPost _postRepository)
        {
            postRepository = _postRepository;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            IActionResult response = null;

            try
            {
                var categories = postRepository.GetCategories();
                
                if (categories == null)
                {
                    response = NotFound();
                }

                response = Ok(categories);

                return response;
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => { logger.Error(string.Format("Method {0} SessionID: {1} | Exception {2}", "Lotteries", Request.Headers["SessionId"], ex.Message)); });

                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = "500";
                errorModel.Status.ResponseDescription = "Internal Server Error";

                response = StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }

            return response;

        }
    }
}
