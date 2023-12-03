using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Others;
using Repositories_Do_An.IRepositories.Users;
using Repositories_Do_An.Repositories;
using Services_Do_An.APIFunctions;
using Services_Do_An.DTOModels;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Services_Do_An.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper mapper;
        private readonly IDriverRepository driverDB;
        private readonly IOrderRepository orderDB;
        private readonly IOrderStatusRepository orderStatusDB;
        private readonly IOrderItemRepository orderItemDB;
        private readonly IWishedAcceptedDriverListRepository wishedAcceptedDriverListDB;
        private readonly IOwnedVehicleInforRepository ownedVehicleInforRepositoryDB;
        private readonly ICustomerRepository customerDB;
        private readonly IMessageRepository messageDB;
        public DriverService(IMapper mapper, IMessageRepository messageDB, ICustomerRepository customerDB, IOwnedVehicleInforRepository ownedVehicleInforRepositoryDB,  IWishedAcceptedDriverListRepository wishedAcceptedDriverListDB, IDriverRepository driverDB, IOrderRepository orderDB, IOrderStatusRepository orderStatusDB, IOrderItemRepository orderItemDB)
        {
            this.mapper = mapper;
            this.driverDB = driverDB;
            this.orderDB = orderDB;
            this.orderStatusDB = orderStatusDB;
            this.orderItemDB = orderItemDB;
            this.wishedAcceptedDriverListDB = wishedAcceptedDriverListDB;
            this.ownedVehicleInforRepositoryDB = ownedVehicleInforRepositoryDB;
            this.customerDB = customerDB;
            this.messageDB = messageDB;
        }


        public OnWorkedOrderModel getOnWorkedOrder(int driverId)
        {
            var order = new Order(); 
            try
            {
                List<Order> ls = orderDB.getAll(driverId,"driverId");
                foreach (var each in ls)
                {
                    if (orderStatusDB.checkInitOrder(each.OrderId) == true
                        && orderStatusDB.checkContractedByDriverOrder(each.OrderId) == true
                        && orderStatusDB.checkEndOrder(each.OrderId) == false)
                    {
                        order = each;
                        break;
                    }
                }

                if (order == null)
                {
                    return null;}
                else
                {
                    List<OrderStatus> status = orderStatusDB.getAll(order.OrderId);
                    var index = status.Count - 1;
                    int newStatus = (int)status[index].StatusId;
                    return new OnWorkedOrderModel() { order = order, status = status, newStatus = newStatus };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppliedOrderModel> getAllAppliedOrders(int driverId)
        {
            try
            {
                List<AppliedOrderModel> rs = new List<AppliedOrderModel>();
                List<WishedAcceptedDriverList> listWAL = wishedAcceptedDriverListDB.getAll(driverId,"driverId"); 
                foreach (var each in listWAL)
                {
                    bool check;
                    if (each.OVIId == each.order.OVIId)
                        check = true;
                    else
                    {
                        check = false;
                    }
                    if (orderStatusDB.checkContractedByDriverOrder((int)each.OrderId)==false)
                    rs.Add(  new AppliedOrderModel(){order = each.order , oVI = each.ownedVehicleInfor, isChoosen = check });
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeToNotWorked(int driverId)
        {
            try
            {
                Driver driver = driverDB.read(driverId);
                driver.IsWorked = false;
                return driverDB.update(driver);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool changeToWorked(int driverId)
        {
            try
            {
                Driver driver = driverDB.read(driverId);
                driver.IsWorked = true;
                return driverDB.update(driver);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool updateMessage(int messId, MessageModel mess)
        {
            try
            {
                Message mes = mapper.Map<Message>(mess);
                mes.MessId = messId;
                return messageDB.update(mes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<MessageModel> getMessageList(int driverId)
        {
            try
            {
                List<Message> ls = messageDB.getAll(driverId, 3);
                List<MessageModel> rs = new List<MessageModel>();
                foreach (Message mess in ls)
                {
                    rs.Add(mapper.Map<MessageModel>(mess));
                }

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(int driverId, DriverModel entity)
        {
            try
            {
                DriverModel driver = entity;
                driver.DateUpdatedAccount = DateTime.UtcNow;
                driver.UserId= driverId;
                string pass_md5 = MD5Functions.GenerateMD5(driver.Password);
                driver.Password = pass_md5;
                Driver e = mapper.Map<Driver>(driver);
                return driverDB.update(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(DriverModel entity)
        {
            try
            {
                DriverModel driver = entity;
                driver.DateUpdatedAccount = DateTime.Now;
                Driver e = mapper.Map<Driver>(driver);
                return driverDB.update(e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool createVehicle(OwnedVehicleInforModel entity)
        {
            try
            {
                OwnedVehicleInfor e = mapper.Map<OwnedVehicleInfor>(entity);
                return ownedVehicleInforRepositoryDB.create(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateVehicle(int oVIId, OwnedVehicleInforModel entity)
        {
            try
            {
                OwnedVehicleInfor e = mapper.Map<OwnedVehicleInfor>(entity);
                e.OVIId = oVIId;
                return ownedVehicleInforRepositoryDB.update(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteVehicle(int id)
        {
            try
            {

                var e = ownedVehicleInforRepositoryDB.read(id);
                return ownedVehicleInforRepositoryDB.delete(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderItemModel> getItemList(int orderId)
        {
            try
            {
                List<OrderItem> orderItemList = orderItemDB.getAll(orderId);
                List<OrderItemModel> orderItemModelList = new List<OrderItemModel>();
                foreach (OrderItem item in orderItemList)
                {
                    orderItemModelList.Add(mapper.Map<OrderItemModel>(item));
                }
                return orderItemModelList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerModel getCustomer(int customerId)
        {
            try
            {
                Customer customer = customerDB.read(customerId);
                CustomerModel customerModel = mapper.Map<CustomerModel>(customer);
                return customerModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public Object getStatusList(int orderId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                List<OrderStatus> orderStatusList = orderStatusDB.getAll(orderId );
                List<OrderStatusModel> orderStatusModelList = new List<OrderStatusModel>();
                foreach (OrderStatus item in orderStatusList)
                {
                    orderStatusModelList.Add(mapper.Map<OrderStatusModel>(item));
                }
                return new {  order= order,statusList= orderStatusModelList };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool applyOrder(int oVIId, int orderId)
        {
            try
            {
                WishedAcceptedDriverList data = new WishedAcceptedDriverList() { OrderId = orderId, OVIId = oVIId, Status = true };
                if (wishedAcceptedDriverListDB.checkDupplicate(oVIId, orderId) == false && orderStatusDB.checkAcceptedOrder(orderId)==false)
                {
                    return wishedAcceptedDriverListDB.create(data);
                }
                else return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteApplyOrder(int oVIId, int orderId)
        {
            try
            {
                WishedAcceptedDriverList data = wishedAcceptedDriverListDB.read(oVIId,orderId);
                return wishedAcceptedDriverListDB.delete(data);
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
                {
                    ;
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
        public bool deleteAcceptedOrder(int orderId)
        {
            try
            {

                try
                {
                    if (orderStatusDB.checkAcceptedOrder(orderId) == true &&
                        orderStatusDB.checkOnListOrder(orderId) == true)
                    {
                        orderStatusDB.delete(2, orderId);
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
                            int cusId = (int)order.CustomerId;
                            int driverId = (int)ownedVehicleInforRepositoryDB.read((int)order.OVIId).DriverId;
                            List<Order> ls = orderDB.getAll(driverId, "driverId");
                            foreach (var each in ls)
                            {
                                if (orderStatusDB.checkContractedByDriverOrder(each.OrderId) == false)
                                {
                                    
                                    try { each.OVIId = null; orderDB.update(each); } catch { }
                                    try { orderStatusDB.delete(2, each.OrderId); } catch { }
                                    try { orderStatusDB.delete(4, each.OrderId); } catch { }
                                }
                            }


                            try
                            {
                                //them contract
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


        public bool deliveringOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkContractedByDriverOrder(orderId) == true && orderStatusDB.checkContractedByCustomerOrder(orderId) == true && ((orderStatusDB.checkDeliveringOrder(orderId) == false || orderStatusDB.checkBeforeStatus(orderId) == 9) || orderStatusDB.checkBeforeStatus(orderId) == 13 || orderStatusDB.checkBeforeStatus(orderId) == 15 || (orderStatusDB.checkBeforeStatus(orderId) == 14 && orderStatusDB.checkPayedOrder(orderId) == true)))
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
                    if ((orderStatusDB.checkBeforeStatus(orderId) == 6 || orderStatusDB.checkBeforeStatus(orderId) == 8 /*|| orderStatusDB.checkBeforeStatus(orderId) == 14*/) && (orderStatusDB.checkUnTakenOrder(orderId) == true || orderStatusDB.checkTakenOrder(orderId) == false))//&& orderStatusDB.checkAlteringOrder(orderId) == false)
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
                        //orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 10, Status = true });
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 14, Status = true });
                        
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
        }



        public bool payedOrder(int orderId)
        {
            try
            {
                try
                {
                    if (orderStatusDB.checkBeforeStatus(orderId) == 6 && (orderStatusDB.checkTakenOrder(orderId) == false /* || orderStatusDB.checkAlteredOrder(orderId) == true*/))
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 11, Status = true });
                        //orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 12, Status = true });
                        //cap nhat lai gia tien
                        //tao mot order khac
                        return true;
                    }
                    else if (orderStatusDB.checkBeforeStatus(orderId) == 14 && orderStatusDB.checkPayedOrder(orderId) == false)
                    {
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 11, Status = true });
                        // tính toán tìm ra kho của bussiness nào gần nhất địa điểm của khác hàng => trả ra id kho warehouseId => trả ra bussinessId
                        //Order order = orderDB.read(orderId);
                        //order.BussinessId = bussinessId;
                        /* tạo contract với bussiness: *///contractRepositoryDB.createBussinessContract(order.CustomerId, bussinessId, orderId);
                        //orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 15, Status = true, WarehouseId = warehouseId  });
                        //orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 12, Status = true });
                        orderStatusDB.create(new OrderStatus { OrderId = orderId, Date = DateTime.UtcNow, StatusId = 15, Status = true });
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

        public Object getOrder(int orderId) 
        {
            try 
            {
                Order order = orderDB.read(orderId);
                List<OrderItem> orderItemList  = orderItemDB.getAll(orderId);
                List<OrderItemModel> orderItemModelList =new List<OrderItemModel>();
                foreach (OrderItem item in orderItemList)
                {
                    orderItemModelList.Add(mapper.Map<OrderItemModel>(item));
                }
                return new { order = order, orderItem = orderItemModelList };
                
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public Object getOrder(int oVIId, int orderId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                List<OrderItem> orderItemList = orderItemDB.getAll(orderId);
                List<OrderItemModel> orderItemModelList = new List<OrderItemModel>();
                foreach (OrderItem item in orderItemList)
                {
                    orderItemModelList.Add(mapper.Map<OrderItemModel>(item));
                }
                return new { order = order, orderItem = orderItemModelList, checkWAL = wishedAcceptedDriverListDB.checkDupplicate(oVIId,orderId) };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderModel> getAllInitializedOrders()
        {
            try 
            {
                List<OrderModel> rs = new List<OrderModel>();
                List<Order> list = orderDB.getAll();
                OrderModel order1;
                //foreach (var order in list)
                //{
                //    rs.Add(mapper.Map<OrderModel>(order));
                //}
                foreach (var order in list)
                {
                    if (orderStatusDB.checkInitOrder(order.OrderId)==true && orderStatusDB.checkOnListOrder(order.OrderId) ==true)
                    {
                        order1 = mapper.Map<OrderModel>(order);
                       //order1.DriverId = order.ownedVehicleInfor.DriverId;
                        //order1.BussinessName = order.bussiness.BusinessName;
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

        public bool check(string mail)
        {
            try
            {
                return (driverDB.check(mail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object readDriver(int id)
        {
            try
            {
                Driver driver = driverDB.read(id);
                DriverModel driverModel = mapper.Map<DriverModel>(driver);

                List<OwnedVehicleInfor> OVIList = ownedVehicleInforRepositoryDB.getAll(id);
                return new { driver = driver, vehicle = OVIList };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DriverModel read(int id)
        {
            try
            {
                Driver driver = driverDB.read(id);
                DriverModel driverModel = mapper.Map<DriverModel>(driver);
                return driverModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DriverModel read(string name)
        {
            try
            {
                Driver driver = driverDB.read(name);
                DriverModel driverModel = mapper.Map<DriverModel>(driver);
                return driverModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(DriverModel entity)
        {
            try
            {
                Driver driver = mapper.Map<Driver>(entity);


                //Driver driver = new Driver()
                //{
                //    Address = entity.Address,
                //    Status = entity.Status,
                //    AvatarImageLink = entity.AvatarImageLink,
                //    DateCreatedAccount = entity.DateCreatedAccount,
                //    DateUpdatedAccount = entity.DateUpdatedAccount,
                //    BackIdentifyImageLink = entity.BackIdentifyImageLink,
                //    Password = entity.Password,
                //    Email = entity.Email,
                //    PhoneNumber = entity.PhoneNumber,
                //    Birthday = entity.Birthday,
                //    Gender = entity.Gender,
                //    FullName = entity.FullName,
                //    RoleId = entity.RoleId,
                    
                
                //}
                //    ;


                string pass_md5 = MD5Functions.GenerateMD5(driver.Password);
                driver.Password = pass_md5;
                driver.RoleId = 3;
                bool test = check(driver.Email);
                if (test == false)
                {
                    driverDB.create(driver);
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
        
        public bool delete(DriverModel entity)
        {
            return true;
        }

        public int checkAccount(string mail, string password, int roleId)
        {
            try
            {
                var check = driverDB.read(mail, password, roleId);
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

        public bool checkWAL(int oVIId, int orderId)
        {
            try
            {
                return wishedAcceptedDriverListDB.checkDupplicate(oVIId, orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderModel> getAllInitializedOrders(int OVIId, string DisGo, string ProGo, string DisCome, string ProCome)
        {
            try
            {
                OwnedVehicleInfor OVI = ownedVehicleInforRepositoryDB.read(OVIId);
                double cargo = (double)OVI.Cargo;
                
                List<OrderModel> rs = new List<OrderModel>();
                List<Order> list = orderDB.getAll(DisGo,ProGo,DisCome,ProCome);
                foreach (var order in list)
                {
                    
                    if (orderStatusDB.checkInitOrder(order.OrderId) == true && orderStatusDB.checkAcceptedOrder(order.OrderId) == false && orderStatusDB.checkOnListOrder(order.OrderId) == true && cargo >= order.TotalMass)
                    {
                        rs.Add(mapper.Map<OrderModel>(order));
                    }
                }
                return rs;




            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        public List<OwnedVehicleInforModel> getDriverOwnedVehicle(int driverId)
        {
            try
            { 
                List<OwnedVehicleInfor> ls = ownedVehicleInforRepositoryDB.getAll(driverId);
                List<OwnedVehicleInforModel> rs = new List<OwnedVehicleInforModel>();
                foreach (OwnedVehicleInfor model in ls)
                {
                    rs.Add(mapper.Map<OwnedVehicleInforModel>(model));
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Order> x()
        {
            return orderDB.getAll(1, "driverId");

        }
    }
}