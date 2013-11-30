using System;
using System.Globalization;

namespace RfsForChrome.Service.Extensions
{
    public static class Extensions
    {
        public static DateTime MyToDateTime(this string value)
        {
            DateTime converted;
            DateTime.TryParseExact(value, "dd MMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out converted);
            return converted;
        }
    }
}