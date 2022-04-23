using Dukkantek_WebAPI.Context;
using Dukkantek_WebAPI.Entities;
using Dukkantek_WebAPI.Models.Products;
using Dukkantek_WebAPI.Repository.IDAL;
using Dukkantek_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.DAL
{
    public class ProductsPost : IProducts
    {
        DukkantekDBContext db;
        public ProductsPost(DukkantekDBContext _db)
        {
            db = _db;
        }

        public BaseResponseModel UpdateProducts(ProductUpdateRequestModel objProductUpdate, int productid)
        {
            BaseResponseModel respModel = new BaseResponseModel();

            if (db != null)
            {
                try
                {
                    var entity = db.Products.FirstOrDefault(item => item.ID == productid);

                    if (entity != null)
                    {
                        entity.ProductStatusID = (int)objProductUpdate.ProductStatus;
                        entity.ModifiedBy = objProductUpdate.ModifiedBy;
                        entity.ModifiedDate = DateTime.Now;

                        db.Products.Update(entity);

                        db.SaveChanges();

                        respModel.Status.ResponseCode = "00";
                        respModel.Status.ResponseDescription = "Success";
                    }

                }
                catch (Exception ex)
                {
                    respModel.Status.ResponseCode = "95";
                    respModel.Status.ResponseDescription = ex.ToString();
                }
            }

            return respModel;
        }

        public ProductStatusSummaryResponseModel ProductStatusSummary()
        {
            ProductStatusSummaryResponseModel respModel = new ProductStatusSummaryResponseModel();

            List<ProductStatusSummary> entity = new List<ProductStatusSummary>();

            if (db != null)
            {
                entity = db.Products.Where(y => y.IsActive == true).GroupBy(x => x.ProductStatusID).Select(group => new ProductStatusSummary
                {
                    ProductStatusID = group.Key,
                    Count = group.Count()
                }).ToList();

                if (entity != null)
                {
                    respModel.ProductStatusSummary = new List<ProductStatusSummary>();
                    respModel.ProductStatusSummary = entity;
                }
            }

            return respModel;
        }
    }
}
