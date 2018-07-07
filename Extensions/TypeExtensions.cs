﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NoNameDev.CSharpCommon.Extensions {
    public static class TypeExtensions {
        public static bool IsArrayOf<T>(this Type type) {
            return type == typeof(T[]);
        }

        public static bool IsClassOrSubclassOf<T>(this Type type) {
            return type == typeof(T) || type.IsSubclassOf(typeof(T));
        }

        public static bool IsNonNullableSimpleType(this Type type) {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[] {
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }

        public static bool IsNullableSimpleType(this Type type) {
            return
                new Type[] {
                    typeof(short?),
                    typeof(int?),
                    typeof(double?),
                    typeof(float?),
                    typeof(String),
                    typeof(Decimal?),
                    typeof(DateTime?),
                    typeof(DateTimeOffset?),
                    typeof(TimeSpan?),
                    typeof(Guid?)
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

        public static bool IsNullableEnum(this Type type) {
            type = Nullable.GetUnderlyingType(type);
            return (type != null) && type.IsEnum;
        }

        public static bool IsNumericType(this Type type) {
            return IsNonNullableNumericType(type) || IsNullableNumericType(type);
        }

        public static bool IsICollection(this Type type) {
            return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
        }

        public static bool IsGenericOfType(this Type type, Type genericType) {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == genericType);
        }

        public static bool IsGenericCollectionType(this Type type) {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(ICollection<>));
        }

        public static bool IsSimpleType(this Type type) {
            return IsNullableSimpleType(type) || IsNonNullableSimpleType(type);
        }

        public static bool HasInterface<T>(this Type type) {
            return type.GetInterfaces().Contains(typeof(T));
        }
    }
}
