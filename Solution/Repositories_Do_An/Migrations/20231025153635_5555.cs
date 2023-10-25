using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class _5555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Order",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(BigInteger),
                oldType: "numeric",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<BigInteger>(
                name: "TotalAmount",
                table: "Order",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
