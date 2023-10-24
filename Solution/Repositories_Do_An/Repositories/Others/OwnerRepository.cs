using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private CFcontext _dbcontext;
        public OwnerRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Owner entity)
        {
            try
            {
                _dbcontext.Owners.Add(entity);
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

        public bool delete(Owner entity)
        {
            try
            {
                _dbcontext.Owners.Remove(entity);
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

        public List<Owner> getAll()
        {
            try
            {
                List<Owner> rs = _dbcontext.Owners.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Owner read(int id)
        {
            try
            {
                var rs = _dbcontext.Owners.FirstOrDefault(t => t.OwnerId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Owner read(string name) => null;

        public bool update(Owner entity)
        {
            try
            {
                _dbcontext.Owners.Add(entity);
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
