namespace SalesDashboard.Pages.Regional.SalesTrendTop3Countries
{
    public class SalesTrendTop3CountriesItem
    {
        public required int Year { get; set; }
        public required string CountryName { get; set; }
        public required decimal TotalSales { get; set; }
    }
}
