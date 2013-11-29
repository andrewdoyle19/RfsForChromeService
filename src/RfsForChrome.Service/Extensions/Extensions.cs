using System;
using System.Globalization;

namespace RfsForChrome.Service.Extensions
{
    public static class Extensions
    {
        public static DateTime MyToDateTime(this string value)
        {
            DateTime converted;
            DateTime.TryParse(value, CultureInfo.CreateSpecificCulture("en-AU"), DateTimeStyles.None, out converted);
            return converted;
        }
    }
}