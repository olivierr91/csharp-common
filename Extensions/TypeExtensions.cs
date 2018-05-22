using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class TypeExtensions {
        public static bool IsArrayOf<T>(this Type type) {
            return type == typeof(T[]);
        }

        public static bool IsNonNullableSimpleType(this Type type) {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[] {
                    typeof(String),
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }

        public static bool IsNonNullableNumericType(this Type type) {
            return new Type[] {
                    typeof(short),
                    typeof(int),
                    typeof(long),
                    typeof(decimal),
                    typeof(float),
                    typeof(double)
                }.Contains(type);
        }

        public static bool IsNullableNumericType(this Type type) {
            return new Type[] {
                    typeof(short?),
                    typeof(int?),
                    typeof(long?),
                    typeof(decimal?),
                    typeof(float?),
                    typeof(double?)
                }.Contains(type);
        }

        public static bool IsNumericType(this Type type) {
            return IsNonNullableNumericType(type) || IsNullableNumericType(type);
        }

        public static bool IsICollection(this Type type) {
            return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
        }

        public static bool IsGenericCollectionType(this Type type) {
            return type.IsGenericType && (typeof(ICollection<>) == type.GetGenericTypeDefinition());
        }

        public static bool HasInterface(this Type type, Type interfaceType) {
            return type.GetInterfaces().Contains(interfaceType);
        }
    }
}
