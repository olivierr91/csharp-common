using System;
using System.Text.RegularExpressions;

namespace CSharpCommon.Utils.Extensions {
    public static class StringExtensions
    {
        public static bool IsValidEmailFormat(this string value) {
            return Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public static bool IsNumeric(this string value) {
            return Regex.IsMatch(value, @"^\d+$",  RegexOptions.Compiled);
        }

        public static bool ContainsSpaces(this string value) {
            return Regex.IsMatch(value, @"\s+", RegexOptions.Compiled);
        }

        public static string RemoveNonNumerics(this string value) {
            return Regex.Replace(value, @"[^0-9]", "", RegexOptions.Compiled);
        }

        public static string RemoveNonAlphaNumerics(this string value) {
            return Regex.Replace(value, @"[^0-9\w\s]", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string RemoveWhitespaces(this string value) {
            return Regex.Replace(value, @"\s+", "", RegexOptions.Compiled);
        }

        public static string SubstringEx(this string value, int startIndex, int length) {
            if (length < 0) {
                length = value.Length - (-length);
            }
            return value.Substring(startIndex, length);
        }

        public static string Append(this string value, string appendValue = null, string delimiter = "") {
            if (String.IsNullOrEmpty(appendValue)) {
                return value;
            }
            if (!String.IsNullOrEmpty(value)) {
                return value + delimiter + appendValue;
            } else {
                return value + appendValue;
            }
        }

        public static string Truncate(this string value, int maxLength) {
            return value.TruncateWith(maxLength, null);
        }

        public static string TruncateWithEllipsis(this string value, int maxLength) {
            return value.TruncateWith(maxLength, "...");
        }

        public static string TruncateWith(this string value, int maxLength, string suffix) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            } else if (value.Length <= maxLength) {
                return value;
            } else if (suffix != null) {
                return value.Substring(0, maxLength - suffix.Length) + suffix;
            } else {
                return value.Substring(0, maxLength);
            }
        }
    }
}
