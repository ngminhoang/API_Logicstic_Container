using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private CFcontext _dbcontext;
        public ContractTypeRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(ContractType entity)
        {
            try
            {
                _dbcontext.ContractTypes.Add(entity);
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

        public bool delete(ContractType entity)
        {
            try
            {
                _dbcontext.ContractTypes.Remove(entity);
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

        public List<ContractType> getAll()
        {
            try
            {
                List<ContractType> rs = _dbcontext.ContractTypes.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContractType read(int id)
        {
            try
            {
                var rs = _dbcontext.ContractTypes.FirstOrDefault(t => t.ContractTypeId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContractType read(string name) => null;

        public bool update(ContractType entity)
        {
            try
            {
                _dbcontext.ContractTypes.Update(entity);
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
