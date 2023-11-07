using Microsoft.AspNetCore.Mvc;
using Repositories_Do_An.DBcontext_vs_Entities;
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
        public IActionResult createContaction([FromBody] Contaction contaction)
        {
            try
            {
                return Ok(publicSV.createContaction(contaction));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
