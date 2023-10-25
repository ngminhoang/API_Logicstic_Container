using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Staff_StaffId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StaffId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "weightPerUnit",
                table: "OrderItem",
                newName: "WeightPerUnit");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "WeightPerUnit",
                table: "OrderItem",
                newName: "weightPerUnit");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentMethod",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StaffId",
                table: "Order",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Owner_OwnerId",
                table: "Order",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Staff_StaffId",
                table: "Order",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId");
        }
    }
}
