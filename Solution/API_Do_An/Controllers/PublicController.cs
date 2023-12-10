using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.DTOModels;
using Services_Do_An.IServices;
using Services_Do_An.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IPublicService publicSV;
        public PublicController(IPublicService publicSV)
        {
            this.publicSV = publicSV;
        }

        [HttpPost("CreateContaction")]
        public IActionResult createContaction([FromBody] ContactionModel contactionModel)
        {
            try
            {
                return Ok(publicSV.createContaction(contactionModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("DriverInfor")]
        public IActionResult getDriverInfor(int driverId)
        {
            try
            {
                return Ok(publicSV.getDriver(driverId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("CustomerInfor")]
        public IActionResult getCustomerInfor(int customerId)
        {
            try
            {
                return Ok(publicSV.getCustomer(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("StaffInfor")]
        public IActionResult getStaffInfor(int staffId)
        {
            try
            {
                return Ok(publicSV.getStaff(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
