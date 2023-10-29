using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;
using System.Diagnostics.Eventing.Reader;

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
                if (customerSV.initOrder(orderModel))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("OnListOrder/{orderId}")]
        public IActionResult onListOrder(int orderId)
        {
            try
            {
                if (customerSV.onListOrder(orderId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost("AcceptedOrder/{orderId}/{oVIId}")]
        public IActionResult AcceptedOrder(int orderId, int oVIId)
        {
            try
            {
                if (customerSV.acceptedOrder(orderId, oVIId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
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
                if (customerSV.contractedByCustomerOrder(orderId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
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
                if (customerSV.takenOrder(orderId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
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
                if (customerSV.unTakenOrder(orderId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
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
                if (customerSV.payedOrder(orderId))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AddOrderItem")]
        public IActionResult addOrderItem(OrderItemModel orderItem)
        {
            try
            {
                if (customerSV.addOrderItem(orderItem))
                {
                    return Ok(true); 
                }
                else 
                {
                    return BadRequest(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("RateDriver")]
        public IActionResult rateDriver(DriverRateModel rate)
        {
            try
            {
                if (customerSV.rateDriver(rate))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
