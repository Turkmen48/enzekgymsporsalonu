using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class addsitename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteName",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteName",
                table: "SiteInfos");
        }
    }
}
