using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utils.Extensions {
    public static class TypeExtensions {
        public static bool IsArrayOf<T>(this Type type) {
            return type == typeof(T[]);
        }

        public static bool IsSimpleType(this Type type) {
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
