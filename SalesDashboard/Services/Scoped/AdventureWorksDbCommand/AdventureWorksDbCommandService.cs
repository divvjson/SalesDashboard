using System.Reactive.Subjects;

namespace SalesDashboard.Services.Scoped.AdventureWorksDbCommand
{
    public class AdventureWorksDbCommandService
    {
        public BehaviorSubject<string?> LatestDbCommandTextSubject = new(null);
    }
}
