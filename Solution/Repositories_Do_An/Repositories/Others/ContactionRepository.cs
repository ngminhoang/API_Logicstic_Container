using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories.Others
{
    public class ContactionRepository : IContactionRepository
    {
        private CFcontext _dbcontext;
        public ContactionRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Contaction entity)
        {
            try
            {
                _dbcontext.Contactions.Add(entity);
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

        public bool delete(Contaction entity)
        {
            try
            {
                _dbcontext.Contactions.Remove(entity);
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

        public List<Contaction> getAll()
        {
            try
            {
                List<Contaction> rs = _dbcontext.Contactions.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contaction> getAll(int staffId)
        {
            try
            {
                List<Contaction> rs = _dbcontext.Contactions.Where(x=> x.StaffId==staffId).OrderBy(x => x.CheckRead).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contaction read(int id)
        {
            try
            {
                var rs = _dbcontext.Contactions.FirstOrDefault(t => t.ContactionId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contaction read(string name) => null;

        public bool update(Contaction entity)
        {
            try
            {
                _dbcontext.Contactions.Update(entity);
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
