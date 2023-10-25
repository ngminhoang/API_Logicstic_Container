using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        Staff read(string name);
        Staff read(string mail, string password, int roleId);
        bool check(string mail);
    }
}
