using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
	/// <inheritdoc />
	public partial class mig6 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsActive",
				table: "Users",
				type: "bit",
				nullable: false,
				defaultValue: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "Birthday",
				table: "UserInfos",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "PlanEndDate",
				table: "UserInfos",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "PlanStartDate",
				table: "UserInfos",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<int>(
				name: "PriceId",
				table: "UserInfos",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<DateTime>(
				name: "RegistrationDate",
				table: "UserInfos",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.CreateIndex(
				name: "IX_UserInfos_PriceId",
				table: "UserInfos",
				column: "PriceId");

			migrationBuilder.AddForeignKey(
				name: "FK_UserInfos_Prices_PriceId",
				table: "UserInfos",
				column: "PriceId",
				principalTable: "Prices",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_UserInfos_Prices_PriceId",
				table: "UserInfos");

			migrationBuilder.DropIndex(
				name: "IX_UserInfos_PriceId",
				table: "UserInfos");

			migrationBuilder.DropColumn(
				name: "IsActive",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "Birthday",
				table: "UserInfos");

			migrationBuilder.DropColumn(
				name: "PlanEndDate",
				table: "UserInfos");

			migrationBuilder.DropColumn(
				name: "PlanStartDate",
				table: "UserInfos");

			migrationBuilder.DropColumn(
				name: "PriceId",
				table: "UserInfos");

			migrationBuilder.DropColumn(
				name: "RegistrationDate",
				table: "UserInfos");
		}
	}
}
