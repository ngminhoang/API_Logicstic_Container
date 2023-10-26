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

        [HttpPost("ContractedByCustomerOrder/{orderId}")]
        public IActionResult contractedByCustomerOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.contractedByCustomerOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ContractedByDriverOrder/{orderId}")]
        public IActionResult contractedByDriverOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.contractedByDriverOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("DeliveringOrder/{orderId}")]
        public IActionResult deliveringOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.deliveringOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("DeliveredOrder/{orderId}")]
        public IActionResult deliveredOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.deliveredOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("TakenOrder/{orderId}")]
        public IActionResult takenOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.takenOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UnTakenOrder/{orderId}")]
        public IActionResult unTakenOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.unTakenOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("AlteredOrder/{orderId}")]
        public IActionResult alteredOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.alteredOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("PayedOrder/{orderId}")]
        public IActionResult payedOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.payedOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AccidentlOrder/{orderId}")]
        public IActionResult accidentlOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.accidentlOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
