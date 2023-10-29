using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        bool createBussinessContract(int cusId, int bussinessId, int orderId);
        bool createDriverContract(int cusId, int driverId, int orderId);
    }
}
