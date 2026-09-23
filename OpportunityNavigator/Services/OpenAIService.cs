using Azure;
using Azure.AI.OpenAI;

namespace OpportunityNavigator.Services;

public class OpenAIService
{
    private readonly IConfiguration _configuration;

    public OpenAIService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<string> GenerateOpportunityBrief(string prompt)
    {
        var test = _configuration["TESTVALUE"];

        return $"TESTVALUE={(test ?? "NULL")}";
    }

}