using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Common.Utils;
using Common.Utils.Localization;

namespace Common.Utils.Extensions {
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
            return GetAttributes<TAttribute>(value).First();
        }

        public static string GetDisplayName(this Enum value) {
            return value.GetDisplayName(CultureInfo.CurrentCulture);
        }

        public static string GetDisplayName(this Enum value, CultureInfo locale) {
            string defaultDisplayName = value.GetAttributes<DisplayNameAttribute>().FirstOrDefault()?.DisplayName;
            return ResourceUtils.GetString(value, value.ToString(), defaultDisplayName, locale);
        }

        public static MultiLangString GetMultiLangDisplayName(this Enum value, string[] localeNames = null) {
            string englishDisplayName = value.GetAttributes<DisplayNameAttribute>().FirstOrDefault()?.DisplayName;
            return ResourceUtils.GetMultiLangString(value, value.ToString(), englishDisplayName, localeNames);
        }
    }
}
