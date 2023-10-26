using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private CFcontext _dbcontext;
        public OrderStatusRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(OrderStatus entity)
        {
            try
            {
                _dbcontext.OrderStatuss.Add(entity);
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

        public bool delete(OrderStatus entity)
        {
            try
            {
                _dbcontext.OrderStatuss.Remove(entity);
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

        public List<OrderStatus> getAll()
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderStatus read(int id)
        {
            try
            {
                var rs = _dbcontext.OrderStatuss.FirstOrDefault(t => t.OrderStatusId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderStatus read(string name) => null;

        public bool update(OrderStatus entity)
        {
            try
            {
                _dbcontext.OrderStatuss.Add(entity);
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


        public bool checkInitOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId).ToList();
                if(rs.Count == 1 && rs[0].StatusId==1) 
                {
                    return true;
                }
                else { return false; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
