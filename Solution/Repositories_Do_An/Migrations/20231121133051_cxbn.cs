using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class cxbn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "Order",
                newName: "WardGo");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Order",
                newName: "WardCome");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Order",
                newName: "ProvinceGo");

            migrationBuilder.RenameColumn(
                name: "DetailPosition",
                table: "Order",
                newName: "ProvinceCome");

            migrationBuilder.AddColumn<string>(
                name: "DetailPositionCome",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailPositionGo",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCome",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictGo",
                table: "Order",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailPositionCome",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DetailPositionGo",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DistrictCome",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DistrictGo",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "WardGo",
                table: "Order",
                newName: "Ward");

            migrationBuilder.RenameColumn(
                name: "WardCome",
                table: "Order",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "ProvinceGo",
                table: "Order",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "ProvinceCome",
                table: "Order",
                newName: "DetailPosition");
        }
    }
}
