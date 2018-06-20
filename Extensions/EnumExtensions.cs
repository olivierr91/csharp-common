using CSharpCommon.Utils.Localization;
using CSharpCommon.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class EnumExtensions
    {
        public static bool HasAttribute<TAttribute>(this Enum value) where TAttribute : Attribute {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).HasAttribute<TAttribute>();
        }

        public static List<TAttribute> GetAttributes<TAttribute>(this Enum value) where TAttribute : Attribute {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetAttributes<TAttribute>();
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute {
            return GetAttributes<TAttribute>(value).Single();
        }

        public static TAttribute GetAttributeOrDefault<TAttribute>(this Enum value) where TAttribute : Attribute {
            return GetAttributes<TAttribute>(value).SingleOrDefault();
        }

        public static string GetDisplayName(this Enum value) {
            return ResourceUtils.GetString(value, value.ToString());
        }
    }
}
