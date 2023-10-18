using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class AppRateRepository : IRepository<AppRate>
    {
        private CFcontext _dbcontext;
        public AppRateRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(AppRate entity)
        {
            try
            {
                _dbcontext.AppRates.Add(entity);
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

        public bool delete(AppRate entity)
        {
            try
            {
                _dbcontext.AppRates.Remove(entity);
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

        public List<AppRate> getAll()
        {
            try
            {
                List<AppRate> rs = _dbcontext.AppRates.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppRate read(int id)
        {
            try
            {
                var rs = _dbcontext.AppRates.FirstOrDefault(t => t.UserId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppRate read(string name) => null;

        public bool update(AppRate entity)
        {
            try
            {
                _dbcontext.AppRates.Add(entity);
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
