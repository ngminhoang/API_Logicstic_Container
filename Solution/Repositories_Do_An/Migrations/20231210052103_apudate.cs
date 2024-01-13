using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class apudate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckRead",
                table: "Contaction",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactionId1",
                table: "Contaction",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Contaction",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Contaction",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contaction_ContactionId1",
                table: "Contaction",
                column: "ContactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contaction_Contaction_ContactionId1",
                table: "Contaction",
                column: "ContactionId1",
                principalTable: "Contaction",
                principalColumn: "ContactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contaction_Contaction_ContactionId1",
                table: "Contaction");

            migrationBuilder.DropIndex(
                name: "IX_Contaction_ContactionId1",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "CheckRead",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "ContactionId1",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contaction");
        }
    }
}
