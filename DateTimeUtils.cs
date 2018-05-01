using System;

namespace CSharpCommon.Utils {
    public static class DateTimeUtils
    {
        public static DateTime FromDateAndTime(DateTime date, DateTime time) {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }

        public static DateTime TryParseOrMin(string value, DateTime? defaultValue = null) {
            DateTime result;
            if (DateTime.TryParse(value, out result)) {
                return result;
            } else {
                return defaultValue ?? DateTime.MinValue;
            }
        }
    }
}
