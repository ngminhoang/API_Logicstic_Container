using Microsoft.AspNetCore.Mvc;
using Services_Do_An.IServices;
using Services_Do_An.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverSV;
        public DriverController(IDriverService driverSV) 
        {
            this.driverSV = driverSV;
        }
        // GET: api/<DriverController>
        [HttpGet("OrdersList")]
        public IActionResult GetOrderList()
        {
            try 
            {
                return Ok(driverSV.getAllInitializedOrders());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("OrdersList/{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            try
            {
                return Ok(driverSV.getOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
