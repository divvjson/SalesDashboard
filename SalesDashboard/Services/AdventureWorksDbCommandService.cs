using System.Reactive.Subjects;

namespace SalesDashboard.Services
{
    public class AdventureWorksDbCommandService
    {
        public BehaviorSubject<string?> LatestDbCommandTextSubject = new(null);
    }
}
