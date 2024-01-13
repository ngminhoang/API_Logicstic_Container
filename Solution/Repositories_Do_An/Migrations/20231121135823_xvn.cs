using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class xvn : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_OVIId",
                table: "Order",
                column: "OVIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OwnedVehicleInfor_OVIId",
                table: "Order",
                column: "OVIId",
                principalTable: "OwnedVehicleInfor",
                principalColumn: "OVIId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OwnedVehicleInfor_OVIId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OVIId",
                table: "Order");

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
