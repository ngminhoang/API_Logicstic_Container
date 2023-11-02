using Services_Do_An.APIFunctions;
using API_Do_An.APIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositories_Do_An.DBcontext_vs_Entities;
using Services_Do_An.IServices;
using Services_Do_An.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using XAct;
using XSystem.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Do_An.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRoleService roleSV;
        private readonly IAdminService adminSV;
        private readonly IDriverService driverSV;
        private readonly IStaffService staffSV;
        private readonly ICustomerService customerSV;
        private readonly IConfiguration configuration;
        private readonly IBussinessService bussinessSV;

        public LoginController(IConfiguration configuration, IRoleService roleSV, IAdminService adminSV, IDriverService driverSV, ICustomerService customerSV, IStaffService staffSV, IBussinessService bussinessSV )
        {
            try
            {
                this.roleSV = roleSV;
                this.adminSV = adminSV;
                this.driverSV = driverSV;
                
                this.bussinessSV = bussinessSV;
                this.staffSV = staffSV;
                this.configuration = configuration;
                this.customerSV = customerSV;
            }
            catch (Exception ex) { throw ex; }
        }



        [HttpPost]
        public IActionResult Login([FromBody] Account account)
        {
            var email = account.email;
            var password = account.password;
            //var roleId = account.roleId;

            //var roleName = roleSV.read(roleId).RoleName;
            var pass_md5 = MD5Functions.GenerateMD5(password);

            var driverCheck = driverSV.checkAccount(email, pass_md5, 3);
            var adminCheck = adminSV.checkAccount(email, pass_md5, 1);
            var staffCheck = staffSV.checkAccount(email, pass_md5, 2);
            var bussinessCheck = bussinessSV.checkAccount(email, pass_md5, 5);
            var customerCheck = customerSV.checkAccount(email, pass_md5, 4);
            string name;
            string role;
            int time;
            int id;
            //
            //

            if (driverCheck != 0)
            {
                id = driverCheck;
                role = "driver";
                name = driverSV.read(driverCheck).FullName;
                time = 1;
            }
            else if (adminCheck != 0)
            {
                id = adminCheck;
                role = "admin";
                name = adminSV.read(adminCheck).FullName;
                time = 4;
            }
            else if (staffCheck != 0)
            {
                id = staffCheck;
                role = "staff";
                name = staffSV.read(staffCheck).FullName;
                time = 4;
            }
            else if (bussinessCheck != 0)
            {
                id = bussinessCheck;
                role = "bussiness";
                name = bussinessSV.read(bussinessCheck).BusinessName;
                time = 1;
            }
            else if (customerCheck != 0)
            {
                id = customerCheck;
                role = "customer";
                name = customerSV.read(customerCheck).FullName;
                time = 1;
            }
            else { return new JsonResult(new { message = 0 }); } 

            
                var key = configuration["Jwt:Key"];
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role),
                };
                var identity = new ClaimsIdentity(claims, role);
                var claimPrincipal = new ClaimsPrincipal(identity);
                var adminClaim = claimPrincipal.Claims.ToList();
                //tao token voi thong so khop voi cau hinh
                var token = new JwtSecurityToken(

                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddMinutes(time),
                        signingCredentials: signingCredential,
                        claims: adminClaim
                    );
                //sinh chuoi token
                var usingToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new JsonResult(new { username = name, id = id, token = usingToken });
            
        }
        




    }
}
