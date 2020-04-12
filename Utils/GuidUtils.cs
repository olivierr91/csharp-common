using System;

namespace CSharpCommon.Utils {

    public static class GuidUtils {

        public static bool IsValidGuid(string guidStr) {
            Guid guid = default;
            return Guid.TryParse(guidStr, out guid);
        }
    }
}