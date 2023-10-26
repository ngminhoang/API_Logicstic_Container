using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private CFcontext _dbcontext;
        public WarehouseRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Warehouse entity)
        {
            try
            {
                _dbcontext.Warehouses.Add(entity);
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

        public bool delete(Warehouse entity)
        {
            try
            {
                _dbcontext.Warehouses.Remove(entity);
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

        public List<Warehouse> getAll()
        {
            try
            {
                List<Warehouse> rs = _dbcontext.Warehouses.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Warehouse read(int id)
        {
            try
            {
                var rs = _dbcontext.Warehouses.FirstOrDefault(t => t.WarehouseId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Warehouse read(string name) => null;

        public bool update(Warehouse entity)
        {
            try
            {
                _dbcontext.Warehouses.Update(entity);
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
