namespace OpportunityNavigator.Services
{
    public class OpenAIService
    {
        public async Task<string> GenerateOpportunityBrief(string prompt)
        {
            await Task.Delay(500);

            return $@"
            Opportunity Rating: High

            Confidence Level: High

            Key Areas Of Interest:
            - Knowledge Management
            - Artificial Intelligence
            - Product Evaluation

            Buying Signals:
            - Strong AI engagement
            - Significant product evaluation activity
            - Sales engagement detected

            Recommended Sales Action:
            Arrange a discovery workshop focused on AI-powered knowledge management capabilities.

            Executive Summary:
            This account demonstrates sustained engagement across knowledge management, AI and product-related content. 
            Product research and sales engagement activity suggest active solution evaluation and potential buying intent.";
        }
    }
}