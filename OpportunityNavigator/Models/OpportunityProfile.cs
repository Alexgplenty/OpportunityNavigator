namespace OpportunityNavigator.Models
{
    public class OpportunityProfile
    {
        public string AccountIdentifier { get; set; } = "";

        public int TotalVisits { get; set; }

        public string? AccountName { get; set; }

        public string? Country { get; set; }

        public string? Industry { get; set; }

        public int KnowledgeVisits { get; set; }

        public int AIVisits { get; set; }

        public int ProductVisits { get; set; }

        public int SalesVisits { get; set; }

        public int CorporateVisits { get; set; }

        public int PartnerVisits { get; set; }

        public int LegalVisits { get; set; }

        public int CareerVisits { get; set; }

        public int IntentScore { get; set; }
    }
}
