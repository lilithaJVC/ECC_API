using System.ComponentModel.DataAnnotations;

namespace ECC_API.Models
{
    public class BusinessProposal
    {
        [Key]
        public int BusinessProposalId { get; set; }  // This will auto-generate
        public string ExecutiveSummary { get; set; }
        public string Introduction { get; set; }
        public string ProposedSolution { get; set; }
        public string ProblemSolution { get; set; }
        public string BudgetAndPenalties { get; set; }
        public string Benefits { get; set; }
        public string TermsAndConditions { get; set; }
        public string Appendix { get; set; }

        // Removed the constructor
    }
}
