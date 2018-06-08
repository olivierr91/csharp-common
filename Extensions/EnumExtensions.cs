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
            return value.GetDisplayName(CultureInfo.CurrentCulture);
        }

        public static string GetDisplayName(this Enum value, CultureInfo locale) {
            return ResourceUtils.GetString(value, value.ToString(), locale);
        }

        public static MultiLangString GetMultiLangDisplayName(this Enum value, string[] localeNames = null) {
            return ResourceUtils.GetMultiLangString(value, value.ToString(), localeNames);
        }
    }
}
