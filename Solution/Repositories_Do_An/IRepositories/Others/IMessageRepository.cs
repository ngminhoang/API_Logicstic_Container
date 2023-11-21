using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> getAll(int userId, int roleId);
    }
}
