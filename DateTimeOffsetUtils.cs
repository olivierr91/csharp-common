using System;

namespace CSharpCommon.Utils {
    public static class DateTimeOffsetUtils
    {
        public static DateTimeOffset FromTime(int hours, int minutes, int seconds, int milliseconds, TimeSpan offset) {
            DateTimeOffset min = DateTimeOffset.MinValue;
            return new DateTimeOffset(min.Year, min.Month, min.Day, hours, minutes, seconds, milliseconds, offset);
        }
    }
}
