using Dukkantek_WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models.Products
{
    public class ProductUpdateRequestModel
    {
        public ProductStatus ProductStatus { get; set; }

        public int ModifiedBy { get; set; }


    }
}
