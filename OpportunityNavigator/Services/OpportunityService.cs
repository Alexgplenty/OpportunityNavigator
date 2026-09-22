using Microsoft.Data.SqlClient;
using OpportunityNavigator.Models;

namespace OpportunityNavigator.Services;

public class OpportunityService
{
    private readonly IConfiguration _configuration;

    public OpportunityService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<OpportunityProfile>> GetTopOpportunitiesAsync()
    {
        var opportunities = new List<OpportunityProfile>();

        var connectionString =
            _configuration.GetConnectionString("OpportunityDb");

        using var connection =
            new SqlConnection(connectionString);

        await connection.OpenAsync();

        var sql = @"
            SELECT TOP 100 *
            FROM dbo.vwOpportunityScores
            ORDER BY IntentScore DESC";

        using var command =
            new SqlCommand(sql, connection);

        using var reader =
            await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            opportunities.Add(new OpportunityProfile
            {
                AccountIdentifier =
                    reader["AccountIdentifier"].ToString() ?? "",

                AccountName=
                    reader["AccountName"].ToString() ?? "",

                Country=
                    reader["Country"].ToString() ?? "",

                Industry=
                    reader["Industry"].ToString() ?? "",

                TotalVisits =
                    Convert.ToInt32(reader["TotalVisits"]),

                KnowledgeVisits =
                    Convert.ToInt32(reader["KnowledgeVisits"]),

                AIVisits =
                    Convert.ToInt32(reader["AIVisits"]),

                ProductVisits =
                    Convert.ToInt32(reader["ProductVisits"]),

                SalesVisits =
                    Convert.ToInt32(reader["SalesVisits"]),

                CorporateVisits =
                    Convert.ToInt32(reader["CorporateVisits"]),

                PartnerVisits =
                    Convert.ToInt32(reader["PartnerVisits"]),

                LegalVisits =
                    Convert.ToInt32(reader["LegalVisits"]),

                CareerVisits =
                    Convert.ToInt32(reader["CareerVisits"]),

                IntentScore =
                    Convert.ToInt32(reader["IntentScore"])
            });
        }

        return opportunities;
    }
    public async Task<OpportunityProfile?> GetOpportunityAsync(string accountIdentifier)
    {
        var opportunities = await GetTopOpportunitiesAsync();

        return opportunities.FirstOrDefault(
            x => x.AccountIdentifier == accountIdentifier);
    }
}