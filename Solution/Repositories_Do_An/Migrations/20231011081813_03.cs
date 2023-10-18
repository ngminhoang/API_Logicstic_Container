using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_OwnerId",
                table: "Order",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OwnerId",
                table: "Order");
        }
    }
}
