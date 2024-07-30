namespace SalesDashboard.Extensions
{
    public static class IntExtensions
    {
        public static string ToTwoDecimalsInThousands(this int value)
        {
            var scaled = value / 1000.0;

            var formattedScaled = scaled.ToString("F2") + "K";

            return formattedScaled;
        }
    }
}
