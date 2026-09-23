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
        var endpoint = _configuration["AzureOpenAI:Endpoint"];
        var apiKey = _configuration["AzureOpenAI:ApiKey"];
        var deploymentName = _configuration["AzureOpenAI:DeploymentName"];

        var client = new AzureOpenAIClient(
            new Uri(endpoint),
            new AzureKeyCredential(apiKey));

        var chatClient = client.GetChatClient(deploymentName);

        var response = await chatClient.CompleteChatAsync(prompt);

        return response.Value.Content[0].Text;
    }

}