using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class xcv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contactions",
                table: "Contactions");

            migrationBuilder.RenameTable(
                name: "Contactions",
                newName: "Contaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contaction",
                table: "Contaction",
                column: "ContactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contaction",
                table: "Contaction");

            migrationBuilder.RenameTable(
                name: "Contaction",
                newName: "Contactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contactions",
                table: "Contactions",
                column: "ContactionId");
        }
    }
}
