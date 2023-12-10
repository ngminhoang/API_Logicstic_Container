using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.IServices
{
    public interface ICustomerService : IServices<CustomerModel>
    {
        bool update(int customerId, CustomerModel entity);
        int checkAccount(string mail, string password, int roleId);
        bool check(string mail);
        int initOrder(OrderModel2 orderModel);
        bool acceptedOrder(int driverId, int orderId);
        bool contractedByCustomerOrder(int orderId);
        bool deleteAcceptedOrder(int orderId);
        bool deleteContractedByCustomerOrder(int orderId);
        bool takenOrder(int orderId);
        bool unTakenOrder(int orderId);
        bool addOrderItem(OrderItemModel item);
        bool onListOrder(int orderId);
        bool rateDriver(DriverRateModel rate);
        //List<WishedAcceptedDriverListModel> getWishedAcceptedDrivers(int orderId);
        List<WishedAcceptedDriverList> getWishedAcceptedDrivers(int orderId);
        List<OrderModel> getAllInitializedOrders(int customerId);
        List<OrderModel> getAllWaitedDeliveredOrders(int customerId);
        List<OnWorkedOrdersModel> getAllOnWorkedOrders(int customerId);
        List<OnWorkedOrdersModel> getAllHistory(int customerId);
        List<MessageModel> getMessageList(int customerId);
        bool createMessage(MessageModel mess);
        bool updateMessage(int messId);
        /*bool contractedByDriverOrder(int driverId);
        bool deliveringOrder(int driverId);
        bool deliveredOrder(int driverId);
        bool alteringOrder(int orderId);
        bool accidentlOrder(int orderId);
        bool alteredOrder(int orderId);*/
    }
}

