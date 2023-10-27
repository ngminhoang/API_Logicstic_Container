using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Others;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.APIFunctions;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
        public DriverService(IMapper mapper, IWishedAcceptedDriverListRepository wishedAcceptedDriverListDB, IDriverRepository driverDB, IOrderRepository orderDB, IOrderStatusRepository orderStatusDB, IOrderItemRepository orderItemDB)
        {
            this.mapper = mapper;
            this.driverDB = driverDB;
            this.orderDB = orderDB;
            this.orderStatusDB = orderStatusDB;
            this.orderItemDB = orderItemDB;
            this.wishedAcceptedDriverListDB = wishedAcceptedDriverListDB;
        }

        public bool applyOrder(int oVIId, int orderId)
        {
            try
            {
                WishedAcceptedDriverList data = new WishedAcceptedDriverList() { OrderId = orderId, OVIId = oVIId, Status = true };
                if (wishedAcceptedDriverListDB.checkDupplicate(oVIId, orderId) == false)
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
        }


        public List<OrderItemModel> getOrder(int orderId) 
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
                return orderItemModelList;
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
                //foreach (var order in list)
                //{
                //    rs.Add(mapper.Map<OrderModel>(order));
                //}
                foreach (var order in list)
                {
                    if (orderStatusDB.checkInitOrder(order.OrderId)==true)
                    {
                        rs.Add(mapper.Map<OrderModel>(order));
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
        public bool update(DriverModel entity)
        {
            return true;
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
    }
}