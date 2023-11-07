using Microsoft.EntityFrameworkCore.Storage;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private CFcontext _dbcontext;
        public OrderItemRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(OrderItem entity)
        {
            try
            {
                _dbcontext.OrderItems.Add(entity);
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

        public bool delete(OrderItem entity)
        {
            try
            {
                _dbcontext.OrderItems.Remove(entity);
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


        public List<OrderItem> getAll(int orderId)
        {
            try
            {
                List<OrderItem> rs = _dbcontext.OrderItems.Where(entity => entity.OrderId == orderId).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public double sumWeight(int orderId)
        {
            try
            {
                List<OrderItem> rs = _dbcontext.OrderItems.Where(entity => entity.OrderId == orderId).ToList();
                double sum = 0;
                foreach (OrderItem item in rs)
                {
                    sum += (double)item.WeightPerUnit * (double)item.Quantity;
                }
                return sum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double sumMass(int orderId)
        {
            try
            {
                List<OrderItem> rs = _dbcontext.OrderItems.Where(entity => entity.OrderId == orderId).ToList();
                double sum=0;
                foreach(OrderItem item in rs)
                {
                    sum += (double)item.MassPerUnit * (double)item.Quantity;
                }
                return sum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderItem> getAll()
        {
            try
            {
                List<OrderItem> rs = _dbcontext.OrderItems.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderItem read(int id)
        {
            try
            {
                var rs = _dbcontext.OrderItems.FirstOrDefault(t => t.OrderItemId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderItem read(string name) => null;

        public bool update(OrderItem entity)
        {
            try
            {
                _dbcontext.OrderItems.Update(entity);
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
