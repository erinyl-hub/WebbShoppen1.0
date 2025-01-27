using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShoppen1._0.Migrations
{
    /// <inheritdoc />
    public partial class payInfoThing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "PaymentInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_UserInfoId",
                table: "PaymentInfos",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInfos_UserInfo_UserInfoId",
                table: "PaymentInfos",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfos_UserInfo_UserInfoId",
                table: "PaymentInfos");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfos_UserInfoId",
                table: "PaymentInfos");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "PaymentInfos");
        }
    }
}
