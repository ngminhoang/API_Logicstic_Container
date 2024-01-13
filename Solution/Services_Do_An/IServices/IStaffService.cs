using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.DTOModels;
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
        bool updateMessage(int messId, string answer);
        List<MessageModel> getMessageList(int staffId);
        List<MessageModel> getDriverMessageList(int staffId);
        List<MessageModel> getCustomerMessageList(int staffId);
        List<ContactionModel> getContactionList(int staffId);
        bool update(int staffId, StaffModel entity);
        bool updateContaction(int contactionId);

    }
}
