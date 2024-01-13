using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class vcvc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OwnedVehicleInfor_OVIId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_PostionComeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Position_PostionGoId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "NotifType");

            migrationBuilder.DropIndex(
                name: "IX_Order_OVIId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PostionComeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PostionGoId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PostionComeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PostionGoId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "DetailPosition",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderName",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ownedVehicleInforOVIId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CheckRead",
                table: "Message",
                type: "boolean",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OwnedVehicleInfor_ownedVehicleInforOVIId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ownedVehicleInforOVIId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DetailPosition",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "orderName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ownedVehicleInforOVIId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CheckRead",
                table: "Message");

            migrationBuilder.AddColumn<int>(
                name: "PostionComeId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostionGoId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    Text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NotifType",
                columns: table => new
                {
                    NotifTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotifDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    NotifName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifType", x => x.NotifTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractTypeId = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    ContractFileLink = table.Column<string>(type: "text", nullable: true),
                    DeliveryId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractType",
                        principalColumn: "ContractTypeId");
                    table.ForeignKey(
                        name: "FK_Contract_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Contract_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_Contract_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotifTypeId = table.Column<int>(type: "integer", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_NotifType_NotifTypeId",
                        column: x => x.NotifTypeId,
                        principalTable: "NotifType",
                        principalColumn: "NotifTypeId");
                    table.ForeignKey(
                        name: "FK_Notification_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OVIId",
                table: "Order",
                column: "OVIId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PostionComeId",
                table: "Order",
                column: "PostionComeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PostionGoId",
                table: "Order",
                column: "PostionGoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CustomerId",
                table: "Contract",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OrderId",
                table: "Contract",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RoleId",
                table: "Contract",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotifTypeId",
                table: "Notification",
                column: "NotifTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RoleId",
                table: "Notification",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OwnedVehicleInfor_OVIId",
                table: "Order",
                column: "OVIId",
                principalTable: "OwnedVehicleInfor",
                principalColumn: "OVIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_PostionComeId",
                table: "Order",
                column: "PostionComeId",
                principalTable: "Position",
                principalColumn: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Position_PostionGoId",
                table: "Order",
                column: "PostionGoId",
                principalTable: "Position",
                principalColumn: "PositionId");
        }
    }
}
