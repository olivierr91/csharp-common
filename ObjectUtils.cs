using System;

namespace CSharpCommon.Utils
{
    public static class ObjectUtils
    {
        public static bool IsTypeOfOrSubTypeOf(Type objectType, Type type) {
            return objectType == type || objectType.IsSubclassOf(type);
        }

        public static bool Equals<T>(T oldValue, T newValue, StringComparison stringComparisonType = StringComparison.InvariantCultureIgnoreCase) {
            if (typeof(T) == typeof(string)) {
                return String.Equals(oldValue as string, newValue as string, stringComparisonType);
            } else {
                return Object.Equals(newValue, oldValue);
            }
        }
    }
}
