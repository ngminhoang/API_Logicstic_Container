using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OwnedVehicleInfor_ownedVehicleInforOVIId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ownedVehicleInforOVIId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ownedVehicleInforOVIId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ownedVehicleInforOVIId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ownedVehicleInforOVIId",
                table: "Order",
                column: "ownedVehicleInforOVIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OwnedVehicleInfor_ownedVehicleInforOVIId",
                table: "Order",
                column: "ownedVehicleInforOVIId",
                principalTable: "OwnedVehicleInfor",
                principalColumn: "OVIId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
