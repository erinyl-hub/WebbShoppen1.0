using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShoppen1._0.Migrations
{
    /// <inheritdoc />
    public partial class paymentinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ShipingCost",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CardInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardCVV = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardInfo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice = table.Column<bool>(type: "bit", nullable: false),
                    BillingAdress = table.Column<int>(type: "int", nullable: false),
                    Installment = table.Column<bool>(type: "bit", nullable: false),
                    MountCount = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<bool>(type: "bit", nullable: false),
                    CardInfoId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentInfos_CardInfo_CardInfoId",
                        column: x => x.CardInfoId,
                        principalTable: "CardInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardInfo_CardNumber",
                table: "CardInfo",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardInfo_UserId",
                table: "CardInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_CardInfoId",
                table: "PaymentInfos",
                column: "CardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_OrderId",
                table: "PaymentInfos",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentInfos");

            migrationBuilder.DropTable(
                name: "CardInfo");

            migrationBuilder.DropColumn(
                name: "ShipingCost",
                table: "Order");
        }
    }
}
