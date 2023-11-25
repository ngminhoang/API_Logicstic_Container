using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories.Others
{
    public class WishedAcceptedDriverListRepository : IWishedAcceptedDriverListRepository
    {
        private CFcontext _dbcontext;
        public WishedAcceptedDriverListRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool checkDupplicate(int oVIId, int orderId)
        {
            try
            {
                int data = _dbcontext.WishedAcceptedDriverLists.Where(entity => entity.OrderId == orderId && entity.OVIId == oVIId).Count();
                if (data == 0) return false;
                else return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
            public bool create(WishedAcceptedDriverList entity)
        {
            try
            {
                _dbcontext.WishedAcceptedDriverLists.Add(entity);
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

        public bool delete(WishedAcceptedDriverList entity)
        {
            try
            {
                _dbcontext.WishedAcceptedDriverLists.Remove(entity);
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

        public bool delete(int id)
        {
            try
            {
                try
                {
                    WishedAcceptedDriverList e = read(id);
                    e.Status = false;
                    update(e);
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



        public List<WishedAcceptedDriverList> getAll()
        {
            try
            {
                List<WishedAcceptedDriverList> rs = _dbcontext.WishedAcceptedDriverLists.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WishedAcceptedDriverList read(int id)
        {
            try
            {
                var rs = _dbcontext.WishedAcceptedDriverLists.FirstOrDefault(t => t.WADLId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WishedAcceptedDriverList read(int oVIId, int orderId)
        {
            try
            {
                var rs = _dbcontext.WishedAcceptedDriverLists.FirstOrDefault(t => t.OVIId==oVIId && t.OrderId==orderId);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WishedAcceptedDriverList read(string name) => null;

        public bool update(WishedAcceptedDriverList entity)
        {
            try
            {
                _dbcontext.WishedAcceptedDriverLists.Update(entity);
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

        bool IWishedAcceptedDriverListRepository.choosenDriver(int oVIId, int orderId)
        {
            try
            {
                List<WishedAcceptedDriverList> list = _dbcontext.WishedAcceptedDriverLists.Where(e => e.OrderId == orderId && e.OVIId != oVIId).ToList();
                foreach (WishedAcceptedDriverList e in list)
                {
                    delete(e.WADLId);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
