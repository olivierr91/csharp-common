using NoNameDev.CSharpCommon.Extensions.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoNameDev.CSharpCommon.Utils {

    public static class EnumUtils {

        public static List<T> GetList<T>() {
            return Enum.GetValues(typeof(T)).ToList<T>();
        }

        public static List<T?> GetNullableList<T>() where T : struct {
            return Enum.GetValues(typeof(T)).ToList<T>().Select(s => (T?)s).ToList();
        }
    }
}