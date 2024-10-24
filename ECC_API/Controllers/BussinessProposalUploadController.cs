using ECC_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessProposalUploadController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public BusinessProposalUploadController(ECCDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBusinessProposal([FromForm] IFormFile file, [FromForm] int studentNum)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Define the file path
            var filePath = Path.Combine("uploads", file.FileName);

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Create a new BusinessProposalUpload record
            var upload = new BusinessProposalUpload
            {
                StudentNum = studentNum,
                FileName = file.FileName,
                FilePath = filePath,
                UploadDate = DateTime.Now
            };

            // Save the record to the database
            _context.BusinessProposalUploads.Add(upload);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "File uploaded successfully.", UploadID = upload.UploadID });
        }
    }
}
