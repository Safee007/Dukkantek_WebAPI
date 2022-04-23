using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Entities
{
    public class ProductSales
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int SaleTypeID { get; set; }

        public int CustomerID { get; set; }

        public int ProductSaleStatusID { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
