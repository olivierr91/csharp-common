using System;

namespace NoNameDev.CSharpCommon.Extensions {
    public static class TimeSpanExtensions
    {
        public static TimeSpan Absolute(this TimeSpan value) {
            return new TimeSpan(Math.Abs(value.Ticks));
        }
    }
}
