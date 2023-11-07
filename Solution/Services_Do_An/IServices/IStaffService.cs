using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.IServices
{
    public interface IStaffService : IServices<StaffModel>
    {
        int checkAccount(string mail, string password, int roleId);
        bool check(string mail);

    }
}
