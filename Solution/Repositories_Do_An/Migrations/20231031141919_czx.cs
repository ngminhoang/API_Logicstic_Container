using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Do_An.Migrations
{
    public partial class czx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRate_Role_RoleId",
                table: "AppRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Bussiness_Role_RoleId",
                table: "Bussiness");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRate_Order_OrderId",
                table: "DriverRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Role_RoleId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Staff_StaffId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_NotifType_NotifTypeId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Role_RoleId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Bussiness_BussinessId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_Warehouse_WarehouseId",
                table: "OrderStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedVehicleInfor_Driver_DriverId",
                table: "OwnedVehicleInfor");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Bussiness_BussinessId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WishedAcceptedDriverList_Order_OrderId",
                table: "WishedAcceptedDriverList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishedAcceptedDriverList_OwnedVehicleInfor_OVIId",
                table: "WishedAcceptedDriverList");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "WishedAcceptedDriverList",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OVIId",
                table: "WishedAcceptedDriverList",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BussinessId",
                table: "Warehouse",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "OwnedVehicleInfor",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "OrderStatus",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BussinessId",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Notification",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "NotifTypeId",
                table: "Notification",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Message",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Message",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Invoice",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DriverRate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ContractTypeId",
                table: "Contract",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Bussiness",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AppRate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRate_Role_RoleId",
                table: "AppRate",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bussiness_Role_RoleId",
                table: "Bussiness",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRate_Order_OrderId",
                table: "DriverRate",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Role_RoleId",
                table: "Message",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Staff_StaffId",
                table: "Message",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_NotifType_NotifTypeId",
                table: "Notification",
                column: "NotifTypeId",
                principalTable: "NotifType",
                principalColumn: "NotifTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Role_RoleId",
                table: "Notification",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Bussiness_BussinessId",
                table: "Order",
                column: "BussinessId",
                principalTable: "Bussiness",
                principalColumn: "BussinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_Warehouse_WarehouseId",
                table: "OrderStatus",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedVehicleInfor_Driver_DriverId",
                table: "OwnedVehicleInfor",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Bussiness_BussinessId",
                table: "Warehouse",
                column: "BussinessId",
                principalTable: "Bussiness",
                principalColumn: "BussinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishedAcceptedDriverList_Order_OrderId",
                table: "WishedAcceptedDriverList",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishedAcceptedDriverList_OwnedVehicleInfor_OVIId",
                table: "WishedAcceptedDriverList",
                column: "OVIId",
                principalTable: "OwnedVehicleInfor",
                principalColumn: "OVIId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRate_Role_RoleId",
                table: "AppRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Bussiness_Role_RoleId",
                table: "Bussiness");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRate_Order_OrderId",
                table: "DriverRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Role_RoleId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Staff_StaffId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_NotifType_NotifTypeId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Role_RoleId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Bussiness_BussinessId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_Warehouse_WarehouseId",
                table: "OrderStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedVehicleInfor_Driver_DriverId",
                table: "OwnedVehicleInfor");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Bussiness_BussinessId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WishedAcceptedDriverList_Order_OrderId",
                table: "WishedAcceptedDriverList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishedAcceptedDriverList_OwnedVehicleInfor_OVIId",
                table: "WishedAcceptedDriverList");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "WishedAcceptedDriverList",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OVIId",
                table: "WishedAcceptedDriverList",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BussinessId",
                table: "Warehouse",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "OwnedVehicleInfor",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "OrderStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BussinessId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Notification",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotifTypeId",
                table: "Notification",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Message",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Message",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Invoice",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DriverRate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractTypeId",
                table: "Contract",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Bussiness",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AppRate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRate_Role_RoleId",
                table: "AppRate",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bussiness_Role_RoleId",
                table: "Bussiness",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_ContractType_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRate_Order_OrderId",
                table: "DriverRate",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Role_RoleId",
                table: "Message",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Staff_StaffId",
                table: "Message",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_NotifType_NotifTypeId",
                table: "Notification",
                column: "NotifTypeId",
                principalTable: "NotifType",
                principalColumn: "NotifTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Role_RoleId",
                table: "Notification",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Bussiness_BussinessId",
                table: "Order",
                column: "BussinessId",
                principalTable: "Bussiness",
                principalColumn: "BussinessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_Warehouse_WarehouseId",
                table: "OrderStatus",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedVehicleInfor_Driver_DriverId",
                table: "OwnedVehicleInfor",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Bussiness_BussinessId",
                table: "Warehouse",
                column: "BussinessId",
                principalTable: "Bussiness",
                principalColumn: "BussinessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishedAcceptedDriverList_Order_OrderId",
                table: "WishedAcceptedDriverList",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishedAcceptedDriverList_OwnedVehicleInfor_OVIId",
                table: "WishedAcceptedDriverList",
                column: "OVIId",
                principalTable: "OwnedVehicleInfor",
                principalColumn: "OVIId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
