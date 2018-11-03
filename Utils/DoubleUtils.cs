using System;

namespace NoNameDev.CSharpCommon.Utils {

    public static class DoubleUtils {

        public static bool IsValidDouble(string value) {
            double intVal;
            return Double.TryParse(value, out intVal);
        }
    }
}