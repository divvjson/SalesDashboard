using System.Reactive.Subjects;

namespace SalesDashboard.Services
{
    public class AdventureWorksDbCommandService
    {
        public BehaviorSubject<KeyValuePair<string?, AdventureWorksDbCommandInfo?>> LatestDbCommandInfoSubject = new(new(null, null));

        public static string GetDbCommandTag(string key, string value)
        {
            switch (key)
            {
                case "CircuitId":
                {
                    return $"CIRCUIT_ID_TAG_START{value}CIRCUIT_ID_TAG_END";
                }
                case "CommandName":
                {
                    return $"COMMAND_NAME_TAG_START{value}COMMAND_NAME_TAG_END";
                }
                default:
                {
                    throw new ArgumentException();
                }
            }
        }
    }

    public class AdventureWorksDbCommandInfo
    {
        public string? CommandName { get; set; }

        public required string CommandText { get; set; }
    }
}
