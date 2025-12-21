using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KASHOP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAT",
                table: "Catgores",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Catgores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Catgores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Catgores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Catgores");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Catgores");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Catgores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAT",
                table: "Catgores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
