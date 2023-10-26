using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class NotifTypeRepository : INotifTypeRepository
    {
        private CFcontext _dbcontext;
        public NotifTypeRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(NotifType entity)
        {
            try
            {
                _dbcontext.NotifTypes.Add(entity);
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

        public bool delete(NotifType entity)
        {
            try
            {
                _dbcontext.NotifTypes.Remove(entity);
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

        public List<NotifType> getAll()
        {
            try
            {
                List<NotifType> rs = _dbcontext.NotifTypes.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NotifType read(int id)
        {
            try
            {
                var rs = _dbcontext.NotifTypes.FirstOrDefault(t => t.NotifTypeId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NotifType read(string name) => null;

        public bool update(NotifType entity)
        {
            try
            {
                _dbcontext.NotifTypes.Update(entity);
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
