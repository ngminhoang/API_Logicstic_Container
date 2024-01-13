using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories_Do_An.Repositories
{
    public class DriverRateRepository : IDriverRateRepository
    {
        private CFcontext _dbcontext;
        public DriverRateRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(DriverRate entity)
        {
            try
            {
                _dbcontext.DriverRates.Add(entity);
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

        public bool delete(DriverRate entity)
        {
            try
            {
                _dbcontext.DriverRates.Remove(entity);
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

        public List<DriverRate> getAll()
        {
            try
            {
                List<DriverRate> rs = _dbcontext.DriverRates.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DriverRate> getAll(int driverId)
        {
            try
            {
                List<DriverRate> rs = _dbcontext.DriverRates.Include(x => x.customer).Include(x => x.customer).Where(x=>x.DriverId==driverId).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DriverRate read(int id)
        {
            try
            {
                var rs = _dbcontext.DriverRates.FirstOrDefault(t => t.RateId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DriverRate read(string name) => null;

        public bool update(DriverRate entity)
        {
            try
            {
                _dbcontext.DriverRates.Update(entity);
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
