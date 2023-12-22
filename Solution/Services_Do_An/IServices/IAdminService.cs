using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.IServices
{
    public interface IAdminService : IServices<AdminModel>
    {
        int checkAccount(string mail, string password, int roleId);
        bool check(string mail);
        List<StaffModel> getAllStaffs();
        List<DriverModel> getAllDrivers();
        List<CustomerModel> getAllCustomers();
        List<BussinessModel> getAllBussinesss();
        bool changeDriverStatus(int driverId);
        bool changeCustomerStatus(int customerId);
        bool changeStaffStatus(int staffId);
        bool changeBusinessStatus(int businessId);
        bool changeDriverPassword(int driverId, string pass);
        bool changeCustomerPassword(int customerId, string pass);
        bool changeStaffPassword(int staffId, string pass);
        bool changeBusinessPassword(int businessId, string pass);
        Object counting();
        bool update(int customerId, AdminModel entity);
    }
}
