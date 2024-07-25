using System.Globalization;

namespace SalesDashboard.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrencyWithTwoDecimalsInMillions(this decimal value)
        {
            value = value / 1000000;

            var formattedValue = value.ToString("C2", new CultureInfo("en-US"));

            return $"{formattedValue}M";
        }

        public static string ToCurrencyWithTwoDecimalsInThousands(this decimal value)
        {
            value = value / 1000;

            var formattedValue = value.ToString("C2", new CultureInfo("en-US"));

            return $"{formattedValue}K";
        }

        public static string ToCurrencyWithTwoDecimals(this decimal value)
        {
            var formattedValue = value.ToString("C2", new CultureInfo("en-US"));

            return formattedValue;
        }

        public static string ToPercentageWithTwoDecimals(this decimal value)
        {
            return value.ToString("0.00" + "%");
        }
    }
}
