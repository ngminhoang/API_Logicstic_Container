using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.DTOModels;

namespace Services_Do_An.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin,AdminModel>();
            CreateMap<AppRate,AppRateModel>();
            CreateMap<Bussiness,BussinessModel>();
            CreateMap<Counting, CountingModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<DriverRate, DriverRateModel>();
            CreateMap<Driver, DriverModel>();
            CreateMap<Invoice, InvoiceModel>();
            CreateMap<Message, MessageModel>();
            CreateMap<OrderItem, OrderItemModel>();
            CreateMap<Order, OrderModel>();
            CreateMap<Order, OrderModel2>();
            CreateMap<OrderStatus, OrderStatusModel>();
            CreateMap<OwnedVehicleInfor, OwnedVehicleInforModel>();
            CreateMap<Position, PositionModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<Staff, StaffModel>();
            CreateMap<Status, StatusModel>();
            CreateMap<Vehicle, VehicleModel>();
            CreateMap<Warehouse, WarehouseModel>();
            CreateMap<WishedAcceptedDriverList, WishedAcceptedDriverListModel>();

            CreateMap<AdminModel, Admin>();
            CreateMap<AppRateModel, AppRate>();
            CreateMap<BussinessModel, Bussiness>();
            CreateMap<CountingModel, Counting>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<DriverRateModel, DriverRate>();
            CreateMap<DriverModel, Driver>();
            CreateMap<InvoiceModel, Invoice>();
            CreateMap<MessageModel, Message>();
            CreateMap<OrderItemModel, OrderItem>();
            CreateMap<OrderModel, Order>();
            CreateMap<OrderModel2, Order>();
            CreateMap<OrderStatusModel, OrderStatus>();
            CreateMap<OwnedVehicleInforModel, OwnedVehicleInfor>();
            CreateMap<PositionModel, Position>();
            CreateMap<RoleModel, Role>();
            CreateMap<StaffModel, Staff>();
            CreateMap<StatusModel, Status>();
            CreateMap<VehicleModel, Vehicle>();
            CreateMap<WarehouseModel, Warehouse>();
            CreateMap<WishedAcceptedDriverListModel, WishedAcceptedDriverList>();


            CreateMap<ContactionModel, Contaction>();
            CreateMap<Contaction, ContactionModel>();
        }
    }
}
