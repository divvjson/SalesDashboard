namespace SalesDashboard.Pages.Regional.DistributionOfSales
{
    public class StateProvinceSale
    {
        public required int StateProvinceId { get; set; }

        public required string StateProvinceName { get; set; }

        public required string CountryRegionName { get; set; }

        public required double Latitude { get; set; }

        public required double Longitude { get; set; }

        public required decimal TotalSales { get; set; }
    }
}
