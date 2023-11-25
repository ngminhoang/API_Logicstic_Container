using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories.Others
{
    public interface IWishedAcceptedDriverListRepository: IRepository<WishedAcceptedDriverList>
    {
        bool checkDupplicate(int oVIId, int orderId);
        bool choosenDriver(int oVIId, int orderId);
        WishedAcceptedDriverList read(int oVIId, int orderId);
    }
}
