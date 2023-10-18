using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private CFcontext _dbcontext;
        public StatusRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Status entity)
        {
            try
            {
                _dbcontext.Statuss.Add(entity);
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

        public bool delete(Status entity)
        {
            try
            {
                _dbcontext.Statuss.Remove(entity);
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

        public List<Status> getAll()
        {
            try
            {
                List<Status> rs = _dbcontext.Statuss.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Status read(int id)
        {
            try
            {
                var rs = _dbcontext.Statuss.FirstOrDefault(t => t.StatusId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Status read(string name) => null;

        public bool update(Status entity)
        {
            try
            {
                _dbcontext.Statuss.Add(entity);
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
