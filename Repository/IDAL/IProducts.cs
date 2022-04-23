using Dukkantek_WebAPI.Models.Products;
using Dukkantek_WebAPI.Models;

namespace Dukkantek_WebAPI.Repository.IDAL
{
    public interface IProducts
    {
        BaseResponseModel UpdateProducts(ProductUpdateRequestModel objProductUpdate, int productid);

        ProductStatusSummaryResponseModel ProductStatusSummary();
    }
}
