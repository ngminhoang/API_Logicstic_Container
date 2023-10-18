using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _1233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Staff",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Driver",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Customer",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Admin",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Staff",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Driver",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customer",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Admin",
                newName: "Nickname");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Driver",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Driver",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Admin",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Admin",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
