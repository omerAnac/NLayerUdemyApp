using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedTime", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 7, 7, 9, 56, 15, 560, DateTimeKind.Local).AddTicks(8919), "Pens", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedTime", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 7, 7, 9, 56, 15, 560, DateTimeKind.Local).AddTicks(8937), "Books", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedTime", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2022, 7, 7, 9, 56, 15, 560, DateTimeKind.Local).AddTicks(8939), "NOtebooks", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryID", "CreatedTime", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 7, 9, 56, 15, 561, DateTimeKind.Local).AddTicks(210), "Roting", 100m, 20, null },
                    { 2, 1, new DateTime(2022, 7, 7, 9, 56, 15, 561, DateTimeKind.Local).AddTicks(217), "Faber-Castell", 200m, 15, null },
                    { 3, 2, new DateTime(2022, 7, 7, 9, 56, 15, 561, DateTimeKind.Local).AddTicks(220), "C#101", 150m, 30, null },
                    { 4, 2, new DateTime(2022, 7, 7, 9, 56, 15, 561, DateTimeKind.Local).AddTicks(221), "JAVA#101", 180m, 40, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Weight" },
                values: new object[] { 1, "Red", 100, 1, 200 });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Weight" },
                values: new object[] { 2, "Blue", 300, 2, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
