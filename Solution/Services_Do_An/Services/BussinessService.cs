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
    public class BussinessService : IBussinessService
    {
        private readonly IMapper mapper;
        private readonly IBussinessRepository bussinessDB;
        public BussinessService(IMapper _mapper, IBussinessRepository _Bussiness)
        {
            this.mapper = _mapper;
            this.bussinessDB = _Bussiness;
        }

        public bool check(string mail)
        {
            try
            {
                return (bussinessDB.check(mail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BussinessModel read(int id)
        {
            try
            {
                Bussiness Bussiness = bussinessDB.read(id);
                BussinessModel BussinessModel = mapper.Map<BussinessModel>(Bussiness);
                return BussinessModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BussinessModel read(string name)
        {
            try
            {
                Bussiness Bussiness = bussinessDB.read(name);
                BussinessModel BussinessModel = mapper.Map<BussinessModel>(Bussiness);
                return BussinessModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(BussinessModel entity)
        {
            try
            {
                Bussiness bussiness = mapper.Map<Bussiness>(entity);
                string pass_md5 = MD5Functions.GenerateMD5(bussiness.BussinessPassword);
                bussiness.BussinessPassword = pass_md5;
                bussiness.RoleId = 5;
                bool test = check(bussiness.ContactEmail);
                if (test == false)
                {
                    bussinessDB.create(bussiness);
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
        public bool update(BussinessModel entity)
        {
            return true;
        }
        public bool delete(BussinessModel entity)
        {
            return true;
        }

        public int checkAccount(string mail, string password, int roleId)
        {
            try
            {
                var check = bussinessDB.read(mail, password, roleId);
                if (check != null)
                {
                    return check.BussinessId;
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
