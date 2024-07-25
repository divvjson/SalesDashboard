using System.Text.Json;

namespace SalesDashboard.Helpers
{
    public sealed class SecretsHelper
    {
        private static readonly string SecretsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");

        public static string GetConnectionString(IConfiguration configuration)
        {
            var dataSource = configuration["DbDataSource"];
            var initialCatalog = configuration["DbInitialCatalog"];
            var userId = configuration["DbUserID"];
            var password = GetValue("DbPassword");

            var connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={userId};Password={password};Encrypt=False;MultipleActiveResultSets=true";

            return connectionString;
        }

        private static string GetValue(string key)
        {
            if (File.Exists(SecretsFilePath) == false)
            {
                throw new FileNotFoundException($"The secrets file '{SecretsFilePath}' does not exist. Please create it.");
            }

            try
            {
                var jsonString = File.ReadAllText(SecretsFilePath);

                using var jsonDoc = JsonDocument.Parse(jsonString);

                if (jsonDoc.RootElement.TryGetProperty(key, out var secretElement))
                {
                    return secretElement.GetString() ?? throw new KeyNotFoundException($"{key} not found in secrets file.");
                }
                else
                {
                    throw new KeyNotFoundException($"{key} not found in secrets file.");
                }
            }
            catch (JsonException ex)
            {
                throw new JsonException("Error parsing secrets file. Please ensure it is in valid JSON format.", ex);
            }
        }
    }
}
