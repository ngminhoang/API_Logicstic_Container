using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    internal class CustomerService : ICustomerService
    { 
        private readonly IMapper mapper;
    private readonly ICustomerRepository customerDB;
    public CustomerService(IMapper _mapper, ICustomerRepository _customer)
    {
        this.mapper = _mapper;
        this.customerDB = _customer;
    }
    public CustomerModel read(int id)
    {
        try
        {
            Customer Customer = customerDB.read(id);
            CustomerModel CustomerModel = mapper.Map<CustomerModel>(Customer);
            return CustomerModel;
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
            Customer Customer = customerDB.read(name);
            CustomerModel CustomerModel = mapper.Map<CustomerModel>(Customer);
            return CustomerModel;
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
            Customer Customer = mapper.Map<Customer>(entity);
            return true;
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
