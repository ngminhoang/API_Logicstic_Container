using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class OwnedVehicleInforRepository : IOwnedVehicleInforRepository
    {
        private CFcontext _dbcontext;
        public OwnedVehicleInforRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(OwnedVehicleInfor entity)
        {
            try
            {
                _dbcontext.OwnedVehicleInfors.Add(entity);
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

        public bool delete(OwnedVehicleInfor entity)
        {
            try
            {
                _dbcontext.OwnedVehicleInfors.Remove(entity);
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

        public List<OwnedVehicleInfor> getAll()
        {
            try
            {
                List<OwnedVehicleInfor> rs = _dbcontext.OwnedVehicleInfors.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OwnedVehicleInfor read(int id)
        {
            try
            {
                var rs = _dbcontext.OwnedVehicleInfors.FirstOrDefault(t => t.OVIId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OwnedVehicleInfor read(string name) => null;

        public bool update(OwnedVehicleInfor entity)
        {
            try
            {
                _dbcontext.OwnedVehicleInfors.Update(entity);
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
