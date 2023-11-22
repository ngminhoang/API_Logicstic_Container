using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.IServices
{
    public interface IDriverService : IServices<DriverModel>
    {
        int checkAccount(string mail, string password, int roleId);
        bool check(string mail);
        List<OrderModel> getAllInitializedOrders();
        Object getOrder(int orderId);
        bool contractedByDriverOrder(int driverId);
        bool deliveringOrder(int driverId);
        bool deliveredOrder(int driverId);
        bool alteringOrder(int orderId);
        bool accidentlOrder(int orderId);
        bool alteredOrder(int orderId);
        bool applyOrder(int OVIId, int orderId);
        List<OwnedVehicleInforModel> getDriverOwnedVehicle(int driverId);
        List<OrderModel> getAllInitializedOrders(int OVIId, string DisGo, string ProGo, string DisCome, string ProCome);
        Object readDriver(int id);
        bool createVehicle(OwnedVehicleInforModel entity);
        bool updateVehicle(OwnedVehicleInforModel entity);
        bool deleteVehicle(int id);
        List<OrderItemModel> getItemList(int orderId);
        Object getStatusList(int orderId);
        CustomerModel getCustomer(int customerId);
        List<MessageModel> getMessageList(int driverId);
        bool updateMessage(int messId, MessageModel mess);
        bool update(int driverId, DriverModel driver);

    }
}
