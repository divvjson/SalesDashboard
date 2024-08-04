namespace SalesDashboard.Pages.Product.ProductSummaryMatrix
{
    public class ProductSummaryMatrixItem
    {
        public required string ProductCategoryName { get; set; }

        public required string ProductSubcategoryName { get; set; }

        public required string ProductName { get; set; }

        public required int QuantitySold { get; set; }

        public required decimal TotalSales { get; set; }

        public required decimal TotalCosts { get; set; }

        public required decimal GrossProfit { get; set; }

        public required decimal GrossMargin { get; set; }
    }
}
