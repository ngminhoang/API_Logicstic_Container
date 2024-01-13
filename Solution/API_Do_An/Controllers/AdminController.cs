using API_Do_An.APIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services_Do_An.IServices;

namespace API_Do_An.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminService adminSV;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(IWebHostEnvironment hostingEnvironment, IAdminService adminSV)
        {
            this.adminSV = adminSV;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("counting")]
        public IActionResult counting()
        {
            try
            {
                return Ok(adminSV.counting());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("customer/password/{customerId}")]
        public IActionResult changeCustomerPassword(int customerId, [FromBody] Password pass)
        {
            try
            {
                return Ok(adminSV.changeCustomerPassword(customerId, pass.password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("driver/password/{driverId}")]
        public IActionResult changeDriverPassword(int driverId, [FromBody] Password pass)
        {
            try
            {
                return Ok(adminSV.changeDriverPassword(driverId, pass.password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("staff/password/{staffId}")]
        public IActionResult changeStaffPassword(int staffId, [FromBody] Password pass)
        {
            try
            {
                return Ok(adminSV.changeStaffPassword(staffId, pass.password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("business/password/{businessId}")]
        public IActionResult changeBusinessPassword(int businessId, [FromBody] Password pass)
        {
            try
            {
                return Ok(adminSV.changeBusinessPassword(businessId, pass.password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("customer/status/{customerId}")]
        public IActionResult changeCustomerStatus(int customerId)
        {
            try
            {
                return Ok(adminSV.changeCustomerStatus(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("driver/status/{driverId}")]
        public IActionResult changeDriverStatus(int driverId)
        {
            try
            {
                return Ok(adminSV.changeDriverStatus(driverId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("staff/status/{staffId}")]
        public IActionResult changeStaffStatus(int staffId)
        {
            try
            {
                return Ok(adminSV.changeStaffStatus(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("business/status/{businessId}")]
        public IActionResult changeBusinessStatus(int businessId)
        {
            try
            {
                return Ok(adminSV.changeBusinessStatus(businessId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAllCustomers")]
        public IActionResult getAllCustomers()
        {
            try
            {
                return Ok(adminSV.getAllCustomers());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAllDrivers")]
        public IActionResult getAllDrivers()
        {
            try
            {
                return Ok(adminSV.getAllDrivers());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAllStaffs")]
        public IActionResult getAllStaffs()
        {
            try
            {
                return Ok(adminSV.getAllStaffs());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAllBussinesss")]
        public IActionResult getAllBussinesss()
        {
            try
            {
                return Ok(adminSV.getAllBussinesss());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
