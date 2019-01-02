using NoNameDev.CSharpCommon.Extensions;
using System;

namespace NoNameDev.CSharpCommon.Utils {

    public static class ObjectUtils {

        public static TValue ConvertTo<TValue>(object obj) {
            if (typeof(TValue).IsNullable() && obj == null) {
                return default;
            } else if (typeof(TValue) == obj?.GetType()) {
                return (TValue)obj;
            } else if (typeof(TValue).IsEnum) {
                return (TValue)(object)Convert.ToInt32(obj);
            } else if (typeof(TValue).IsNullableEnum()) {
                return (TValue)Enum.ToObject(Nullable.GetUnderlyingType(typeof(TValue)), Convert.ToInt32(obj));
            } else if (typeof(TValue) == typeof(Guid)) {
                return (TValue)(object)Guid.Parse(obj?.ToString());
            } else if (typeof(TValue) == typeof(Guid?)) {
                return (TValue)(object)(Guid?)Guid.Parse(obj?.ToString());
            } else if (typeof(TValue).HasInterface<IConvertible>()) {
                return (TValue)Convert.ChangeType(obj, typeof(TValue));
            } else if (typeof(TValue).IsNullable() && Nullable.GetUnderlyingType(typeof(TValue)).HasInterface<IConvertible>()) {
                return (TValue)Convert.ChangeType(obj, Nullable.GetUnderlyingType(typeof(TValue)));
            } else {
                return (TValue)obj;
            }
        }

        public static bool Equals<T>(T oldValue, T newValue, StringComparison stringComparisonType = StringComparison.InvariantCultureIgnoreCase) {
            if (typeof(T) == typeof(string)) {
                return String.Equals(oldValue as string, newValue as string, stringComparisonType);
            } else {
                return Object.Equals(newValue, oldValue);
            }
        }

        public static bool IsTypeOfOrSubTypeOf(Type objectType, Type type) {
            return objectType == type || objectType.IsSubclassOf(type);
        }

        public static TValue TryConvertTo<TValue>(object obj) {
            try {
                return ConvertTo<TValue>(obj);
            } catch (Exception) {
                return default;
            }
        }
    }
}