using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpCommon.Utils.Extensions.Text {
    public static class StringExtensions
    {
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

        public static bool Contains(this string source, string value, StringComparison comparison) {
            return source != null && value != null && source.IndexOf(value, comparison) >= 0;
        }

        public static bool ContainsSpaces(this string value) {
            return Regex.IsMatch(value, @"\s+", RegexOptions.Compiled);
        }

        public static bool IsValidEmailFormat(this string value) {
            return Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public static bool IsNumeric(this string value) {
            return Regex.IsMatch(value, @"^\d+$",  RegexOptions.Compiled);
        }

        public static string NullableTrim(this string value) {
            if (value == null) {
                return null;
            } else {
                return value.Trim();
            }
        }

        public static string RemoveDiacritics(this string value) {
            var normalizedString = value.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString) {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string RegExReplace(this string value, string pattern, string replacement) {
            return Regex.Replace(value, pattern, replacement, RegexOptions.Compiled);
        }

        public static string RemoveNonNumerics(this string value) {
            return Regex.Replace(value, @"[^0-9]", "", RegexOptions.Compiled);
        }

        public static string RemoveNonAlphaNumerics(this string value) {
            return Regex.Replace(value, @"[^0-9\w]", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string RemoveNonAlphaNumericsOrNonWhitespaces(this string value) {
            return Regex.Replace(value, @"[^0-9\w\s]", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string RemoveWhitespaces(this string value) {
            return Regex.Replace(value, @"\s+", "", RegexOptions.Compiled);
        }

        public static string ReplaceWhitespaces(this string value, string replaceWidth) {
            return Regex.Replace(value, @"\s+", replaceWidth, RegexOptions.Compiled);
        }

        public static string ReplaceMultiWhitespaceWithSingleSpace(this string value) {
            return Regex.Replace(value, @"\s+", " ");
        }

        public static string ReplaceNonAlphaNumericsWithSpace(this string value) {
            return Regex.Replace(value, "[^A-Za-z0-9 ]", " ");
        }

        public static bool SoftEquals(this string str1, string str2, bool ignoreCase = false) {
            if (str1 == null && str2 == null) {
                return true;
            } else if (str1 != null && str2 == null) {
                return false;
            } else if (str1 == null && str2 != null) {
                return false;
            } else {
                return String.Compare(str1.Trim(), str2.Trim(), ignoreCase) == 0;
            }
        }

        public static string[] Split(this string value, char separator, StringSplitOptions options = StringSplitOptions.None) {
            return value.Split(new char[] { separator }, options);
        }

        public static string[] Split(this string value, string separator, StringSplitOptions options = StringSplitOptions.None) {
            return value.Split(new string[] { separator }, options);
        }

        public static string[] SplitWhitespace(this string value) {
            return value.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string SubstringEx(this string value, int startIndex, int length) {
            if (length < 0) {
                length = value.Length - (-length);
            }
            return value.Substring(startIndex, length);
        }

        public static string ToSingleLine(this string value) {
            return Regex.Replace(value, @"[\r|\n]+", "");
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
