using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NodaTime;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Others;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.APIFunctions;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services_Do_An.DTOModels;
using XAct;

namespace Services_Do_An.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerDB;
        private readonly IDriverRepository driverDB;
        private readonly IOrderRepository orderDB;
        private readonly IOrderItemRepository orderItemDB;
        private readonly IOrderStatusRepository orderStatusDB;
        private readonly IWishedAcceptedDriverListRepository wishedAcceptedDriverListDB;
        private readonly IOwnedVehicleInforRepository ownedVehicleInforRepositoryDB;
        private readonly IDriverRateRepository driverRateDB;
        public CustomerService(IDriverRepository driverDB, IDriverRateRepository driverRateDB, IOwnedVehicleInforRepository ownedVehicleInforRepositoryDB, IWishedAcceptedDriverListRepository wishedAcceptedDriverListDB, IOrderItemRepository _orderItem, IOrderRepository _order, IMapper _mapper, ICustomerRepository _customer, IOrderStatusRepository _orderStatus)
        {
            this.mapper = _mapper;
            this.customerDB = _customer;
            this.driverDB = driverDB;
            this.orderDB = _order;
            this.orderItemDB = _orderItem;
            this.orderStatusDB = _orderStatus;
            this.wishedAcceptedDriverListDB = wishedAcceptedDriverListDB;
            this.ownedVehicleInforRepositoryDB = ownedVehicleInforRepositoryDB;
            this.driverRateDB = driverRateDB;
        }


        public bool addOrderItem(OrderItemModel item)
        {
            try
            {
                OrderItem orderItem = mapper.Map<OrderItem>(item);
                if (orderStatusDB.checkInitOrder(item.OrderId) == true && orderStatusDB.checkOnListOrder(item.OrderId) == false)
                {
                    return orderItemDB.create(orderItem);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool check(string mail)
        {
            try
            {
                return (customerDB.check(mail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerModel read(int id)
        {
            try
            {
                Customer customer = customerDB.read(id);
                CustomerModel customerModel = mapper.Map<CustomerModel>(customer);
                return customerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerModel read(string name)
        {
            try
            {
                Customer customer = customerDB.read(name);
                CustomerModel customerModel = mapper.Map<CustomerModel>(customer);
                return customerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool create(CustomerModel entity)
        {
            try
            {
                Customer customer = mapper.Map<Customer>(entity);
                string pass_md5 = MD5Functions.GenerateMD5(customer.Password);
                customer.Password = pass_md5;
                customer.RoleId = 4;
                bool test = check(customer.Email);
                if (test == false)
                {
                    customerDB.create(customer);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update( CustomerModel entity)
        {
            return true;
        }
        public bool update(int customerId, CustomerModel entity)
        {
            try
            {
                CustomerModel customer = entity;
                customer.DateUpdatedAccount = DateTime.UtcNow;
                customer.UserId = customerId;
                string pass_md5 = MD5Functions.GenerateMD5(customer.Password);
                customer.Password = pass_md5;
                Customer e = mapper.Map<Customer>(customer);
                return customerDB.update(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool delete(CustomerModel entity)
        {
            return true;
        }
    
        public int checkAccount(string mail, string password, int roleId)
        {
            try
            {
                var check = customerDB.read(mail, password, roleId);
                if (check != null)
                {
                    return check.UserId;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    

        public int initOrder(OrderModel2 orderModel)
        {
            try
            {
                Order order = mapper.Map<Order>(orderModel);
                //Console.WriteLine(order.OVIId);
                //Console.WriteLine(order.BussinessId);
                //Order e = order;
                //e.OVIId = null;
                //e.BussinessId = null;

                try
                {
                    //orderDB.create(order);
                    var data = orderDB.create_2(order);
                    int orderId = data.Entity.OrderId;
                    orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date = DateTime.UtcNow, StatusId = 1, Status = true });
                    return orderId;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool onListOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkInitOrder(orderId) == true && orderStatusDB.checkBeforeStatus(orderId) == 1 && orderStatusDB.checkAcceptedOrder(orderId)==false)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 19, Status = true });
                        List<OrderItem> list = orderItemDB.getAll(orderId);
                        double totalAmount = 0;
                        double totalWeight = 0;
                        double totalMass = 0;
                        foreach (OrderItem e in list){
                            totalAmount += ((double)e.PricePerUnit * (double)e.Quantity) * 0.01;// + (giá thành quãng đường đi =. phải tính thông quâ địaa dsdieerm đi);
                            totalWeight += (double)e.WeightPerUnit * (double)e.Quantity;
                            totalMass += (double)e.MassPerUnit * (double)e.Quantity;
                        }
                        Order order = orderDB.read(orderId);
                        order.TotalAmount = totalAmount;
                        order.TotalMass = totalMass;
                        order.TotalWeight = totalWeight;
                        orderDB.update(order);//them cap nhat thong tin gia don hang
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WishedAcceptedDriverList> getWishedAcceptedDrivers(int orderId)
        {
            try
            {
                List<WishedAcceptedDriverList> ls = wishedAcceptedDriverListDB.getAll(orderId);
                List < WishedAcceptedDriverListModel> rs = new List<WishedAcceptedDriverListModel>();
                foreach (var each in ls)
                {
                    rs.Add(mapper.Map<WishedAcceptedDriverListModel>(each));
                }
                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderModel> getAllInitializedOrders(int customerId)
        {
            try
            {

                List<OrderModel> rs = new List<OrderModel>();
                List<Order> list = orderDB.getAll(customerId);
                foreach (var order in list)
                {

                    if (orderStatusDB.checkInitOrder(order.OrderId) == true && orderStatusDB.checkAcceptedOrder(order.OrderId) == false && orderStatusDB.checkOnListOrder(order.OrderId) == true)
                    {
                        var order1 = mapper.Map<OrderModel>(order);
                        rs.Add(order1);
                    }
                }

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<OrderModel> getAllWaitedDeliveredOrders(int customerId)
        {
            try
            {

                List<OrderModel> rs = new List<OrderModel>();
                List<Order> list = orderDB.getAll(customerId);
                foreach (var order in list)
                {

                    if (orderStatusDB.checkInitOrder(order.OrderId) == true && orderStatusDB.checkAcceptedOrder(order.OrderId) == true && orderStatusDB.checkContractedByDriverOrder(order.OrderId) == false)
                    {
                        var order1 = mapper.Map<OrderModel>(order);
                        rs.Add(order1);
                    }
                }

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<OnWorkedOrdersModel> getAllOnWorkedOrders(int customerId)
        {
            try
            {

                List<OnWorkedOrdersModel> rs = new List<OnWorkedOrdersModel>();
                List<Order> list = orderDB.getAll(customerId);
                foreach (var order in list)
                {

                    if (orderStatusDB.checkInitOrder(order.OrderId) == true && orderStatusDB.checkContractedByDriverOrder(order.OrderId) == true && orderStatusDB.checkEndOrder(order.OrderId) == false)
                    {
                        var order1 = mapper.Map<OrderModel>(order);
                        var check = orderStatusDB.getRecentStatus(order.OrderId);
                        string status = check.StatusType.StatusName;
                        var statusId = check.StatusId;
                        rs.Add(new OnWorkedOrdersModel() { order = order1, status = status, statusId = (int)statusId });
                    }
                }

                    return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<OnWorkedOrdersModel> getAllHistory(int customerId)
        {
            try
            {
                List<OnWorkedOrdersModel> rs = new List<OnWorkedOrdersModel>();
                List<Order> list = orderDB.getAll(customerId);
                foreach (var order in list)
                {

                    if (orderStatusDB.checkInitOrder(order.OrderId) == true && orderStatusDB.checkContractedByDriverOrder(order.OrderId) == true && orderStatusDB.checkEndOrder(order.OrderId) == true)
                    {
                        var order1 = mapper.Map<OrderModel>(order);
                        var check = orderStatusDB.getRecentStatus(order.OrderId);
                        string status = check.StatusType.StatusName;
                        var statusId = check.StatusId;
                        rs.Add(new OnWorkedOrdersModel() { order = order1, status = status, statusId = (int)statusId });
                    }
                }

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool acceptedOrder(int orderId, int oVIId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                order.OVIId = oVIId;
                try
                {
                    if (orderStatusDB.checkAcceptedOrder(orderId) == false && orderStatusDB.checkOnListOrder(orderId)==true /*&& oVIId co trong danh sach*/ )
                    {
                        orderDB.update(order);
                        wishedAcceptedDriverListDB.choosenDriver(oVIId, orderId);
                        orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date = DateTime.UtcNow, StatusId = 2, Status = true });
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public bool contractedByCustomerOrder(int orderId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                try
                {
                    if (orderStatusDB.checkAcceptedOrder(orderId) == true && orderStatusDB.checkContractedByCustomerOrder(orderId) == false)
                    {
                        orderDB.update(order);
                        orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date = DateTime.UtcNow, StatusId = 4, Status = true });
                        if (orderStatusDB.checkContractedByDriverOrder(orderId) == true)
                        {
                            ///LenhUpDate
                            orderDB.update(order);
                            int cusId = (int)order.CustomerId;
                            int driverId= (int)ownedVehicleInforRepositoryDB.read((int)order.OVIId).DriverId;
                            try
                            {
                                //taocontract
                            }
                            catch 
                            { 
                                return false; 
                            }

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool deleteAcceptedOrder(int orderId)
        {
            try
            {

                try
                {
                    if (orderStatusDB.checkAcceptedOrder(orderId) == true &&
                        orderStatusDB.checkOnListOrder(orderId) == true)
                    {
                        orderStatusDB.delete(2,orderId);
                        var order = orderDB.read(orderId);
                        order.OVIId = null;
                        orderDB.update(order);
                        wishedAcceptedDriverListDB.deleteAll(orderId);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool deleteContractedByCustomerOrder(int orderId)
        {
            try
            {
                try
                {;
                    if (orderStatusDB.checkAcceptedOrder(orderId) == true &&
                        orderStatusDB.checkContractedByCustomerOrder(orderId) == true)
                    {
                        orderStatusDB.delete(4, orderId);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool takenOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkDeliveredOrder(orderId) == true && orderStatusDB.checkTakenOrder(orderId) == false && (orderStatusDB.checkBeforeStatus(orderId) == 11 || orderStatusDB.checkBeforeStatus(orderId) == 15))
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 7, Status = true });
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 12, Status = true });
                        Driver driver = orderDB.read(orderId).ownedVehicleInfor.driver;
                        driver.IsWorked = false;
                        driverDB.update(driver);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool unTakenOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkDeliveredOrder(orderId) == true &&( orderStatusDB.checkTakenOrder(orderId) == false )&& orderStatusDB.checkBeforeStatus(orderId) == 6)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 8, Status = true });
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        


        public bool rateDriver(DriverRateModel rateModel)
        {
            try
            {
                DriverRate rate = mapper.Map<DriverRate>(rateModel);
                try
                {
                    if (orderStatusDB.checkRateDriver((int)rate.OrderId)==false && orderStatusDB.checkBeforeStatus((int)rate.OrderId)==12 && rate.DriverId == ownedVehicleInforRepositoryDB.read((int)orderDB.read((int)rate.OrderId).OVIId).DriverId)
                    {
                        rate.CommentDate = DateTime.UtcNow;
                        driverRateDB.create(rate);
                        orderStatusDB.create(new OrderStatus { OrderId = rate.OrderId, Date = DateTime.UtcNow, StatusId = 129, Status = true });
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       





        /*
        public bool contractedByDriverOrder(int orderId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                try
                {
                    if (orderStatusDB.checkAcceptedOrder(orderId) == true && orderStatusDB.checkContractedByDriverOrder(orderId) == false)
                    {
                        orderDB.update(order);
                        orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date = DateTime.UtcNow, StatusId = 3, Status = true });
                        if (orderStatusDB.checkContractedByCustomerOrder(orderId) == true)
                        {
                            ///LenhUpDate
                            orderDB.update(order);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deliveringOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkContractedByDriverOrder(orderId) == true && orderStatusDB.checkContractedByCustomerOrder(orderId) == true && ((orderStatusDB.checkDeliveringOrder(orderId) == false || orderStatusDB.checkBeforeStatus(orderId) == 9) || orderStatusDB.checkBeforeStatus(orderId) == 13))
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 5, Status = true });
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deliveredOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkEndOrder(orderId) == false && orderStatusDB.checkDeliveringOrder(orderId) == true && (orderStatusDB.checkDeliveredOrder(orderId) == false || orderStatusDB.checkBeforeStatus(orderId) == 5))
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 6, Status = true });
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool alteringOrder(int orderId)
        {
            try
            {
                try
                {
                    if ((orderStatusDB.checkBeforeStatus(orderId) == 6 || orderStatusDB.checkBeforeStatus(orderId) == 8) && (orderStatusDB.checkUnTakenOrder(orderId) == true || orderStatusDB.checkTakenOrder(orderId) == false))//&& orderStatusDB.checkAlteringOrder(orderId) == false)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 9, Status = true });
                        //cap nhat lai gia tien
                        //tao mot order khac
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool alteredOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkBeforeStatus(orderId) == 9 && orderStatusDB.checkTakenOrder(orderId) == false)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 14, Status = true });
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 10, Status = true });
                        //cap nhat lai gia tien
                        //tao mot order khac
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool accidentlOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkTakenOrder(orderId) == false && orderStatusDB.checkBeforeStatus(orderId) == 5)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 13, Status = true });
                        //cap nhat lai trang thai, gia tien,....
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/


    }
}
