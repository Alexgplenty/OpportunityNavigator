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

        if (string.IsNullOrWhiteSpace(endpoint))
            throw new Exception("Endpoint is null");

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new Exception("ApiKey is null");

        if (string.IsNullOrWhiteSpace(deploymentName))
            throw new Exception("DeploymentName is null");

        var client = new AzureOpenAIClient(
            new Uri(endpoint),
            new AzureKeyCredential(apiKey));

        var chatClient = client.GetChatClient(deploymentName);

        var response = await chatClient.CompleteChatAsync(
            prompt);

        return response.Value.Content[0].Text;
    }
}