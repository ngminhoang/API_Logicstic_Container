using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.APIFunctions;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    public class AdminService : IAdminService
    { 
        private readonly IMapper mapper;
        private readonly IAdminRepository adminDB;
        private readonly IDriverRepository driverDB;
        private readonly ICustomerRepository customerDB;
        private readonly IStaffRepository staffDB;
        private readonly IBussinessRepository bussinessDB;
        public AdminService(IBussinessRepository bussinessDB, IDriverRepository driverDB, ICustomerRepository customerDB , IStaffRepository staffDB, IMapper _mapper, IAdminRepository _admin) {
            this.mapper = _mapper;
            this.adminDB = _admin;
            this.driverDB = driverDB;
            this.customerDB = customerDB;
            this.staffDB = staffDB;
            this.bussinessDB = bussinessDB;
        }


        public bool changeDriverPassword(int driverId,string pass)
        {
            try
            {
                var data = driverDB.read(driverId);
                string pass_md5 = MD5Functions.GenerateMD5(data.Password);
                data.Password = pass_md5;
                return driverDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeStaffPassword(int staffId, string pass)
        {
            try
            {
                var data = staffDB.read(staffId);
                string pass_md5 = MD5Functions.GenerateMD5(pass);
                data.Password = pass_md5;
                return staffDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeBusinessPassword(int businessId, string pass)
        {
            try
            {
                var data = bussinessDB.read(businessId);
                string pass_md5 = MD5Functions.GenerateMD5(pass);
                data.BussinessPassword = pass_md5;
                return bussinessDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeCustomerPassword(int customerId, string pass)
        {
            try
            {
                var data = customerDB.read(customerId);
                string pass_md5 = MD5Functions.GenerateMD5(pass);
                data.Password = pass_md5;
                return customerDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeDriverStatus(int driverId)
        {
            try
            {
                var data = driverDB.read(driverId);
                if (data.Status == false) { data.Status = true; }
                else { data.Status = false; }
                return driverDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeStaffStatus(int staffId)
        {
            try
            {
                var data = staffDB.read(staffId);
                if (data.Status == false) { data.Status = true; }
                else { data.Status = false; }
                return staffDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeBusinessStatus(int businessId)
        {
            try
            {
                var data = bussinessDB.read(businessId);
                if (data.Status == false) { data.Status = true; }
                else { data.Status = false; }
                return bussinessDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changeCustomerStatus(int customerId)
        {
            try
            {
                var data = customerDB.read(customerId);
                if (data.Status == false) { data.Status = true; }
                else { data.Status = false; }
                return customerDB.update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerModel> getAllCustomers()
        {
            try
            {
                List<CustomerModel> rs = new List<CustomerModel>();
                List<Customer> customers = customerDB.getAll();
                foreach (Customer customer in customers) {
                rs.Add(mapper.Map<CustomerModel>(customer));
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<DriverModel> getAllDrivers()
        {
            try
            {
                List<DriverModel> rs = new List<DriverModel>();
                List<Driver> drivers = driverDB.getAll();
                foreach (Driver driver in drivers)
                {
                    rs.Add(mapper.Map<DriverModel>(driver));
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffModel> getAllStaffs()
        {
            try
            {
                List<StaffModel> rs = new List<StaffModel>();
                List<Staff> staffs = staffDB.getAll();
                foreach (Staff staff in staffs)
                {
                    rs.Add(mapper.Map<StaffModel>(staff));
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BussinessModel> getAllBussinesss()
        {
            try
            {
                List<BussinessModel> rs = new List<BussinessModel>();
                List<Bussiness> bussinesss = bussinessDB.getAll();
                foreach (Bussiness bussiness in bussinesss)
                {
                    rs.Add(mapper.Map<BussinessModel>(bussiness));
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
                return(adminDB.check(mail));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public AdminModel read(int id)
        {
            try
            {
                Admin admin = adminDB.read(id);
                AdminModel adminModel = mapper.Map<AdminModel>(admin);
                return adminModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AdminModel read(string name)
        {
            try
            {
                Admin admin = adminDB.read(name);
                AdminModel adminModel = mapper.Map<AdminModel>(admin);
                return adminModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(AdminModel entity)
        {
            try
            {
                Admin admin = mapper.Map<Admin>(entity);
                string pass_md5 = MD5Functions.GenerateMD5(admin.Password);
                admin.Password = pass_md5;
                admin.RoleId = 1;
                bool test = check(admin.Email);
                if (test == false)
                {
                    adminDB.create(admin);
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
        public bool update(AdminModel entity)
        {
            return true;
        }
        public bool delete(AdminModel entity)
        {
            return true;
        }
       
        public int checkAccount(string mail, string password, int roleId)
        {
            try
            {
                var check = adminDB.read(mail, password, roleId);
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
