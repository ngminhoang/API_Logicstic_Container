﻿using AutoMapper;
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
    internal class StaffService : IStaffService
    {
        private readonly IMapper mapper;
        private readonly IStaffRepository StaffDB;
        public StaffService(IMapper _mapper, IStaffRepository _Staff)
        {
            this.mapper = _mapper;
            this.StaffDB = _Staff;
        }
        public StaffModel read(int id)
        {
            try
            {
                Staff Staff = StaffDB.read(id);
                StaffModel StaffModel = mapper.Map<StaffModel>(Staff);
                return StaffModel;
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
                Staff Staff = StaffDB.read(name);
                StaffModel StaffModel = mapper.Map<StaffModel>(Staff);
                return StaffModel;
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
                Staff Staff = mapper.Map<Staff>(entity);
                return true;
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
                var check = StaffDB.read(mail, password, roleId);
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
