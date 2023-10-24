using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class CountingRepository : ICountingRepository
    {
        private CFcontext _dbcontext;
        public CountingRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Counting entity)
        {
            try
            {
                _dbcontext.Countings.Add(entity);
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

        public bool delete(Counting entity)
        {
            try
            {
                _dbcontext.Countings.Remove(entity);
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

        public List<Counting> getAll()
        {
            try
            {
                List<Counting> rs = _dbcontext.Countings.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Counting read(int id)
        {
            try
            {
                var rs = _dbcontext.Countings.FirstOrDefault(t => t.CountingId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Counting read(string name) => null;

        public bool update(Counting entity)
        {
            try
            {
                _dbcontext.Countings.Add(entity);
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
