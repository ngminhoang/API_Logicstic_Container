using API_Do_An.APIModels;
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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverSV;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DriverController(IWebHostEnvironment hostingEnvironment,IDriverService driverSV) 
        {
            this.driverSV = driverSV;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet("GetOnWorkedOrder/{driverId}")]
        public OnWorkedOrderModel getOnWorkedOrder(int driverId)
        {
            try
            {
                return driverSV.getOnWorkedOrder(driverId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("TurnToBeWorked")]

        public IActionResult turnToBeWorked(int driverId)
        {
            try
            {
                bool rs = driverSV.changeToWorked(driverId);
                if (rs)
                {
                    return Ok(rs);
                }
                else
                {
                    return BadRequest(rs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("TurnToNotBeWorked")]

        public IActionResult turnToNotBeWorked(int driverId)
        {
            try
            {
                bool rs = driverSV.changeToNotWorked(driverId);
                if (rs)
                {
                    return Ok(rs);
                }
                else
                {
                    return BadRequest(rs);
                }
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
                return Ok(driverSV.readDriver(driverId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("x")]
        public IActionResult x(int driverId)
        {
            try
            {
                return Ok(driverSV.x());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        [HttpPost("SaveImage")]
        public async Task<IActionResult> SaveImage(int driverId, [FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("Invalid image file");
                }

                // Get the path to the _assets folder next to the Controllers folder

                var assetsFolderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "_image", "driver");

                // Create the _assets folder if it doesn't exist
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }

                // Save the image to the staff folder
                var fileNameWithoutExtension = driverId.ToString();
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







        [HttpPut("UpdateDriver")]

        public IActionResult updateDriver(int driverId, DriverModel entity)
        {
            try
            {
                return Ok(driverSV.update(driverId, entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetVehicleList")]
        public IActionResult getVehicleList(int driverId)
        {
            try
            {
                return Ok(driverSV.getDriverOwnedVehicle(driverId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("CreateVehicle")]

        public IActionResult createVehicle(OwnedVehicleInforModel entity)
        {
            try
            {
                return Ok(driverSV.createVehicle(entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateVehicle")]

        public IActionResult updateVehicle(int oVIId, OwnedVehicleInforModel entity)
        {
            try
            {
                return Ok(driverSV.updateVehicle(oVIId, entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("DeleteVehicle")]

        public IActionResult deleteVehicle(int id)
        {
            try
            {
                return Ok(driverSV.deleteVehicle(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost("FilteredOrdersList")]
        public IActionResult GetFilteredOrdersList([FromBody] SearchFilter search)
        {
            try
            {
                List<OrderModel> ls = driverSV.getAllInitializedOrders(search.OVIId, search.DisGo, search.ProGo,search.DisCome, search.ProCome);
                
                List<FilteredOrdersResult> rs = new List<FilteredOrdersResult>();
                foreach (var each in ls )
                {
                    var check = driverSV.checkWAL(search.OVIId, each.OrderId);
                    rs.Add(new FilteredOrdersResult() { order=each, checkWAL=check });
                }
                return Ok(rs);
                //return Ok(driverSV.getAllInitializedOrders(search.OVIId, search.DisGo, search.ProGo, search.DisCome, search.ProCome));
            }
            catch (Exception ex)
            {
                throw ;
            }
        }


        // GET: api/<DriverController>
        [HttpGet("AllInitedOrdersList")]
        public IActionResult getOrderList()
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

        [HttpGet("OrdersList/{orderId}/{oVIId}")]
        public IActionResult GetOrder(int oVIId,int orderId)
        {
            try
            {
                return Ok(driverSV.getOrder(oVIId,orderId));
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
                return Ok(driverSV.getStatusList(orderId));
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
                return Ok(driverSV.getItemList(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("CustomerInfor")]
        public IActionResult GetCustomerInfor(int customerId)
        {
            try
            {
                return Ok(driverSV.getCustomer(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("GetAllAppliedOrders/{driverId}")]
        public IActionResult getAllAppliedOrders(int driverId)
        {
            try
            {
                return Ok(driverSV.getAllAppliedOrders(driverId));
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
                return Ok(driverSV.contractedByDriverOrder(orderId));
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
                return Ok(driverSV.deliveringOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("AccidentOrder/{orderId}")]
        public IActionResult accidentlOrder(int orderId)
        {
            try
            {
                return Ok(driverSV.accidentlOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AlteringOrder/{orderId}")]
        public IActionResult alteringOrder(int orderId)
        {
            try
            {
                return Ok(driverSV.alteringOrder(orderId));
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
                return Ok(driverSV.deliveredOrder(orderId));
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
                return Ok(driverSV.alteredOrder(orderId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ApplyOrder/{oVIId}/{orderId}")]
        public IActionResult applyOrder(int oVIId, int orderId)
        {
            try
            {
                if (driverSV.applyOrder(oVIId, orderId))
                    return Ok(driverSV.applyOrder(oVIId, orderId));
                else return BadRequest(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeleteApplyOrder/{oVIId}/{orderId}")]
        public IActionResult deleteApplyOrder(int oVIId, int orderId)
        {
            //return Ok(driverSV.x(oVIId, orderId));
            try
            {
                var rs = driverSV.deleteApplyOrder(oVIId, orderId);
                if (rs==true)
                    return Ok(rs);
                else return BadRequest(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(false);
            }
        }


        [HttpDelete("DeleteAcceptedOrder/{orderId}")]
        public IActionResult DeleteAcceptedOrder(int orderId, int oVIId)
        {
            try
            {
                if (driverSV.deleteAcceptedOrder(orderId))
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
                if (driverSV.deleteContractedByCustomerOrder(orderId))
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
                if (driverSV.payedOrder(orderId))
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
        public IActionResult getMessageList(int driverId)
        {
            try
            {
                return Ok(driverSV.getMessageList(driverId));
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
                return Ok(driverSV.createMessage(mes));
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

                return Ok(driverSV.updateMessage(messId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
