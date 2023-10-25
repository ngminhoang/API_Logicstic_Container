using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private CFcontext _dbcontext;
        public DriverRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public bool check(string mail)
        {
            try
            {
               
                    var rs = _dbcontext.Drivers.FirstOrDefault(t => t.Email == mail);
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


        public bool create(Driver entity)
        {
            try
            {
                _dbcontext.Drivers.Add(entity);
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

        public bool delete(Driver entity)
        {
            try
            {
                _dbcontext.Drivers.Remove(entity);
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

        public List<Driver> getAll()
        {
            try
            {
                List<Driver> rs = _dbcontext.Drivers.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Driver read(string mail, string password, int roleId)
        {
            try
            {
                var rs = _dbcontext.Drivers.FirstOrDefault(t => t.Email == mail && t.Password == password && t.RoleId == roleId);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Driver read(int id)
        {
            try
            {
                var rs = _dbcontext.Drivers.FirstOrDefault(t => t.UserId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Driver read(string name)
        {
            try
            {
                var rs = _dbcontext.Drivers.FirstOrDefault(t => t.FullName == name);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Driver entity)
        {
            try
            {
                _dbcontext.Drivers.Add(entity);
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
