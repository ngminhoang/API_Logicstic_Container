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
    public CustomerService(IMapper _mapper, ICustomerRepository _customer)
    {
        this.mapper = _mapper;
        this.customerDB = _customer;
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

}
}
