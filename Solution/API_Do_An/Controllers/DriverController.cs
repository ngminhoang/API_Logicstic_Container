using API_Do_An.APIModels;
using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
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

        [HttpPut("UpdateDriver")]

        public IActionResult updateDriver(DriverModel entity)
        {
            try
            {
                return Ok(driverSV.update(entity));
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

        public IActionResult updateVehicle(OwnedVehicleInforModel entity)
        {
            try
            {
                return Ok(driverSV.updateVehicle(entity));
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
                //return Ok();
                return Ok(driverSV.getAllInitializedOrders(search.OVIId, search.DisGo, search.ProGo, search.DisCome, search.ProCome));
            }
            catch (Exception ex)
            {
                throw ex;
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


        [HttpPost("AccidentlOrder/{orderId}")]
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
                return Ok(driverSV.applyOrder(oVIId, orderId));
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
        [HttpPut("Message/{messId}")]
        public IActionResult updateMessage(int messId,[FromBody] MessageModel message)
        {
            try
            {
                return Ok(driverSV.updateMessage(messId,message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
