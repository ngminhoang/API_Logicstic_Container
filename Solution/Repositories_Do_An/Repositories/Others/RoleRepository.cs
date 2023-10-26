using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private CFcontext _dbcontext;
        public RoleRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Role entity)
        {
            try
            {
                _dbcontext.Roles.Add(entity);
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

        public bool delete(Role entity)
        {
            try
            {
                _dbcontext.Roles.Remove(entity);
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

        public List<Role> getAll()
        {
            try
            {
                List<Role> rs = _dbcontext.Roles.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role read(int id)
        {
            try
            {
                var rs = _dbcontext.Roles.FirstOrDefault(t => t.RoleId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role read(string name) => null;

        public bool update(Role entity)
        {
            try
            {
                _dbcontext.Roles.Update(entity);
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
