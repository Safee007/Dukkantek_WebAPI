using Dukkantek_WebAPI.Entities;
using Dukkantek_WebAPI.Models.Products;
using Dukkantek_WebAPI.Repository.IDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductsController : ControllerBase
    {
        IProducts postRepository;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ProductsController(IProducts _postRepository)
        {
            postRepository = _postRepository;
        }

        [HttpPut]
        [Route("UpdateProduct/{productid}")]
        public IActionResult GetCategories([FromBody] ProductUpdateRequestModel objProductUpdate, int productid)
        {
            IActionResult response = null;

            try
            {
                var products = postRepository.UpdateProducts(objProductUpdate , productid);

                if (products == null && products.Status.ResponseCode != "00")
                {
                    throw new Exception(products.Status.ResponseDescription); // This is done to reuse the generalized exception logic.
                }

                response = Ok(products);

                return response;
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => { logger.Error(string.Format("Method {0} SessionID: {1} | Exception {2}", "UpdateProduct", Request.Headers["SessionId"], ex.Message)); });

                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = "500";
                errorModel.Status.ResponseDescription = "Internal Server Error";

                response = StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }

            return response;

        }

        [HttpGet]
        [Route("ProductStatusSummary")]
        public IActionResult ProductStatusSummary()
        {
            IActionResult response = null;

            try
            {
                var products = postRepository.ProductStatusSummary();

                if (products == null || products.ProductStatusSummary == null || products.ProductStatusSummary.Count <= 0)
                {
                    response = NoContent();                                    
                }

                response = Ok(products);

                return response;
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => { logger.Error(string.Format("Method {0} SessionID: {1} | Exception {2}", "UpdateProduct", Request.Headers["SessionId"], ex.Message)); });

                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = "500";
                errorModel.Status.ResponseDescription = "Internal Server Error";

                response = StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }

            return response;

        }
    }
}
