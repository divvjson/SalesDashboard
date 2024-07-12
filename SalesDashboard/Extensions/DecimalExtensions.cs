namespace SalesDashboard.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMillionsWithTwoDecimals(this decimal value)
        {
            return $"${value / 1_000_000:0.00}M";
        }
    }
}
