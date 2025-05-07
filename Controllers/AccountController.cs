using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            if (login.Login == "admin" && login.Password == "admin")
            {
                var token = generateTokenJWT();
                return Ok(new { token });
            }
            return BadRequest(new { message = "Invalid credentials, verify your name and password"});
        }

        private string generateTokenJWT()
        {
            string secretKey = "43149244-8170-402b-9d18-cef25d3ee2d1";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("name", "System administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "your_business",
                audience: "your_application",
                claims: null,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
