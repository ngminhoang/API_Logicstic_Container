using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repositories_Do_An.DBcontext_vs_Entities;
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
        public AdminService(IMapper _mapper, IAdminRepository _admin) {
            this.mapper = _mapper;
            this.adminDB = _admin;
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
