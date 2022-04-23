using Dukkantek_WebAPI.Models.ProductSales;
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
    public class ProductSalesController : ControllerBase
    {
        IProductSales postRepository;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ProductSalesController(IProductSales _postRepository)
        {
            postRepository = _postRepository;
        }

        [HttpPost]
        [Route("Sale")]
        public IActionResult Sale([FromBody] SaleRequestModel objProductSale)
        {
            IActionResult response = null;

            if (!ModelState.IsValid)
            {
                List<string> allErrors = ModelState.Values.Select(v => v.Errors[0].ErrorMessage).ToList();

                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = "01";
                errorModel.Status.ResponseDescription = allErrors[0];
                response = BadRequest(errorModel);
                return response;
            }

            try
            {
                var products = postRepository.Sale(objProductSale);

                if (products.Status.ResponseCode == "95")
                {
                    throw new Exception(products.Status.ResponseDescription); // This is done to reuse the generalized exception logic.
                }
                else if (products.Status.ResponseCode == "01")
                {
                    response = UnprocessableEntity(products);
                }
                else
                {
                    response = Ok(products);
                }

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
