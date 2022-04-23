using Dukkantek_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Context
{
    public class DukkantekDBContext : DbContext
    {
        public DukkantekDBContext(DbContextOptions<DukkantekDBContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCategories> ProductCategories { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductSales> ProductSales { get; set; }

        public DbSet<ProductStatus> ProductStatus { get; set; }

        public DbSet<ProductSaleStatus> ProductSaleStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Populating Master Data

            modelBuilder.Entity<ProductCategories>().HasData(
                new ProductCategories
                {
                    ProductCategoriesID = 1,
                    Category = "Electronics",
                    IsActive = true
                },
                new ProductCategories
                {
                    ProductCategoriesID = 2,
                    Category = "Fragrances",
                    IsActive = true
                },
                new ProductCategories
                {
                    ProductCategoriesID = 3,
                    Category = "Footwear",
                    IsActive = true
                }
            );


            modelBuilder.Entity<ProductStatus>().HasData(
               new ProductStatus
               {
                   ID = 1,
                   Status = "INSTOCK",
                   IsActive = true
               },
               new ProductStatus
               {
                   ID = 2,
                   Status = "SOLD",
                   IsActive = true
               },
               new ProductStatus
               {
                   ID = 3,
                   Status = "DAMAGED",
                   IsActive = true
               }
           );

            modelBuilder.Entity<ProductSaleStatus>().HasData(
               new ProductSaleStatus
               {
                   ID = 1,
                   Status = "SOLD",
                   IsActive = true
               },
               new ProductSaleStatus
               {
                   ID = 2,
                   Status = "VOID",
                   IsActive = true
               },
               new ProductSaleStatus
               {
                   ID = 3,
                   Status = "REFUND",
                   IsActive = true
               },
               new ProductSaleStatus
               {
                   ID = 4,
                   Status = "EXCHANGE",
                   IsActive = true
               }
           );

            #endregion


            #region DummyData

            Random objRandom = new Random();

            for (int i = 0; i < 50; i++)
            {

                modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ID = i + 1,
                    Name = "Product-" + i + 1,
                    Barcode = new Random().Next(100000, 999999).ToString(),
                    Description = "This is a description of Product-" + i + 1,
                    Weight = new Random().Next(10, 20),
                    CategoryID = new Random().Next(1, 4),
                    ProductStatusID = new Random().Next(1, 4),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now

                }
                ) ;


            }

            #endregion

        }
    }
}
