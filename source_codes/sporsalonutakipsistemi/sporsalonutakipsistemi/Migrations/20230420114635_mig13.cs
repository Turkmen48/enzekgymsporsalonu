using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "Nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(30)",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "Nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
