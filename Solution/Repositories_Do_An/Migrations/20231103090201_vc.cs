using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class vc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_PostionComeId",
                table: "Order",
                column: "PostionComeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PostionGoId",
                table: "Order",
                column: "PostionGoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_PostionComeId",
                table: "Order",
                column: "PostionComeId",
                principalTable: "Position",
                principalColumn: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_PostionGoId",
                table: "Order",
                column: "PostionGoId",
                principalTable: "Position",
                principalColumn: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_PostionComeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_PostionGoId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PostionComeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PostionGoId",
                table: "Order");
        }
    }
}
