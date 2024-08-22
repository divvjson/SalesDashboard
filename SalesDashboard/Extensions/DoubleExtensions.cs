using System.Globalization;

namespace SalesDashboard.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToCurrencyWithTwoDecimals(this double value)
        {
            var formattedValue = value.ToString("C2", new CultureInfo("en-US"));
            
            return formattedValue;
        }
    }
}
