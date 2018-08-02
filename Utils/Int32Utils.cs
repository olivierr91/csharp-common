using System;

namespace NoNameDev.CSharpCommon.Utils {

    public static class Int32Utils {

        public static bool IsValidInt(string value) {
            int intVal;
            return Int32.TryParse(value, out intVal);
        }

        public static int? ParseNullable(string value) {
            if (value == null) {
                return null;
            } else {
                return Int32.Parse(value);
            }
        }
    }
}