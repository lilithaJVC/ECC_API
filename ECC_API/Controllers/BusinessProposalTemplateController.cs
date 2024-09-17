using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECC_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessProposalTemplateController : ControllerBase
    {
        private readonly ECCDbContext _context;

        public BusinessProposalTemplateController(ECCDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessProposalTemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessProposal>>> GetBusinessProposals()
        {
            return await _context.BusinessProposal.ToListAsync();
        }

        // GET: api/BusinessProposalTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessProposal>> GetBusinessProposal(int id)
        {
            var businessProposal = await _context.BusinessProposal.FindAsync(id);

            if (businessProposal == null)
            {
                return NotFound();
            }

            return businessProposal;
        }

        // POST: api/BusinessProposalTemplate
        [HttpPost]
        public async Task<ActionResult> PostBusinessProposal(BusinessProposal businessProposal)
        {
            _context.BusinessProposal.Add(businessProposal);
            await _context.SaveChangesAsync();

            // Create a response object with the success message
            var response = new
            {
                Message = "Business proposal successfully captured.",
                BusinessProposalId = businessProposal.BusinessProposalId,
                ExecutiveSummary = businessProposal.ExecutiveSummary
            };

            return CreatedAtAction(nameof(GetBusinessProposal), new { id = businessProposal.BusinessProposalId }, response);
        }
    }
}
