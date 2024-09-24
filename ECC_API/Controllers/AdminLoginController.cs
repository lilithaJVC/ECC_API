using ECC_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public AdminLoginController(ECCDbContext context)
        {
            _context = context;
        }

        // POST: api/AdminLogin
        [HttpPost]
        public IActionResult Login([FromBody] AdminLogin login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // Check if the admin exists in the database
            var admin = _context.Administrator
                .FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Return success message or token (if you are using JWT, etc.)
            return Ok(new
            {
                Message = "Login successful",
                AdminID = admin.AdminID,
                AdminName = $"{admin.Firstname} {admin.Lastname}"
            });
        }
    }
}
