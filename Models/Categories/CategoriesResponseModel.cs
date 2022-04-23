using Dukkantek_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models.Categories
{
    public class CategoriesResponseModel
    {
        public List<ProductCategories> Categories { get; set; }
    }
}
