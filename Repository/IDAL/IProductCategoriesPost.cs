using Dukkantek_WebAPI.Entities;
using Dukkantek_WebAPI.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Repository.IDAL
{
    public interface IProductCategoriesPost
    {
        CategoriesResponseModel GetCategories();
    }
}
