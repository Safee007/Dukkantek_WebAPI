using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Entities
{
    public class ProductStatus
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Status cannot be more tham 50 characters")]
        public string Status { get; set; }

        public bool IsActive { get; set; }
    }
}
