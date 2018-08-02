using NoNameDev.CSharpCommon.Extensions.Reflection;
using NoNameDev.CSharpCommon.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoNameDev.CSharpCommon.Extensions {

    public static class EnumExtensions {

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute {
            return GetAttributes<TAttribute>(value).Single();
        }

        public static TAttribute GetAttributeOrDefault<TAttribute>(this Enum value) where TAttribute : Attribute {
            return GetAttributes<TAttribute>(value).SingleOrDefault();
        }

        public static List<TAttribute> GetAttributes<TAttribute>(this Enum value) where TAttribute : Attribute {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetAttributes<TAttribute>();
        }

        public static string GetDisplayName(this Enum value) {
            return ResourceUtils.GetString(value, value.ToString());
        }

        public static bool HasAttribute<TAttribute>(this Enum value) where TAttribute : Attribute {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).HasAttribute<TAttribute>();
        }
    }
}