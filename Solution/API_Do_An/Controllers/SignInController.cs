using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IAdminService adminSV;
        private readonly IDriverService driverSV;
        private readonly IStaffService staffSV;
        private readonly ICustomerService customerSV;
        private readonly IBussinessService bussinessSV;
        public SignInController(IAdminService adminSV, IDriverService driverSV, ICustomerService customerSV, IStaffService staffSV, IBussinessService bussinessSV) 
        {
            this.adminSV = adminSV;
            this.driverSV = driverSV;
            this.customerSV = customerSV;
            this.bussinessSV = bussinessSV;    
            this.staffSV = staffSV;

        }
        // GET: api/<ValuesController>
        [HttpPost("admin")]
        //[Authorize(Roles = "admin")]
        public IActionResult SignInAdmin(AdminModel admin)
        {
            try
            {
                var rs = adminSV.create(admin);
                if (rs) return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("staff")]
        //[Authorize(Roles = "admin")]
        public IActionResult SignInStaff(StaffModel staff)
        {
            try
            {
                var rs = staffSV.create(staff);
                if (rs) return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("driver")]
        public IActionResult SignInDriver(DriverModel driver)
        {
            try
            {
                var rs = driverSV.create(driver);
                if (rs) return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("customer")]
        public IActionResult SignInCustomer(CustomerModel customer)
        {
            try
            {
                var rs = customerSV.create(customer);
                if (rs) return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("bussiness")]
        public IActionResult SignInBussiness(BussinessModel bussiness)
        {
            try
            {
                var rs = bussinessSV.create(bussiness);
                if (rs) return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
