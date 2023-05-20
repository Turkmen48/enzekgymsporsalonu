using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class emailsettings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EmailSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "EmailSettings");
        }
    }
}
