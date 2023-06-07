using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avondale_College_Shop.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardChargeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipOrderTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToZip = table.Column<int>(type: "int", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    ShipmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Order_Shipment_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "ProductShipment",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShipment", x => new { x.ProductID, x.ShipmentID });
                    table.ForeignKey(
                        name: "FK_ProductShipment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShipment_Shipment_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipmentID",
                table: "Order",
                column: "ShipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderID",
                table: "Product",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShipment_ShipmentID",
                table: "ProductShipment",
                column: "ShipmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShipment");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
