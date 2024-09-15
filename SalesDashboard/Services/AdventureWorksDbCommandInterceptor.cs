﻿using Microsoft.EntityFrameworkCore.Diagnostics;
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

        //public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        //{
        //    _service.LatestDbCommandTextSubject.OnNext(command.CommandText);

        //    return result;
        //}

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            var circuitId = GetCircuitId(command.CommandText);
            // sanitized command text = <-----

            if (!string.IsNullOrEmpty(circuitId))
            {
                _service.LatestDbCommandTextSubject.OnNext(new(circuitId, command.CommandText));
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
    }
}
