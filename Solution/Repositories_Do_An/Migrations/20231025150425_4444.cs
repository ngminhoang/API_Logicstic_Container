using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _4444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Driver_DriverId",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Contract",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_DriverId",
                table: "Contract",
                newName: "IX_Contract_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Contract",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Role_RoleId",
                table: "Contract",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Role_RoleId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Contract",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_RoleId",
                table: "Contract",
                newName: "IX_Contract_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Driver_DriverId",
                table: "Contract",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
