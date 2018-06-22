using System;

namespace NoNameDev.CSharpCommon.Utils {
    public static class Int32Utils
    {
        public static int? ParseNullable(string value) {
            if (value == null) {
                return null;
            } else {
                return Int32.Parse(value);
            }
        }

        public static bool IsValidInt(string value) {
            int intVal;
            return Int32.TryParse(value, out intVal);
        }

    }
}
