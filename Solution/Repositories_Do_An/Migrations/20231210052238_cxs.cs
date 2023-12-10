using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class cxs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contaction_Contaction_ContactionId1",
                table: "Contaction");

            migrationBuilder.DropIndex(
                name: "IX_Contaction_ContactionId1",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "ContactionId1",
                table: "Contaction");

            migrationBuilder.CreateIndex(
                name: "IX_Contaction_StaffId",
                table: "Contaction",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contaction_Staff_StaffId",
                table: "Contaction",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contaction_Staff_StaffId",
                table: "Contaction");

            migrationBuilder.DropIndex(
                name: "IX_Contaction_StaffId",
                table: "Contaction");

            migrationBuilder.AddColumn<int>(
                name: "ContactionId1",
                table: "Contaction",
                type: "integer",
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
    }
}
