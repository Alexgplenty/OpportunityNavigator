using OpportunityNavigator.Models;

namespace OpportunityNavigator.Services
{
    public class CsvOpportunityService
    {
        public async Task<int> CountRowsAsync()
        {
            var csvPath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "Opportunities.csv");

            if (!File.Exists(csvPath))
            {
                return -1;
            }

            var lines = await File.ReadAllLinesAsync(csvPath);

            return lines.Length;
        }

        public async Task<List<OpportunityProfile>> GetTopOpportunitiesAsync()
        {
            var opportunities = new List<OpportunityProfile>();

            var csvPath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "Opportunities.csv");

            if (!File.Exists(csvPath))
            {
                return opportunities;
            }

            var lines = await File.ReadAllLinesAsync(csvPath);

            foreach (var line in lines)
            {
                var fields = line.Split(',');

                opportunities.Add(new OpportunityProfile
                {
                    AccountIdentifier = fields[0],
                    TotalVisits = int.Parse(fields[1]),
                    KnowledgeVisits = int.Parse(fields[2]),
                    AIVisits = int.Parse(fields[3]),
                    ProductVisits = int.Parse(fields[4]),
                    SalesVisits = int.Parse(fields[5]),
                    CorporateVisits = int.Parse(fields[6]),
                    PartnerVisits = int.Parse(fields[7]),
                    LegalVisits = int.Parse(fields[8]),
                    CareerVisits = int.Parse(fields[9]),
                    AccountName = fields[10],
                    Country = fields[11],
                    Industry = fields[12],
                    IntentScore = int.Parse(fields[13])
                });
            }

            return opportunities;
        }

        public async Task<OpportunityProfile?> GetOpportunityAsync(
            string accountIdentifier)
        {
            var opportunities =
                await GetTopOpportunitiesAsync();

            return opportunities.FirstOrDefault(o =>
                o.AccountIdentifier == accountIdentifier);
        }
    }
}