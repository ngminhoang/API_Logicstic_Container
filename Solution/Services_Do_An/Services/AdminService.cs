using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    public class AdminService : IServices<AdminModel>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Admin> adminDB;
        public AdminService(IMapper mapper, IRepository<Admin> admin) {
            this.mapper = mapper;
            this.adminDB = admin;
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
            return null;
        }
        public bool create(AdminModel entity)
        {
            return true;
        }
        public bool update(AdminModel entity)
        {
            return true;
        }
        public bool delete(AdminModel entity)
        {
            return true;
        }
       
    }
}
