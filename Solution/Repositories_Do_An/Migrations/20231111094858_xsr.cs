using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class xsr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Message",
                newName: "Question");

            migrationBuilder.AddColumn<bool>(
                name: "able",
                table: "Staff",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Message",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "able",
                table: "Driver",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "able",
                table: "Customer",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Contaction",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "able",
                table: "Admin",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "able",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "able",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "able",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Contaction");

            migrationBuilder.DropColumn(
                name: "able",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Message",
                newName: "Content");
        }
    }
}
