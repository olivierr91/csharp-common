using System;

namespace NoNameDev.CSharpCommon.Utils {
    public static class DateTimeOffsetUtils
    {
        public static readonly DateTimeOffset DATELESS_DATETIME = new DateTimeOffset(2000, 01, 01, 0, 0, 0, TimeSpan.Zero);

        public static DateTimeOffset FromTime(int hours, int minutes, int seconds, int milliseconds, TimeSpan offset) {
            return new DateTimeOffset(DATELESS_DATETIME.Year, DATELESS_DATETIME.Month, DATELESS_DATETIME.Day, hours, minutes, seconds, milliseconds, offset);
        }
    }
}
