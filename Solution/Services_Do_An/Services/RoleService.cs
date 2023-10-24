using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleDB;
        public RoleService(IMapper _mapper, IRoleRepository _role)
        {
            this.mapper = _mapper;
            this.roleDB = _role;
        }
        public RoleModel read(int id)
        {
            try
            {
                Role driver = roleDB.read(id);
                RoleModel driverModel = mapper.Map<RoleModel>(driver);
                return driverModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RoleModel read(string name) => null;
        public bool create(RoleModel entity)
        {
            try
            {
                Role driver = mapper.Map<Role>(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(RoleModel entity)
        {
            return true;
        }
        public bool delete(RoleModel entity)
        {
            return true;
        }
    }
}
