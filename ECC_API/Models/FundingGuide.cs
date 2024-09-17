namespace ECC_API.Models
{
    public class FundingGuide
    {
        public FundingGuide(int fundingGuideId, string fundingPurpose, int amountRequested, string bussinessOverview, string bussinessName, string mission, string bussinessModel, string totalFunding, string useOfFunds, string expenses, string profitability, string industry, string competitors, string marketTrends, string keyMembersAndRoles, string keyMilestones, string timeline, string risks, string riskPlan, string summary, string name, string email, string phoneNumber)
        {
            FundingGuideId = fundingGuideId;
            FundingPurpose = fundingPurpose;
            AmountRequested = amountRequested;
            BussinessOverview = bussinessOverview;
            BussinessName = bussinessName;
            Mission = mission;
            BussinessModel = bussinessModel;
            TotalFunding = totalFunding;
            UseOfFunds = useOfFunds;
            Expenses = expenses;
            Profitability = profitability;
            Industry = industry;
            Competitors = competitors;
            MarketTrends = marketTrends;
            KeyMembersAndRoles = keyMembersAndRoles;
            KeyMilestones = keyMilestones;
            Timeline = timeline;
            Risks = risks;
            RiskPlan = riskPlan;
            Summary = summary;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public int FundingGuideId { get; set; }
        public string FundingPurpose { get; set; }
        public int AmountRequested { get; set; }
        public string BussinessOverview { get; set; }
        public string BussinessName { get; set; }
        public string Mission { get; set; }
        public string BussinessModel { get; set; }
        public string TotalFunding { get; set; }
        public string UseOfFunds { get; set; }
        public string Expenses { get; set; }
        public string Profitability { get; set; }
        public string Industry { get; set; }
        public string Competitors { get; set; }
        public string MarketTrends { get; set; }
        public string KeyMembersAndRoles { get; set; }
        public string KeyMilestones { get; set; }
        public string Timeline { get; set; }
        public string Risks { get; set; }
        public string RiskPlan { get; set; }
        public string Summary { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
