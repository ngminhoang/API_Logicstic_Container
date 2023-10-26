using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private CFcontext _dbcontext;
        public VehicleRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Vehicle entity)
        {
            try
            {
                _dbcontext.Vehicles.Add(entity);
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

        public bool delete(Vehicle entity)
        {
            try
            {
                _dbcontext.Vehicles.Remove(entity);
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

        public List<Vehicle> getAll()
        {
            try
            {
                List<Vehicle> rs = _dbcontext.Vehicles.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vehicle read(int id)
        {
            try
            {
                var rs = _dbcontext.Vehicles.FirstOrDefault(t => t.VehicleId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vehicle read(string name) => null;

        public bool update(Vehicle entity)
        {
            try
            {
                _dbcontext.Vehicles.Update(entity);
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
