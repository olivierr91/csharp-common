using CSharpCommon.Extensions.Text;
using System;
using System.Linq;

namespace CSharpCommon.Utils {

    public static class MathUtils {

        public static bool ApproxEquals(float val1, float val2, float epsilon) {
            return Math.Abs(val1 - val2) <= epsilon;
        }

        public static bool IsInRange(float value, float minimum, float maximum) {
            return value >= minimum && value <= maximum;
        }

        public static bool IsWhole(decimal? value) {
            if (value == null) {
                return false;
            }
            return value % 1 == 0;
        }

        public static int Max(params int[] values) {
            return Enumerable.Max(values);
        }

        public static float? NullableMax(float? val1, float? val2) {
            if (val1.HasValue && val2.HasValue) {
                return Math.Max(val1.Value, val2.Value);
            } else if (val1.HasValue && !val2.HasValue) {
                return val1;
            } else if (!val1.HasValue && val2.HasValue) {
                return val2;
            } else {
                return null;
            }
        }

        public static decimal? NullableMax(decimal? val1, decimal? val2) {
            if (val1.HasValue && val2.HasValue) {
                return Math.Max(val1.Value, val2.Value);
            } else if (val1.HasValue && !val2.HasValue) {
                return val1;
            } else if (!val1.HasValue && val2.HasValue) {
                return val2;
            } else {
                return null;
            }
        }

        public static float? NullableMin(float? val1, float? val2) {
            if (val1.HasValue && val2.HasValue) {
                return Math.Min(val1.Value, val2.Value);
            } else if (val1.HasValue && !val2.HasValue) {
                return val1;
            } else if (!val1.HasValue && val2.HasValue) {
                return val2;
            } else {
                return null;
            }
        }

        public static decimal? NullableMin(decimal? val1, decimal? val2) {
            if (val1.HasValue && val2.HasValue) {
                return Math.Min(val1.Value, val2.Value);
            } else if (val1.HasValue && !val2.HasValue) {
                return val1;
            } else if (!val1.HasValue && val2.HasValue) {
                return val2;
            } else {
                return null;
            }
        }

        public static (int IntegerPart, int DecimalPart) SplitDecimalPoint(float value) {
            string[] strValues = value.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (strValues.Length == 2) {
                return (Int32.Parse(strValues[0]), Int32.Parse(strValues[1]));
            } else {
                return (Int32.Parse(strValues[0]), 0);
            }
        }

        public static (int IntegerPart, int DecimalPart) SplitDecimalPoint(decimal value) {
            string[] strValues = value.ToString().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (strValues.Length == 2) {
                return (Int32.Parse(strValues[0]), Int32.Parse(strValues[1]));
            } else {
                return (Int32.Parse(strValues[0]), 0);
            }
        }

        public static int Wrap(int value, int min, int max) {
            int range_size = max - min + 1;
            if (value < min)
                value += range_size * ((min - value) / range_size + 1);

            return min + (value - min) % range_size;
        }
    }
}