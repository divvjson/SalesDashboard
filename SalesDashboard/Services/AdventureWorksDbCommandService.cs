using System.Reactive.Subjects;

namespace SalesDashboard.Services
{
    public class AdventureWorksDbCommandService
    {
        public BehaviorSubject<KeyValuePair<string?, string?>> LatestDbCommandTextSubject = new(new(null, null));
    }
}
