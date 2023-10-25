using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class fdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "positionComePositionId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "positionGoPositionId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_positionComePositionId",
                table: "Order",
                column: "positionComePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_positionGoPositionId",
                table: "Order",
                column: "positionGoPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_positionComePositionId",
                table: "Order",
                column: "positionComePositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_positionGoPositionId",
                table: "Order",
                column: "positionGoPositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_positionComePositionId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_positionGoPositionId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_positionComePositionId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_positionGoPositionId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "positionComePositionId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "positionGoPositionId",
                table: "Order");
        }
    }
}
