using Dukkantek_WebAPI.Models.ProductSales;
using Dukkantek_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Repository.IDAL
{
    public interface IProductSales
    {
        BaseResponseModel Sale(SaleRequestModel objProductSale);
    }
}
