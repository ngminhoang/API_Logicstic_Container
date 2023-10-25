using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
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
        public DriverService(IMapper mapper, IDriverRepository driverDB, IOrderRepository orderDB, IOrderStatusRepository orderStatusDB, IOrderItemRepository orderItemDB)
        {
            this.mapper = mapper;
            this.driverDB = driverDB;
            this.orderDB = orderDB;
            this.orderStatusDB = orderStatusDB;
            this.orderItemDB = orderItemDB;
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
                foreach (var order in list)
                {
                    rs.Add(mapper.Map<OrderModel>(order));
                }
                    //foreach (var order in list)
                    //{
                    //    if (orderStatusDB.readByOrderId(order.OrderId).StatusId == 1)
                    //    {
                    //        rs.Add(mapper.Map<OrderModel>(order));
                    //    }
                    //}
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