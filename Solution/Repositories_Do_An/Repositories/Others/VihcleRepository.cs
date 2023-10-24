using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class VihcleRepository : IVihcleRepository
    {
        private CFcontext _dbcontext;
        public VihcleRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Vihcle entity)
        {
            try
            {
                _dbcontext.Vihcles.Add(entity);
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

        public bool delete(Vihcle entity)
        {
            try
            {
                _dbcontext.Vihcles.Remove(entity);
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

        public List<Vihcle> getAll()
        {
            try
            {
                List<Vihcle> rs = _dbcontext.Vihcles.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vihcle read(int id)
        {
            try
            {
                var rs = _dbcontext.Vihcles.FirstOrDefault(t => t.VihcleId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vihcle read(string name) => null;

        public bool update(Vihcle entity)
        {
            try
            {
                _dbcontext.Vihcles.Add(entity);
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
