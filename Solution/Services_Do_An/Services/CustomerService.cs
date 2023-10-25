using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.APIFunctions;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    public class CustomerService : ICustomerService
    { 
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerDB;
        private readonly IOrderRepository orderDB;
        private readonly IOrderItemRepository orderItemDB;
        private readonly IOrderStatusRepository orderStatusDB;
        public CustomerService(IOrderItemRepository _orderItem, IOrderRepository _order, IMapper _mapper, ICustomerRepository _customer, IOrderStatusRepository _orderStatus)
        {
            this.mapper = _mapper;
            this.customerDB = _customer;
            this.orderDB = _order;
            this.orderItemDB = _orderItem;
            this.orderStatusDB = _orderStatus;  
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
        public bool update(CustomerModel entity)
        {
            return true;
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

        bool createOrder(OrderModel orderModel)
        {
            try 
            {
                Order order = mapper.Map<Order>(orderModel);
                try
                {
                    orderDB.create(order);
                    orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date = DateTime.Now, StatusId = 1, Status = true});
                    return true;

                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool updateOrder(int oVIId,int orderId)
        {
            try
            {
                Order order = orderDB.read(orderId);
                order.OVIId = oVIId;
                try
                {
                    orderDB.update(order);
                    orderStatusDB.create(new OrderStatus { OrderId = order.OrderId, Date= DateTime.Now, StatusId=2, Status=true}); 
                    return true;

                }
                catch 
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
