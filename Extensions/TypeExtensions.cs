using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Extensions {

    public static class TypeExtensions {

        public static bool HasInterface<T>(this Type type) {
            return type.GetInterfaces().Contains(typeof(T));
        }

        public static bool IsArrayOf<T>(this Type type) {
            return type == typeof(T[]);
        }

        public static bool IsClassOrSubclassOf<T>(this Type type) {
            return type == typeof(T) || type.IsSubclassOf(typeof(T));
        }

        public static bool IsGenericCollectionType(this Type type) {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(ICollection<>));
        }

        public static bool IsGenericOfType(this Type type, Type genericType) {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == genericType);
        }

        public static bool IsICollection(this Type type) {
            return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
        }

        public static bool IsNonNullableNumericType(this Type type) {
            return new Type[] {
                    typeof(Int16),
                    typeof(UInt16),
                    typeof(Int32),
                    typeof(UInt32),
                    typeof(Int64),
                    typeof(UInt64),
                    typeof(Double),
                    typeof(Single),
                    typeof(Decimal)
                }.Contains(type);
        }

        public static bool IsNullable(this Type type) {
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static bool IsNullableEnum(this Type type) {
            type = Nullable.GetUnderlyingType(type);
            return (type != null) && type.IsEnum;
        }

        public static bool IsNullableNumericType(this Type type) {
            return new Type[] {
                    typeof(Int16?),
                    typeof(UInt16?),
                    typeof(Int32?),
                    typeof(UInt32?),
                    typeof(Int64?),
                    typeof(UInt64?),
                    typeof(Double?),
                    typeof(Single?),
                    typeof(Decimal?)
                }.Contains(type);
        }

        public static bool IsNullablePrimitive(this Type type) {
            return new Type[] {
                    typeof(Boolean?),
                    typeof(Byte?),
                    typeof(SByte?),
                    typeof(Int16?),
                    typeof(UInt16?),
                    typeof(Int32?),
                    typeof(UInt32?),
                    typeof(Int64?),
                    typeof(UInt64?),
                    typeof(IntPtr?),
                    typeof(UIntPtr?),
                    typeof(Char?),
                    typeof(Double?),
                    typeof(Single?)
                }.Contains(type);
        }

        public static bool IsNumericType(this Type type) {
            return IsNonNullableNumericType(type) || IsNullableNumericType(type);
        }
    }
}