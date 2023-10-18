using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRate_Driver_DriverId",
                table: "AppRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_AppRate_DriverId",
                table: "AppRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractType",
                table: "ContractType");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "AppRate");

            migrationBuilder.RenameTable(
                name: "ContractType",
                newName: "ContractTypes");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Staff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Driver",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Customer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Values",
                table: "Counting",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Admin",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractTypes",
                table: "ContractTypes",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_RoleId",
                table: "Driver",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RoleId",
                table: "Customer",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_RoleId",
                table: "Admin",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Role_RoleId",
                table: "Admin",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_ContractTypes_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Role_RoleId",
                table: "Customer",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Role_RoleId",
                table: "Driver",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Role_RoleId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_ContractTypes_ContractTypeId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Role_RoleId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Role_RoleId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_RoleId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Driver_RoleId",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Customer_RoleId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Admin_RoleId",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractTypes",
                table: "ContractTypes");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Counting");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "ContractTypes",
                newName: "ContractType");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "AppRate",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractType",
                table: "ContractType",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRate_DriverId",
                table: "AppRate",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRate_Driver_DriverId",
                table: "AppRate",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
