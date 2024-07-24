namespace SalesDashboard.Pages.Regional.RegionalSummaryMatrix
{
    public class RegionalSummaryMatrixGridItem
    {
        public required string CountryRegionName { get; set; }

        public required string StateProvinceName { get; set; }

        public required string City { get; set; }

        public required int QuantitySold { get; set; }

        public required decimal TotalSales { get; set; }

        public required decimal TotalCosts { get; set; }

        public required decimal GrossProfit { get; set; }

        public required decimal GrossMargin { get; set; }
    }
}
