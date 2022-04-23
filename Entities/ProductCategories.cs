using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Entities
{
    public class ProductCategories 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCategoriesID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category cannot be more tham 50 characters")]
        public string Category { get; set; }

        public bool IsActive { get; set; }
    }
}
