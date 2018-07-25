using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NoNameDev.CSharpCommon.Extensions.Globalization {
    public static class CultureInfoExtensions
    {
        public static bool IsOrIsSubcultureOf(this CultureInfo parentCulture, CultureInfo childCulture) {
            return parentCulture.Equals(childCulture) || childCulture.IsSubcultureOf(parentCulture);
        }

        public static bool IsSubcultureOf(this CultureInfo parentCulture, CultureInfo childCulture) {
            do {
                if (childCulture.Parent.Equals(parentCulture)) {
                    return true;
                }
                childCulture = childCulture.Parent;
            } while (!childCulture.Equals(CultureInfo.InvariantCulture));
            return false;
        }

        public static CultureInfo GetClosestCulture(this CultureInfo cultureInfo, List<CultureInfo> cultureList) {
            while (!cultureInfo.Equals(CultureInfo.InvariantCulture)) {
                if (cultureList.Exists(sc => sc.Equals(cultureInfo))) {
                    return cultureInfo;
                }
                cultureInfo = cultureInfo.Parent;
            }
            return null;
        }
    }
}
