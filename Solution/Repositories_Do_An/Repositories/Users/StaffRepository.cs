using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private CFcontext _dbcontext;
        public StaffRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public bool check(string mail)
        {
            try
            {
                    var rs = _dbcontext.Staffs.FirstOrDefault(t => t.Email == mail);
                    if (rs != null)
                    {
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


        public bool create(Staff entity)
        {
            try
            {
                _dbcontext.Staffs.Add(entity);
                _dbcontext.SaveChanges();
                try
                {
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

        public bool delete(Staff entity)
        {
            try
            {
                _dbcontext.Staffs.Remove(entity);
                _dbcontext.SaveChanges();
                try
                {
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

        public List<Staff> getAll()
        {
            try
            {
                List<Staff> rs = _dbcontext.Staffs.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Staff read(string mail, string password, int roleId)
        {
            try
            {
                var rs = _dbcontext.Staffs.FirstOrDefault(t => t.Email == mail && t.Password == password && t.RoleId == roleId);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Staff read(int id)
        {
            try
            {
                var rs = _dbcontext.Staffs.FirstOrDefault(t => t.UserId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Staff read(string name)
        {
            try
            {
                var rs = _dbcontext.Staffs.FirstOrDefault(t => t.FullName == name);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Staff entity)
        {
            try
            {
                _dbcontext.Staffs.Update(entity);
                _dbcontext.SaveChanges();
                try
                {
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
