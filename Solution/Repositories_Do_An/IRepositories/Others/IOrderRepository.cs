using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> getAll(string DisGo, string ProGo, string DisCome,string ProCome);
        EntityEntry<Order> create_2(Order entity);
    }
}
