using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Apontamento.App.Util
{
    public static class Extensions
    {
        public static TimeSpan Sum<T>(this IEnumerable<T> source, Func<T, TimeSpan> selector)
        {
            return source.Select(selector).Aggregate((TimeSpan)TimeSpan.Zero, (t1, t2) => t1 + t2);
        }

        public static DateTime ToDatetime(this string value, string format)
        {
            return DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) ? date : throw new InvalidCastException("Data invalida");
        }

        public static int ToInt(this string value)
        {
            return int.TryParse(value, out var id) ? id : throw new InvalidCastException("Valor invalido");
        }
        
        public static string Format(this TimeSpan value)
        {
            return $"{value.TotalHours:00}:{value.Minutes:00}:{value.Seconds:00}";
        }
    }
}