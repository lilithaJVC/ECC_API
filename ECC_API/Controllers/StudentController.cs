using Microsoft.AspNetCore.Mvc;
using ECC_API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ECC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public StudentController(ECCDbContext context)
        {
            _context = context;
        }

        // POST: api/Student/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Students student)
        {
            if (_context.Students.Any(s => s.Email == student.Email))
            {
                return BadRequest("Email already exists.");
            }

            // Hash the password
            var hashedPassword = HashPassword(student.Password);
            student.Password = hashedPassword;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }

        // GET: api/Student/{email}
        [HttpGet("{email}")]
        public IActionResult GetStudentByEmail(string email)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Email == email);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Exclude the password from the response
            student.Password = null;

            return Ok(student);
        }

        private string HashPassword(string password)
        {
            // Generate a salt
            var salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Hash the password
            var hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            // Combine salt and hashed password
            var saltBase64 = Convert.ToBase64String(salt);
            var hashedBase64 = Convert.ToBase64String(hashed);

            return $"{saltBase64}:{hashedBase64}";
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            var parts = storedPassword.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = Convert.FromBase64String(parts[1]);

            var hashToVerify = KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return hashToVerify.SequenceEqual(storedHash);
        }
    }
}
