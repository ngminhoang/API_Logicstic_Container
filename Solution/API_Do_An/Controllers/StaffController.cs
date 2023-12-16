using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IStaffService staffSV;

        public StaffController(IStaffService staffSV, IWebHostEnvironment hostingEnvironment)
        {
            this.staffSV = staffSV;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("Message")]
        public IActionResult getMessageList(int staffId)
        {
            try
            {
                return Ok(staffSV.getMessageList(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("DriverMessage")]
        public IActionResult getDriverMessageList(int staffId)
        {
            try
            {
                return Ok(staffSV.getDriverMessageList(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("CustomerMessage")]
        public IActionResult getCustomerMessageList(int staffId)
        {
            try
            {
                return Ok(staffSV.getCustomerMessageList(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("Message/{messId}/{answer}")]
        public IActionResult updateMessage(int messId, string answer)
        {
            try
            {

                return Ok(staffSV.updateMessage(messId,answer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Contaction")]
        public IActionResult getContactionList(int staffId)
        {
            try
            {
                return Ok(staffSV.getContactionList(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("Contaction/{contactionId}")]
        public IActionResult updateContaction(int contactionId)
        {
            try
            {

                return Ok(staffSV.updateContaction(contactionId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [HttpPost("SaveImage")]
        public async Task<IActionResult> SaveImage(int staffId,[FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("Invalid image file");
                }

                // Get the path to the _assets folder next to the Controllers folder

                var assetsFolderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "_image", "staff");

                // Create the _assets folder if it doesn't exist
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }

                // Save the image to the staff folder
                var fileNameWithoutExtension = staffId.ToString();
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






            [HttpPut("UpdateStaff")]

        public IActionResult updateStaff(int staffId, StaffModel entity)
        {
            try
            {
                return Ok(staffSV.update(staffId, entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("ReadStaff")]

        public IActionResult readStaff(int staffId)
        {
            try
            {
                return Ok(staffSV.read(staffId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
