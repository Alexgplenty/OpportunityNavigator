using OpportunityNavigator.Models;

namespace OpportunityNavigator.Services
{
    public class OpportunityPromptService
    {
        public string GenerateOpportunityBrief(
            OpportunityProfile opportunity)
        {
            return $@"You are an enterprise software sales strategist.

            Your task is to analyse website behaviour and determine whether the activity indicates a potential buying opportunity.

            When assessing activity:

            - High Knowledge Visits indicate research activity.
            - High AI Visits indicate interest in AI-related solutions.
            - High Product Visits indicate active product evaluation.
            - High Sales Visits indicate potential buying intent.
            - Corporate Information activity should be treated as neutral.
            - Career activity may indicate recruitment-related interest rather than buying intent.

            Provide:

            1. Opportunity Rating (Low, Medium, High)
            2. Confidence Level (Low, Medium, High)
            3. Key Areas of Interest
            4. Buying Signals
            5. Recommended Sales Action
            6. Executive Summary (maximum 150 words)

            Focus on helping a sales representative decide:
            - whether the opportunity is worth pursuing
            - why the opportunity is interesting
            - what action should be taken next
            Account Identifier:
            {opportunity.AccountIdentifier}

            Intent Overall Score:
            {opportunity.IntentScore}

            Knowledge Page Visits:
            {opportunity.KnowledgeVisits}

            AI Page Visits:
            {opportunity.AIVisits}

            Product Page Visits:
            {opportunity.ProductVisits}

            Sales Visits:
            {opportunity.SalesVisits}

            Corporate Page Visits:
            {opportunity.CorporateVisits}

            Partner Visits:
            {opportunity.PartnerVisits}

            Legal Page Visits:
            {opportunity.LegalVisits}

            Career Page Visits:
            {opportunity.CareerVisits}";

        }
    }
}