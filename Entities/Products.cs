using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public int CategoryID { get; set; }

        public int ProductStatusID { get; set; }

        public bool IsActive { get; set; }

        public int ?CreatedBy { get; set; }

        public DateTime ?CreatedDate { get; set; }

        public int ?ModifiedBy { get; set; }

        public DateTime ?ModifiedDate { get; set; }
    }
}
