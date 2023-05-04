using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_Prices_PriceId",
                table: "Revenues");

            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_UserInfos_UserInfoId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_PriceId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_UserInfoId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Revenues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Revenues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Revenues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_PriceId",
                table: "Revenues",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_UserInfoId",
                table: "Revenues",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_Prices_PriceId",
                table: "Revenues",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_UserInfos_UserInfoId",
                table: "Revenues",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }
    }
}
