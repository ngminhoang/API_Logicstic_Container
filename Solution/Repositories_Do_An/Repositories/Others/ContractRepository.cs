using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private CFcontext _dbcontext;
        public ContractRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool createDriverContract(int cusId, int driverId, int orderId) 
        {
            try
            {
                Contract contract = new Contract() { ContractTypeId = 1, CustomerId = cusId, DeliveryId = driverId, RoleId = 3, OrderId = orderId, Status = true};
                return create(contract);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool createBussinessContract(int cusId, int bussinessId, int orderId)
        {
            try
            {
                Contract contract = new Contract() { ContractTypeId = 2, CustomerId = cusId, DeliveryId = bussinessId, RoleId = 5, OrderId = orderId, Status = true };
                return create(contract);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                _dbcontext.Contracts.Update(entity);
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
