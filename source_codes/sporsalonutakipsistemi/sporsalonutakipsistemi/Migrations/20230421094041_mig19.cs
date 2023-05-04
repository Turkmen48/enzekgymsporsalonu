using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_Users_UserId",
                table: "Revenues");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Revenues",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Revenues_UserId",
                table: "Revenues",
                newName: "IX_Revenues_UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_UserInfos_UserInfoId",
                table: "Revenues",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_UserInfos_UserInfoId",
                table: "Revenues");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Revenues",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Revenues_UserInfoId",
                table: "Revenues",
                newName: "IX_Revenues_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_Users_UserId",
                table: "Revenues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
