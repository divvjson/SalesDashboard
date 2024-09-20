using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SalesDashboard.Services
{
    public class DbCommandService
    {
        private readonly List<KeyValuePair<string, DbCommandItem>> _dbCommandItems = [];
        private readonly Subject<KeyValuePair<string, DbCommandItem>> _dbCommandItemSubject = new();

        public IObservable<KeyValuePair<string, DbCommandItem>> DbCommandItems => _dbCommandItemSubject.AsObservable();

        public void AddDbCommandItem(KeyValuePair<string, DbCommandItem> item)
        {
            _dbCommandItems.Add(item);
            _dbCommandItemSubject.OnNext(item);
        }

        public void RemoveDbCommandItemsForCircuit(string circuitId)
        {
            var itemsToRemove = _dbCommandItems
                .Where(item => item.Key == circuitId)
                .ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                _dbCommandItems.Remove(itemToRemove);
            }
        }

        public IReadOnlyList<KeyValuePair<string, DbCommandItem>> DbCommandItemsReadOnly => _dbCommandItems.AsReadOnly();

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

    public class DbCommandItem
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
