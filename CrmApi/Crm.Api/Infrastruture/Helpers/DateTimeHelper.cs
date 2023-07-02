using System;
using System.Globalization;

namespace Crm.Api.Infrastruture.Helpers
{
    public static class DateTimeHelper
    {
        public static long GetJavaTimeStamp(this DateTime datetime)
        {
            var T = datetime.Ticks;
            double t = (T - 621355968000000000) / 10000;
            return (long)t;
        }

        public static DateTime StartOfDay(this DateTime dt)
        {
            return dt.Date;
        }

        public static DateTime EndOfDay(this DateTime dt)
        {
            return dt.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime FirstDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            var diff = dt.DayOfWeek - cultureInfo.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
                diff += 7;

            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt, CultureInfo cultureInfo) => dt.FirstDayOfWeek(cultureInfo).AddDays(7).AddTicks(-1);
        public static DateTime FirstDayOfMonth(this DateTime dt) => new DateTime(dt.Year, dt.Month, 1);

        public static DateTime LastDayOfMonth(this DateTime dt) => dt.FirstDayOfMonth().AddMonths(1).AddTicks(-1);
        public static DateTime FirstDayOfNextMonth(this DateTime dt) => dt.FirstDayOfMonth().AddMonths(1);

        public static DateTime FromUnixTime(this long unixTime)
        {
            return Epoch.AddMilliseconds(unixTime).ToLocalTime();
        }

        public static long ToUnixTime(this DateTime date)
        {
            return (long)(date - Epoch).TotalMilliseconds;
        }

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
