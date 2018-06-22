using System;

namespace NoNameDev.CSharpCommon.Utils {
    public static class BooleanUtils
    {
        public static bool? ParseNullable(string value) {
            if (value == null) {
                return null;
            } else {
                return Boolean.Parse(value);
            }
        }
    }
}
