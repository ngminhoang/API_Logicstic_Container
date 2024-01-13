﻿using AutoMapper;
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
        Object getOrder(int oVIId, int orderId);
        bool payedOrder(int orderId);
        bool contractedByDriverOrder(int driverId);
        bool deliveringOrder(int driverId);
        bool deliveredOrder(int driverId);
        bool alteringOrder(int orderId);
        bool accidentlOrder(int orderId);
        bool alteredOrder(int orderId);
        bool applyOrder(int OVIId, int orderId);
        bool deleteApplyOrder(int OVIId, int orderId);
        List<OwnedVehicleInforModel> getDriverOwnedVehicle(int driverId);
        bool checkWAL(int oVIId,int orderId);
        List<OrderModel> getAllInitializedOrders(int OVIId, string DisGo, string ProGo, string DisCome, string ProCome);
        Object readDriver(int id);
        bool createVehicle(OwnedVehicleInforModel entity);
        bool updateVehicle(int oVIId, OwnedVehicleInforModel entity);
        bool deleteVehicle(int id);
        List<OrderItemModel> getItemList(int orderId);
        Object getStatusList(int orderId);
        CustomerModel getCustomer(int customerId);
        List<MessageModel> getMessageList(int driverId);
        bool createMessage(MessageModel mess);
        bool updateMessage(int messId);
        bool update(int driverId, DriverModel driver);
        bool changeToNotWorked(int driverId);
        bool changeToWorked(int driverId);
        List<AppliedOrderModel> getAllAppliedOrders(int driverId);
        bool deleteAcceptedOrder(int orderId);
        bool deleteContractedByCustomerOrder(int orderId);
        List<Order> x();
        OnWorkedOrderModel getOnWorkedOrder(int driverId);
    }
}
