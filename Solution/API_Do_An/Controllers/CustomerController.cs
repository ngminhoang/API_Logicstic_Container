using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;
using System.Diagnostics.Eventing.Reader;
using Services_Do_An.DTOModels;
using XAct;

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

        [HttpPut("updateCustomer")]
        public IActionResult updateCustomer(int customerId, CustomerModel entity)
        {
            try
            {
                return Ok(customerSV.update(customerId, entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("initOrder")]
        public IActionResult initOrder(OrderModel2 orderModel)
        {
            try
            {
                int orderId = customerSV.initOrder(orderModel);
                if (!orderId.IsNull())
                {
                    return Ok(orderId);
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

        [HttpGet("WishAcceptDriverList/{orderId}")]
        public IActionResult wishAcceptDriverList(int orderId)
        {
            try
            {
                return Ok(customerSV.getWishedAcceptedDrivers(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllInitializedOrders/{customerId}")]
        public IActionResult getAllInitializedOrders(int customerId)
        {
            try
            {
                return Ok(customerSV.getAllInitializedOrders(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllWaitedDeliveredOrders/{customerId}")]
        public IActionResult getAllWaitedDeliveredOrders(int customerId)
        {
            try
            {
                return Ok(customerSV.getAllWaitedDeliveredOrders(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet("GetAllOnWorkedOrders/{customerId}")]
        public IActionResult getAllOnWorkedOrders(int customerId)
        {
            try
            {
                return Ok(customerSV.getAllOnWorkedOrders(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("GetAllHistory/{customerId}")]
        public IActionResult getAllHistory(int customerId)
        {
            try
            {
                return Ok(customerSV.getAllHistory(customerId));
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



        [HttpDelete("DeleteAcceptedOrder/{orderId}")]
        public IActionResult DeleteAcceptedOrder(int orderId, int oVIId)
        {
            try
            {
                if (customerSV.deleteAcceptedOrder(orderId))
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


        [HttpDelete("DeleteContractedByCustomerOrder/{orderId}")]
        public IActionResult DeleteContractedByCustomerOrder(int orderId)
        {
            try
            {
                if (customerSV.deleteContractedByCustomerOrder(orderId))
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
