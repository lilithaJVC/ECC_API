using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECC_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingGuideTemplateController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public FundingGuideTemplateController(ECCDbContext context)
        {
            _context = context;
        }

        // GET: api/FundingGuideTemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundingGuide>>> GetFundingGuides()
        {
            return await _context.FundingGuide.ToListAsync();
        }

        // GET: api/FundingGuideTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FundingGuide>> GetFundingGuide(int id)
        {
            var fundingGuide = await _context.FundingGuide.FindAsync(id);

            if (fundingGuide == null)
            {
                return NotFound();
            }

            return fundingGuide;
        }

        [HttpPost]
        public async Task<ActionResult> PostFundingGuide(FundingGuide fundingGuide)
        {
            try
            {
                // Remove the line that sets StudentNum
                // fundingGuide.StudentNum = userStudentNum;

                // Add the funding guide to the context
                _context.FundingGuide.Add(fundingGuide);
                await _context.SaveChangesAsync();

                var response = new
                {
                    Message = "Funding guide successfully captured.",
                    FundingGuideId = fundingGuide.FundingGuideId,
                    FundingPurpose = fundingGuide.FundingPurpose,
                    AmountRequested = fundingGuide.AmountRequested
                };

                return CreatedAtAction(nameof(GetFundingGuide), new { id = fundingGuide.FundingGuideId }, response);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, new { message = "An error occurred while saving the funding guide.", error = ex.Message });
            }
        }
    }
}
