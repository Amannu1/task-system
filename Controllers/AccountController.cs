using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if(login.Login == "admin" && login.Password == "admin")
            {
                return Ok(new {token = "xpto"});
            }
            return BadRequest(new { message = "Invalid credentials, verify your name and password"});
        }
    }
}
