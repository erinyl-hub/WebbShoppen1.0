using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShoppen1._0.Migrations
{
    /// <inheritdoc />
    public partial class detfunkar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailsId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderDetailsId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderDetailsId",
                table: "Product",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailsId",
                table: "Product",
                column: "OrderDetailsId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
