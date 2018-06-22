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
            var currentParentCulture = childCulture.Parent;
            while (currentParentCulture != null) {
                if (currentParentCulture.Equals(parentCulture)) {
                    return true;
                }
                currentParentCulture = currentParentCulture.Parent;
            }
            return false;
        }

        public static CultureInfo GetClosestCulture(this CultureInfo cultureInfo, List<CultureInfo> cultureLIst) {
            while (!cultureInfo.Equals(CultureInfo.InvariantCulture)) {
                if (cultureLIst.Exists(sc => sc.Equals(cultureInfo))) {
                    return cultureInfo;
                }
                cultureInfo = cultureInfo.Parent;
            }
            return null;
        }
    }
}
