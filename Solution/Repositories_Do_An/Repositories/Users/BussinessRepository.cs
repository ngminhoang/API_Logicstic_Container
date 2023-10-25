using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class BussinessRepository : IBussinessRepository
    {
        private CFcontext _dbcontext;
        public BussinessRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool check(string mail)
        {
            try
            {
                    var rs = _dbcontext.Bussinesss.FirstOrDefault(t => t.ContactEmail == mail);
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
        public Bussiness read(string mail, string password, int roleId)
        {
            try
            {
                var rs = _dbcontext.Bussinesss.FirstOrDefault(t => t.ContactEmail == mail && t.BussinessPassword == password && t.RoleId == roleId);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool create(Bussiness entity)
        {
            try
            {
                _dbcontext.Bussinesss.Add(entity);
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

        public bool delete(Bussiness entity)
        {
            try
            {
                _dbcontext.Bussinesss.Remove(entity);
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

        public List<Bussiness> getAll()
        {
            try
            {
                List<Bussiness> rs = _dbcontext.Bussinesss.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bussiness read(int id)
        {
            try
            {
                var rs = _dbcontext.Bussinesss.FirstOrDefault(t => t.BussinessId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bussiness read(string name) 
        {
            try
            {
                var rs = _dbcontext.Bussinesss.FirstOrDefault(t => t.BusinessName == name);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Bussiness entity)
        {
            try
            {
                _dbcontext.Bussinesss.Add(entity);
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
