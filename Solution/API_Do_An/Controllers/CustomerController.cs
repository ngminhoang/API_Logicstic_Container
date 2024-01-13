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
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CustomerController(IWebHostEnvironment hostingEnvironment,ICustomerService customerSV)
        {
            this.customerSV = customerSV;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<DriverController>


        [HttpPost("SaveImage")]
        public async Task<IActionResult> SaveImage(int customerId, [FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("Invalid image file");
                }

                // Get the path to the _assets folder next to the Controllers folder

                var assetsFolderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "_image", "customer");

                // Create the _assets folder if it doesn't exist
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }

                // Save the image to the staff folder
                var fileNameWithoutExtension = customerId.ToString();
                var fileName = Path.ChangeExtension(fileNameWithoutExtension, ".png");
                var filePath = Path.Combine(assetsFolderPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }


                return Ok(true);


            }
            catch (Exception ex)
            {
                return BadRequest(false);
            }
        }



        [HttpDelete("deleteOrder")]
        public IActionResult deleteOrder(int orderId)
        {
            try
            {
                return Ok(customerSV.deleteOrder(orderId));
            }
            catch (Exception ex)
            {
                return BadRequest(false);
            }
        }



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
        [HttpGet("Message")]
        public IActionResult getMessageList(int customerId)
        {
            try
            {
                return Ok(customerSV.getMessageList(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Message")]
        public IActionResult createMessage([FromBody] MessageModel mes)
        {
            try
            {
                return Ok(customerSV.createMessage(mes));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("Message/{messId}")]
        public IActionResult updateMessage(int messId)
        {
            try
            {

                return Ok(customerSV.updateMessage(messId));
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
                return Ok(customerSV.getOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("OrdersList/{orderId}/{oVIId}")]
        public IActionResult GetOrder(int oVIId, int orderId)
        {
            try
            {
                return Ok(customerSV.getOrder(oVIId, orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("OrdersList/{orderId}/Status")]
        public IActionResult GetOrderStatusList(int orderId)
        {
            try
            {
                return Ok(customerSV.getStatusList(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("OrdersList/{orderId}/Items")]
        public IActionResult GetOrderItemList(int orderId)
        {
            try
            {
                return Ok(customerSV.getItemList(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
