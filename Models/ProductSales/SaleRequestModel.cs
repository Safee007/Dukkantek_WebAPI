using Dukkantek_WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models.ProductSales
{
    public class SaleRequestModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ProductID")]
        public int ProductID { get; set; }

        [Required]
        public SaleType SaleTypeID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid UserID")]
        public int CreatedBy { get; set; }
    }
}
