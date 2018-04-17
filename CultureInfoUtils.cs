using System;
using System.Globalization;

namespace Common.Utils {
    public class CultureInfoUtils
    {
        public static readonly string[] KNOWN_LOCALE_NAMES = new string[] { "en", "fr" };

        public static CultureInfo ConvertFromKnownName(string cultureName, string defaultCultureName = null) {
            
            if (IsFrench(cultureName)) {
                return new CultureInfo("fr");
            } else if (IsEnglish(cultureName)) {
                return new CultureInfo("en");
            } else if (defaultCultureName != null) {
                return new CultureInfo(defaultCultureName);
            } else {
                return null;
            }
        }

        public static bool IsFrench(CultureInfo cultureInfo) {
            return IsFrench(cultureInfo.Name);
        }

        public static bool IsFrench(string cultureName) {
            return cultureName.Equals("fr", StringComparison.InvariantCultureIgnoreCase) || cultureName.StartsWith("fr-", StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsEnglish(CultureInfo cultureInfo) {
            return IsEnglish(cultureInfo.Name);
        }

        public static bool IsEnglish(string cultureName) {
            return cultureName.Equals("en", StringComparison.InvariantCultureIgnoreCase) || cultureName.StartsWith("en-", StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
