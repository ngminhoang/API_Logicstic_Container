using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class NotificationRepository : IRepository<Notification>
    {
        private CFcontext _dbcontext;
        public NotificationRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Notification entity)
        {
            try
            {
                _dbcontext.Notifications.Add(entity);
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

        public bool delete(Notification entity)
        {
            try
            {
                _dbcontext.Notifications.Remove(entity);
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

        public List<Notification> getAll()
        {
            try
            {
                List<Notification> rs = _dbcontext.Notifications.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Notification read(int id)
        {
            try
            {
                var rs = _dbcontext.Notifications.FirstOrDefault(t => t.NotificationId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Notification read(string name) => null;

        public bool update(Notification entity)
        {
            try
            {
                _dbcontext.Notifications.Add(entity);
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
