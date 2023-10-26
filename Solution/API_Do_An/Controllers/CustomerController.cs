using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerSV;
        public CustomerController(ICustomerService customerSV)
        {
            this.customerSV = customerSV;
        }
        // GET: api/<DriverController>
        [HttpPost("initOrder")]
        public IActionResult initOrder(OrderModel orderModel)
        {
            try
            {
                return Ok(customerSV.initOrder(orderModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AcceptedOrder/{orderId}/{oVIId}")]
        public IActionResult AcceptedOrder(int orderId, int oVIId)
        {
            try
            {
                return Ok(customerSV.acceptedOrder(orderId, oVIId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
