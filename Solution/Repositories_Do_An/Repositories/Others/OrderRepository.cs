using Microsoft.EntityFrameworkCore;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories_Do_An.Migrations;

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

        
        public EntityEntry<Order> create_2(Order entity)
        {
            try
            {
                var data = _dbcontext.Orders.Add(entity);
                _dbcontext.SaveChanges();
                try
                {
                    return data;
                }
                catch
                {
                    return null;
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
                List<Order> rs = _dbcontext.Orders.Include(x=>x.ownedVehicleInfor).Include(x=>x.customer).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Order> getAll(int driverId,string subject)
        {
            try
            {
                    List<Order> rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor).Include(x=>x.customer)
                        .Where(x => x.ownedVehicleInfor.DriverId == driverId).ToList();
                    return rs;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Order> getAll(int customerId)
        {
            try
            {
                List<Order> rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor.driver).Include(x => x.ownedVehicleInfor.vehicle).Include(x => x.customer).Where(x=> x.CustomerId == customerId).ToList();
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
                List<Order> rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor).Include(x => x.customer).Where(x=>x.DistrictCome==DisCome && x.ProvinceCome==ProCome && x.DistrictGo==DisGo && x.ProvinceGo==ProGo).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Order read(int id)
        {
            try
            {
                var rs = _dbcontext.Orders.Include(x => x.ownedVehicleInfor.driver).Include(x => x.customer).Include(x => x.customer).Include(x => x.bussiness).FirstOrDefault(t => t.OrderId == id);
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
