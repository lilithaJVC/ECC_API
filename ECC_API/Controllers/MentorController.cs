using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECC_API.Models;
using System.Threading.Tasks;

namespace ECC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public MentorController(ECCDbContext context)
        {
            _context = context;
        }

        // POST: api/Mentor/Login
        [HttpPost("Login")]
        public async Task<IActionResult> MentorLogin([FromBody] MentorLogin login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid login details.");
            }

            var mentor = await _context.Mentor
                .FirstOrDefaultAsync(m => m.Email == login.Email && m.Password == login.Password);

            if (mentor == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok("Login successful.");
        }
    }
}
