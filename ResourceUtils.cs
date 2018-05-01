using CSharpCommon.Utils.Localization;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace CSharpCommon.Utils {
    public static class ResourceUtils
    {
        public static string GetFileAsString(object caller, string identifier) {
            ResourceSet resourceSet = GetResourceSet(caller);
            object resource = resourceSet.GetObject(identifier);
            using (var memoryStream = new MemoryStream((byte[])resource))
            using (var streamReader = new StreamReader(memoryStream)) {
                return streamReader.ReadToEnd();
            }
        }

        public static string GetString(object caller, string identifier, string defaultString = null) {
            return GetString(caller, identifier, defaultString, CultureInfo.CurrentCulture);
        }

        public static string GetString(object caller, string identifier, string defaultString, CultureInfo locale) {
            ResourceSet resourceSet = GetResourceSet(caller, locale);
            if (resourceSet != null) {
                return resourceSet.GetString(identifier) ?? defaultString;
            } else {
                return defaultString;
            }
        }

        public static LocalizedString GetLocalizedString(object caller, string identifier, string defaultString = null) {
            string defaultValue = defaultString;
            string localizedValue = GetString(caller, identifier, defaultString);
            return new LocalizedString(defaultValue, localizedValue);
        }

        public static LocalizedString GetLocalizedString(object caller, string identifier, string defaultString, params object[] formatArguments) {
            LocalizedString value = GetLocalizedString(caller, identifier, defaultString);
            string formattedDefaultValue = String.Format(CultureInfo.CurrentCulture, value.DefaultValue, formatArguments);
            string formattedLocalizedValue = String.Format(CultureInfo.CurrentCulture, value.LocalizedValue, formatArguments);
            return new LocalizedString(formattedDefaultValue, formattedLocalizedValue);
        }

        public static MultiLangString GetMultiLangString(object caller, string identifier, string defaultString, string[] localeNames = null) {
            var multiLangString = new MultiLangString(defaultString);
            localeNames = localeNames ?? CultureInfoUtils.KNOWN_LOCALE_NAMES;
            foreach (var locale in localeNames) {
                multiLangString.AddLocalization(GetString(caller, identifier, defaultString, new CultureInfo(locale)), locale);
            }
            return multiLangString;
        }

        private static ResourceSet GetResourceSet(object caller) {
            return GetResourceSet(caller, CultureInfo.CurrentCulture);
        }

        private static ResourceSet GetResourceSet(object caller, CultureInfo locale) {
            ResourceManager resourceManager = new ResourceManager(caller.GetType().FullName, Assembly.GetAssembly(caller.GetType()));
            return resourceManager.GetResourceSet(locale, true, false);
        }
    }
}
