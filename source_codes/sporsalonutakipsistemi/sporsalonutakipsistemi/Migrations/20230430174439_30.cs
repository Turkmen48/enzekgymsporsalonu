using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class _30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceUrl",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstaUrl",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwUrl",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceUrl",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "InstaUrl",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "TwUrl",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "SiteInfos");
        }
    }
}
