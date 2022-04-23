using Dukkantek_WebAPI.Context;
using Dukkantek_WebAPI.Entities;
using Dukkantek_WebAPI.Models.Categories;
using Dukkantek_WebAPI.Repository.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.DAL
{
    public class ProductCategoriesPost : IProductCategoriesPost
    {
        DukkantekDBContext db;
        public ProductCategoriesPost(DukkantekDBContext _db)
        {
            db = _db;
        }

        public CategoriesResponseModel GetCategories()
        {
            CategoriesResponseModel resp = new CategoriesResponseModel();

            if (db != null)
            {
                var result = db.ProductCategories.ToList();

                if (result != null)
                {   
                    resp.Categories = new List<ProductCategories>();

                    resp.Categories = result;
                }
            }

            return resp;
        }
    }
}
