namespace ECC_API.Models
{
    public class BusinessProposal
    {
        public BusinessProposal(int businessProposalId, string executiveSummary, string introduction, string proposedSolution, string problemSolution, string budgetAndPenalties, string benefits, string termsAndConditions, string appendix)
        {
            BusinessProposalId = businessProposalId;
            ExecutiveSummary = executiveSummary;
            Introduction = introduction;
            ProposedSolution = proposedSolution;
            ProblemSolution = problemSolution;
            BudgetAndPenalties = budgetAndPenalties;
            Benefits = benefits;
            TermsAndConditions = termsAndConditions;
            Appendix = appendix;
        }

        public int BusinessProposalId { get; set; }
        public string ExecutiveSummary { get; set; }
        public string Introduction { get; set; }
        public string ProposedSolution { get; set; }
        public string ProblemSolution { get; set; }
        public string BudgetAndPenalties { get; set; }
        public string Benefits { get; set; }
        public string TermsAndConditions { get; set; }
        public string Appendix { get; set; }
    }
}
