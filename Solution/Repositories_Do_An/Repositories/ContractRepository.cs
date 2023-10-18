using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class ContractRepository : IRepository<Contract>
    {
        private CFcontext _dbcontext;
        public ContractRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Contract entity)
        {
            try
            {
                _dbcontext.Contracts.Add(entity);
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

        public bool delete(Contract entity)
        {
            try
            {
                _dbcontext.Contracts.Remove(entity);
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

        public List<Contract> getAll()
        {
            try
            {
                List<Contract> rs = _dbcontext.Contracts.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contract read(int id)
        {
            try
            {
                var rs = _dbcontext.Contracts.FirstOrDefault(t => t.ContractId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contract read(string name) => null;

        public bool update(Contract entity)
        {
            try
            {
                _dbcontext.Contracts.Add(entity);
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
