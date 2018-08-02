﻿using System;

namespace NoNameDev.CSharpCommon.Extensions {

    public static class DateTimeOffsetExtensions {

        public static DateTimeOffset Round(this DateTimeOffset value, long ticksAccuracy) {
            long mod = value.Ticks % ticksAccuracy;
            if (mod > ticksAccuracy / 2) {
                return value.AddTicks(ticksAccuracy - mod);
            } else {
                return value.AddTicks(-mod);
            }
        }

        public static DateTimeOffset RoundToCentiseconds(this DateTimeOffset value) {
            return value.Round(TimeSpan.TicksPerMillisecond * 100);
        }

        public static DateTimeOffset RoundToMilliseconds(this DateTimeOffset value) {
            return value.Round(TimeSpan.TicksPerMillisecond);
        }

        public static DateTimeOffset RoundToSeconds(this DateTimeOffset value) {
            return value.Round(TimeSpan.TicksPerSecond);
        }
    }
}