namespace SalesDashboard.Components.Shared.SelectProductDialog
{
    public class SelectProductGridItem
    {
        public required string Name { get; set; }

        public required string ProductNumber { get; set; }

        public required string? ProductSubcategoryName { get; set; }

        public required string? ProductCategoryName { get; set; }
    }
}
