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

        // POST: api/FundingGuideTemplate
        [HttpPost]
        public async Task<ActionResult> PostFundingGuide(FundingGuide fundingGuide)
        {
            _context.FundingGuide.Add(fundingGuide);
            await _context.SaveChangesAsync();

            // Create a response object with the success message
            var response = new
            {
                Message = "Funding guide successfully captured.",
                FundingGuideId = fundingGuide.FundingGuideId,
                FundingPurpose = fundingGuide.FundingPurpose,
                AmountRequested = fundingGuide.AmountRequested
            };

            return CreatedAtAction(nameof(GetFundingGuide), new { id = fundingGuide.FundingGuideId }, response);
        }

    }
}
