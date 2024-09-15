using System.Reactive.Subjects;

namespace SalesDashboard.Services
{
    public class AdventureWorksDbCommandService
    {
        public BehaviorSubject<KeyValuePair<string?, AdventureWorksDbCommandInfo?>> LatestDbCommandInfoSubject = new(new(null, null));

        public static string GetDbCommandTag(EnumDbCommandTag tag, string value)
        {
            switch (tag)
            {
                case EnumDbCommandTag.CIRCUIT_ID:
                {
                    return $"{CIRCUIT_ID_TAG_START}{value}{CIRCUIT_ID_TAG_END}";
                }
                case EnumDbCommandTag.COMMAND_NAME:
                {
                    return $"{COMMAND_NAME_TAG_START}{value}{COMMAND_NAME_TAG_END}";
                }
                default:
                {
                    throw new ArgumentException();
                }
            }
        }

        public const string CIRCUIT_ID_TAG_START = "CIRCUIT_ID_TAG_START";
        public const string CIRCUIT_ID_TAG_END = "CIRCUIT_ID_TAG_END";

        public const string COMMAND_NAME_TAG_START = "COMMAND_NAME_TAG_START";
        public const string COMMAND_NAME_TAG_END = "COMMAND_NAME_TAG_END";
    }

    public class AdventureWorksDbCommandInfo
    {
        public string? CommandName { get; set; }

        public required string CommandText { get; set; }
    }

    public enum EnumDbCommandTag
    {
        CIRCUIT_ID,
        COMMAND_NAME
    }
}
