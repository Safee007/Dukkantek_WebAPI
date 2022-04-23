using Dukkantek_WebAPI.Context;
using Dukkantek_WebAPI.Models.ProductSales;
using Dukkantek_WebAPI.Repository.IDAL;
using Dukkantek_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.DAL
{
    public class ProductSalesPost : IProductSales
    {
        DukkantekDBContext db;
        public ProductSalesPost(DukkantekDBContext _db)
        {
            db = _db;
        }

        public BaseResponseModel Sale(SaleRequestModel objProductSale)
        {
            BaseResponseModel respModel = new BaseResponseModel();

            if (db != null)
            {
                try
                {
                    var entity = db.Products.FirstOrDefault(item => item.ID == objProductSale.ProductID && item.ProductStatusID == 1 && item.IsActive == true);

                    if (entity != null)
                    {
                        entity.ProductStatusID = 2;
                        entity.ModifiedBy = objProductSale.CreatedBy;
                        entity.ModifiedDate = DateTime.Now;

                        db.Products.Update(entity);

                        db.ProductSales.Add(new Entities.ProductSales
                        {

                            ProductID = objProductSale.ProductID,
                            SaleTypeID = (int)objProductSale.SaleTypeID,
                            CustomerID = objProductSale.CustomerID,
                            ProductSaleStatusID = 1,
                            IsActive = true,
                            CreatedBy = objProductSale.CreatedBy,
                            CreatedDate = DateTime.Now

                        }); ;

                        db.SaveChanges();

                        respModel.Status.ResponseCode = "00";
                        respModel.Status.ResponseDescription = "Success";
                    }

                    else
                    {
                        respModel.Status.ResponseCode = "01";
                        respModel.Status.ResponseDescription = "No products found";
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

    }
}
