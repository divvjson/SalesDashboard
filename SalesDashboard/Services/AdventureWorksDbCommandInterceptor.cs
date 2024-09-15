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
            _service.LatestDbCommandTextSubject.OnNext(command.CommandText);

            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            _service.LatestDbCommandTextSubject.OnNext(command.CommandText);

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }
    }
}
