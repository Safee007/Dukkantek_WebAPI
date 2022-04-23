using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dukkantek_WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoriesID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductStatusID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SaleTypeID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ProductSaleStatusID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSaleStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoriesID", "Category", "IsActive" },
                values: new object[,]
                {
                    { 1, "Electronics", true },
                    { 2, "Fragrances", true },
                    { 3, "Footwear", true }
                });

            migrationBuilder.InsertData(
                table: "ProductSaleStatus",
                columns: new[] { "ID", "IsActive", "Status" },
                values: new object[,]
                {
                    { 1, true, "SOLD" },
                    { 2, true, "VOID" },
                    { 3, true, "REFUND" },
                    { 4, true, "EXCHANGE" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "ID", "IsActive", "Status" },
                values: new object[,]
                {
                    { 1, true, "INSTOCK" },
                    { 2, true, "SOLD" },
                    { 3, true, "DAMAGED" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Barcode", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "ProductStatusID", "Weight" },
                values: new object[,]
                {
                    { 35, "57879", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(179), "This is a description of Product-341", true, null, null, "Product-341", 2, 13m },
                    { 34, "60255", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(9940), "This is a description of Product-331", true, null, null, "Product-331", 2, 17m },
                    { 33, "66007", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(9687), "This is a description of Product-321", true, null, null, "Product-321", 2, 14m },
                    { 32, "88462", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(9428), "This is a description of Product-311", true, null, null, "Product-311", 1, 17m },
                    { 27, "50653", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(8086), "This is a description of Product-261", true, null, null, "Product-261", 1, 16m },
                    { 30, "34900", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(8814), "This is a description of Product-291", true, null, null, "Product-291", 1, 11m },
                    { 29, "41567", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(8565), "This is a description of Product-281", true, null, null, "Product-281", 2, 16m },
                    { 28, "48667", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(8333), "This is a description of Product-271", true, null, null, "Product-271", 2, 19m },
                    { 36, "30310", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(431), "This is a description of Product-351", true, null, null, "Product-351", 1, 17m },
                    { 31, "44202", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(9051), "This is a description of Product-301", true, null, null, "Product-301", 1, 18m },
                    { 37, "81397", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(775), "This is a description of Product-361", true, null, null, "Product-361", 2, 13m },
                    { 42, "84215", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(2561), "This is a description of Product-411", true, null, null, "Product-411", 1, 17m },
                    { 39, "37492", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(1457), "This is a description of Product-381", true, null, null, "Product-381", 2, 18m },
                    { 40, "95363", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(1770), "This is a description of Product-391", true, null, null, "Product-391", 1, 14m },
                    { 41, "98595", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(2217), "This is a description of Product-401", true, null, null, "Product-401", 2, 12m },
                    { 26, "79455", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(7828), "This is a description of Product-251", true, null, null, "Product-251", 2, 16m },
                    { 43, "36450", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(2893), "This is a description of Product-421", true, null, null, "Product-421", 2, 13m },
                    { 44, "30093", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(3146), "This is a description of Product-431", true, null, null, "Product-431", 1, 10m },
                    { 45, "29208", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(3422), "This is a description of Product-441", true, null, null, "Product-441", 1, 17m },
                    { 46, "27589", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(3750), "This is a description of Product-451", true, null, null, "Product-451", 2, 11m },
                    { 47, "25035", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(4018), "This is a description of Product-461", true, null, null, "Product-461", 1, 19m },
                    { 48, "32062", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(4280), "This is a description of Product-471", true, null, null, "Product-471", 2, 12m },
                    { 38, "45700", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(1128), "This is a description of Product-371", true, null, null, "Product-371", 2, 18m },
                    { 25, "23435", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(7505), "This is a description of Product-241", true, null, null, "Product-241", 2, 14m },
                    { 20, "39927", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(6239), "This is a description of Product-191", true, null, null, "Product-191", 1, 10m },
                    { 23, "73627", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(7031), "This is a description of Product-221", true, null, null, "Product-221", 2, 17m },
                    { 1, "48454", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 230, DateTimeKind.Local).AddTicks(545), "This is a description of Product-01", true, null, null, "Product-01", 1, 12m },
                    { 2, "59646", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(1354), "This is a description of Product-11", true, null, null, "Product-11", 1, 13m },
                    { 3, "87964", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(1751), "This is a description of Product-21", true, null, null, "Product-21", 2, 18m },
                    { 4, "34633", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(2017), "This is a description of Product-31", true, null, null, "Product-31", 2, 10m },
                    { 5, "17540", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(2301), "This is a description of Product-41", true, null, null, "Product-41", 1, 11m },
                    { 6, "88949", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(2567), "This is a description of Product-51", true, null, null, "Product-51", 1, 18m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Barcode", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "ProductStatusID", "Weight" },
                values: new object[,]
                {
                    { 7, "79846", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(2813), "This is a description of Product-61", true, null, null, "Product-61", 2, 12m },
                    { 8, "31766", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(3162), "This is a description of Product-71", true, null, null, "Product-71", 2, 10m },
                    { 9, "46756", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(3414), "This is a description of Product-81", true, null, null, "Product-81", 1, 15m },
                    { 10, "77409", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(3658), "This is a description of Product-91", true, null, null, "Product-91", 2, 13m },
                    { 24, "89186", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(7269), "This is a description of Product-231", true, null, null, "Product-231", 2, 18m },
                    { 11, "88551", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(3904), "This is a description of Product-101", true, null, null, "Product-101", 1, 12m },
                    { 13, "83484", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(4478), "This is a description of Product-121", true, null, null, "Product-121", 2, 15m },
                    { 14, "21049", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(4718), "This is a description of Product-131", true, null, null, "Product-131", 1, 10m },
                    { 15, "38306", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(4955), "This is a description of Product-141", true, null, null, "Product-141", 1, 16m },
                    { 16, "83550", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(5192), "This is a description of Product-151", true, null, null, "Product-151", 2, 10m },
                    { 17, "86919", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(5501), "This is a description of Product-161", true, null, null, "Product-161", 1, 19m },
                    { 18, "52419", 2, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(5758), "This is a description of Product-171", true, null, null, "Product-171", 2, 17m },
                    { 19, "66676", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(5998), "This is a description of Product-181", true, null, null, "Product-181", 1, 15m },
                    { 49, "50950", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(4538), "This is a description of Product-481", true, null, null, "Product-481", 2, 19m },
                    { 21, "61372", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(6554), "This is a description of Product-201", true, null, null, "Product-201", 1, 10m },
                    { 22, "44936", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(6796), "This is a description of Product-211", true, null, null, "Product-211", 1, 14m },
                    { 12, "26271", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 232, DateTimeKind.Local).AddTicks(4225), "This is a description of Product-111", true, null, null, "Product-111", 2, 13m },
                    { 50, "14160", 1, 1, new DateTime(2022, 4, 23, 14, 34, 17, 233, DateTimeKind.Local).AddTicks(4858), "This is a description of Product-491", true, null, null, "Product-491", 2, 14m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "ProductSaleStatus");

            migrationBuilder.DropTable(
                name: "ProductStatus");
        }
    }
}
