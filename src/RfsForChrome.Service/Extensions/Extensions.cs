using System;

namespace RfsForChrome.Service.Extensions
{
    public static class Extensions
    {
        public static DateTime MyToDateTime(this string value)
        {
            DateTime converted;
            DateTime.TryParse(value, out converted);
            return converted;
        }
    }
}