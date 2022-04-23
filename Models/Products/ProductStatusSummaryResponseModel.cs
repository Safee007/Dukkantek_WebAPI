using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models.Products
{
    public class ProductStatusSummaryResponseModel
    {
        public List<ProductStatusSummary> ProductStatusSummary { get; set; }
    }

    public class ProductStatusSummary
    {
        public int ProductStatusID { get; set; }

        public int Count { get; set; }
    }
}
