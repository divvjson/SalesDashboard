namespace SalesDashboard.Pages.Regional.SalesTrendTop3Countries
{
    public class SalesTrendTop3CountriesItem
    {
        public required string CountryName { get; set; }

        public IEnumerable<SalesYear> SalesYears { get; set; } = [];
    }

    public class SalesYear
    {
        public required int Year { get; set; }

        public required decimal TotalSales { get; set; }
    }
}
