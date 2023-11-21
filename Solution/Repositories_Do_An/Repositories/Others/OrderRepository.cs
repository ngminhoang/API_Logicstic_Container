using Microsoft.EntityFrameworkCore;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CFcontext _dbcontext;
        public OrderRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Order entity)
        {
            try
            {
                
                _dbcontext.Orders.Add(entity);
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

        public bool delete(Order entity)
        {
            try
            {
                _dbcontext.Orders.Remove(entity);
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

        public List<Order> getAll()
        {
            try
            {
                List<Order> rs = _dbcontext.Orders.Include(x=>x.ownedVehicleInfor).Include(x=>x.customer).Include(x=> x.PositionCome).Include(x => x.PositionGo).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Order> getAll(string DisGo, string ProGo, string DisCome, string ProCome)
        {
            try
            {
                List<Order> rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor).Include(x => x.customer).Include(x => x.PositionCome).Include(x => x.PositionGo).Where(x => x.PositionGo.District==DisGo && x.PositionGo.Province == ProGo && x.PositionCome.District == DisCome && x.PositionCome.Province == ProCome).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order read(int id)
        {
            try
            {
                var rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor.driver).Include(x => x.customer).Include(x => x.PositionCome).Include(x => x.PositionGo).Include(x => x.customer).Include(x => x.bussiness).FirstOrDefault(t => t.OrderId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order read(string name) => null;

        public bool update(Order entity)
        {
            try
            {
                _dbcontext.Orders.Update(entity);
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
