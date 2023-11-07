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
    public class StaffService : IStaffService
    {
        private readonly IMapper mapper;
        private readonly IStaffRepository staffDB;
        public StaffService(IMapper _mapper, IStaffRepository _staff)
        {
            this.mapper = _mapper;
            this.staffDB = _staff;
        }


        public bool check(string mail)
        {
            try
            {
                return (staffDB.check(mail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StaffModel read(int id)
        {
            try
            {
                Staff staff = staffDB.read(id);
                StaffModel staffModel = mapper.Map<StaffModel>(staff);
                return staffModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StaffModel read(string name)
        {
            try
            {
                Staff staff = staffDB.read(name);
                StaffModel staffModel = mapper.Map<StaffModel>(staff);
                return staffModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(StaffModel entity)
        {
            try
            {
                Staff staff = mapper.Map<Staff>(entity);
                string pass_md5 = MD5Functions.GenerateMD5(staff.Password);
                staff.Password = pass_md5;
                staff.RoleId = 2;
                bool test = check(staff.Email);
                if (test == false)
                {
                    staffDB.create(staff);
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
        public bool update(StaffModel entity)
        {
            return true;
        }
        public bool delete(StaffModel entity)
        {
            return true;
        }

        public int checkAccount(string mail, string password, int roleId)
        {
            try
            {
                var check = staffDB.read(mail, password, roleId);
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
