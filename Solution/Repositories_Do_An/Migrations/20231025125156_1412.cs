using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _1412 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Staff_StaffId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_StaffId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Contract");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessWebsite",
                table: "Bussiness",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Contract",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessWebsite",
                table: "Bussiness",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_StaffId",
                table: "Contract",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Staff_StaffId",
                table: "Contract",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
