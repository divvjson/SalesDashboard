namespace SalesDashboard.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMillionsWithTwoDecimals(this decimal value)
        {
            return $"${value / 1_000_000:0.00}M";
        }

        public static string ToThousandWithTwoDecimals(this decimal value)
        {
            return $"${value / 1_000:0.00}K";
        }

        public static string ToPercentageWithTwoDecimals(this decimal value)
        {
            return value.ToString("0.00" + "%");
        }
    }
}
