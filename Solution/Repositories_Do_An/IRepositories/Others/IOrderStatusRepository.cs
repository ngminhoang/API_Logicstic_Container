using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
        List<OrderStatus> getAll(int orderId);
        bool checkInitOrder(int id);
        bool checkOnListOrder(int orderId);
        bool checkAcceptedOrder(int id);
        bool checkContractedByDriverOrder(int orderId);
        bool checkContractedByCustomerOrder(int orderId);
        bool checkDeliveringOrder(int orderId);
        bool checkDeliveredOrder(int orderId); 
        bool checkTakenOrder(int orderId);
        bool checkUnTakenOrder(int orderId);
        bool checkAlteredOrder(int orderId);
        bool checkFinishedOrder(int orderId);
        bool checkPayedOrder(int orderId);
        bool checkEndOrder(int orderId);
        bool checkRateDriver(int orderId);
        bool checkProblemOrder(int orderId);
        bool checkAlteringOrder(int orderId);
        int checkBeforeStatus(int orderId);
    }
}
