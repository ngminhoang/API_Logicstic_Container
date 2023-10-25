using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _346 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Staff_staffUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StaffIdId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "staffUserId",
                table: "Order",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_staffUserId",
                table: "Order",
                newName: "IX_Order_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Staff_StaffId",
                table: "Order",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Staff_StaffId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Order",
                newName: "staffUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StaffId",
                table: "Order",
                newName: "IX_Order_staffUserId");

            migrationBuilder.AddColumn<int>(
                name: "StaffIdId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Staff_staffUserId",
                table: "Order",
                column: "staffUserId",
                principalTable: "Staff",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
