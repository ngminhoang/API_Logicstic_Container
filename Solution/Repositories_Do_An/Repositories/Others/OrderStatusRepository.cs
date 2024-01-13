﻿using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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


        //public bool deleteAllAfterContractedByDriver(int driverId)
        //{
        //    try
        //    {
        //        var ls = _dbcontext.OrderStatuss.Include(x=> x.order.ownedVehicleInfor).Where(x=> x.order.ownedVehicleInfor.DriverId==driverId 
        //        && (x.StatusId==)).ToList();
        //        try
        //        {

        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool delete(int statusId, int orderId)
        {
            try
            {
                var rs=_dbcontext.OrderStatuss.FirstOrDefault(x=> x.StatusId== statusId && x.OrderId==orderId);
                _dbcontext.OrderStatuss.Remove(rs);
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

        public List<OrderStatus> getAll(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.OrderBy(e => e.Date).Include(x=>x.StatusType).Where(x=> x.OrderId==orderId && x.Status==true).ToList();
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
                _dbcontext.OrderStatuss.Update(entity);
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
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.Status == true && entity.StatusId == 1).ToList();
                if(rs.Count == 0) 
                {
                    return false;
                }
                else { return true; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool checkOutDateOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.Status == true && entity.StatusId == 139).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkOnListOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 19 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool checkAcceptedOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId==2 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkContractedByCustomerOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 4 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkContractedByDriverOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 3 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkDeliveringOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 5 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkDeliveredOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 6 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkTakenOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 7 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkUnTakenOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 8 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkAlteredOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 14 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkFinishedOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 10 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkPayedOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 11 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkEndOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 12 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkProblemOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 13 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool checkAlteringOrder(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 9 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkRateDriver(int orderId)
        {
            try
            {
                List<OrderStatus> rs = _dbcontext.OrderStatuss.Where(entity => entity.OrderId == orderId && entity.StatusId == 129 && entity.Status == true).ToList();
                if (rs.Count == 0)
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int checkBeforeStatus(int orderId)
        {
            try
            {
                var rs = _dbcontext.OrderStatuss.OrderByDescending(e => e.Date).Where(entity => entity.OrderId == orderId && entity.Status == true).FirstOrDefault();
                return (int)rs.StatusId; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderStatus getRecentStatus(int orderId)
        {
            try
            {
                var rs = _dbcontext.OrderStatuss.OrderByDescending(e => e.Date).Include(entity=> entity.StatusType).Where(entity => entity.OrderId == orderId && entity.Status == true).FirstOrDefault();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
