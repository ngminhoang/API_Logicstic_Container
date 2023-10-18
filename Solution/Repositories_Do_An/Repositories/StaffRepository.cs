using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {
        private CFcontext _dbcontext;
        public StaffRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
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

        public Staff read(string name) => null;

        public bool update(Staff entity)
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
    }
}
