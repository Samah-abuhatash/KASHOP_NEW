using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KASHOP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class auditupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Catgores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Catgores_CreatedBy",
                table: "Catgores",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Catgores_Users_CreatedBy",
                table: "Catgores",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catgores_Users_CreatedBy",
                table: "Catgores");

            migrationBuilder.DropIndex(
                name: "IX_Catgores_CreatedBy",
                table: "Catgores");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Catgores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
