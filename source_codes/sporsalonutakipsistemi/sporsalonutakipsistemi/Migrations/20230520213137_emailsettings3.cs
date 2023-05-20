using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class emailsettings3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailTemplate",
                table: "EmailSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailTemplate",
                table: "EmailSettings");
        }
    }
}
