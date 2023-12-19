using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services_Do_An.DTOModels;

namespace Services_Do_An.IServices
{
    public interface IPublicService: IServices<Object>
    {
        bool createContaction(ContactionModel contaction);
        CustomerModel getCustomer(int customerId);
        Comment_DriverModel getDriver(int driverId);
        StaffModel getStaff(int staffId);
        bool checkAvalbleOrder(int orderId);
    }
}
