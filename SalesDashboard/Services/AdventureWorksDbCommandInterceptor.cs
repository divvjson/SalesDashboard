using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace SalesDashboard.Services
{
    public class AdventureWorksDbCommandInterceptor : DbCommandInterceptor
    {
        private readonly AdventureWorksDbCommandService _service;

        public AdventureWorksDbCommandInterceptor(AdventureWorksDbCommandService service)
        {
            _service = service;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            var circuitId = GetCircuitId(command.CommandText);

            if (!string.IsNullOrEmpty(circuitId))
            {
                var sanitized = SanitizeTagFromCommandText(command.CommandText);

                _service.LatestDbCommandTextSubject.OnNext(new(circuitId, sanitized));
            }

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private static string? GetCircuitId(string commandText)
        {
            var startTag = "CIRCUIT_ID_TAG_START";
            var endTag = "CIRCUIT_ID_TAG_END";

            int startIndex = commandText.IndexOf(startTag) + startTag.Length;
            int endIndex = commandText.IndexOf(endTag);

            if (startIndex == -1 || endIndex == -1)
            {
                return null;
            }

            var circuitId = commandText[startIndex..endIndex];

            return circuitId;
        }

        public static string SanitizeTagFromCommandText(string commandText)
        {
            // Loop to remove all tags following the pattern
            while (true)
            {
                // Find the start of any tag
                int startIndex = commandText.IndexOf("-- ");
                int endIndex = commandText.IndexOf("_TAG_END");

                // If no more tags are found, break the loop
                if (startIndex == -1 || endIndex == -1)
                    break;

                // Adjust the endIndex to include the "_TAG_END"
                endIndex += "_TAG_END".Length;

                // Remove the part of the string containing the tag
                commandText = commandText.Remove(startIndex, endIndex - startIndex).Trim();
            }

            // After removing all tags, also remove any new line characters
            commandText = commandText.Replace("\r\n", " ").Replace("\n", " ").Trim();

            return commandText;
        }
    }
}
