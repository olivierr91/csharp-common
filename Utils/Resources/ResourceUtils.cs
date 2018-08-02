using NoNameDev.CSharpCommon.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NoNameDev.CSharpCommon.Utils.Resources {

    public static class ResourceUtils {

        public static LocalizedString GetLocalizedString(object caller, string identifier, params object[] formatArguments) {
            string neutralValue = GetString(caller, identifier, CultureInfo.InvariantCulture, formatArguments);
            string localizedValue = GetString(caller, identifier, formatArguments);
            return new LocalizedString(neutralValue, localizedValue);
        }

        public static MultiLangString GetMultiLangString(string resourceName, Assembly assembly, string identifier, string[] localeNames = null) {
            var multiLangString = new MultiLangString();
            Dictionary<CultureInfo, ResourceSet> resourceSets = GetResourceSets(resourceName, assembly);
            foreach (var resourceSet in resourceSets) {
                multiLangString.AddLocalization(resourceSet.Value.GetString(identifier), resourceSet.Key);
            }
            return multiLangString;
        }

        public static string GetString(object caller, string identifier, params object[] formatArguments) {
            return GetString(caller.GetType().FullName, caller.GetType().Assembly, identifier, CultureInfo.CurrentCulture, formatArguments);
        }

        public static string GetString(object caller, string identifier, CultureInfo locale, params object[] formatArguments) {
            return GetString(caller.GetType().FullName, caller.GetType().Assembly, identifier, locale, formatArguments);
        }

        public static string GetString(Type callerType, string identifier, params object[] formatArguments) {
            return GetString(callerType.FullName, callerType.Assembly, identifier, CultureInfo.CurrentCulture, formatArguments);
        }

        public static string GetString(string resourceName, Assembly assembly, string identifier, params object[] formatArguments) {
            return GetString(resourceName, assembly, identifier, CultureInfo.CurrentCulture, formatArguments);
        }

        public static string GetString(string resourceName, Assembly assembly, string identifier, CultureInfo locale, params object[] formatArguments) {
            ResourceSet resourceSet = GetResourceSetOrInvariant(resourceName, assembly, locale);
            try {
                var str = resourceSet?.GetString(identifier)
                    ?? throw new ResourceNotFoundException($"Resource '{assembly.FullName}/{resourceName}/{identifier}' could not be found for locale '{locale}'.");
                if (formatArguments.Length > 0) {
                    return String.Format(str, formatArguments);
                } else {
                    return str;
                }
            } catch (ResourceNotFoundException) {
                if (locale != CultureInfo.InvariantCulture) {
                    return GetString(resourceName, identifier, CultureInfo.InvariantCulture, formatArguments);
                } else {
                    return "???";
                }
            }
        }

        private static ResourceSet GetResourceSetOrInvariant(string resourceName, Assembly assembly) {
            return GetResourceSetOrInvariant(resourceName, assembly);
        }

        private static ResourceSet GetResourceSetOrInvariant(string resourceName, Assembly assembly, CultureInfo locale) {
            var resourceManager = new ResourceManager(resourceName, assembly);
            return resourceManager.GetResourceSet(locale, true, false) ?? resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
        }

        private static Dictionary<CultureInfo, ResourceSet> GetResourceSets(string resourceName, Assembly assembly) {
            var resourceManager = new ResourceManager(resourceName, assembly);
            var resourceSets = new Dictionary<CultureInfo, ResourceSet>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
                try {
                    resourceSets.Add(culture, resourceManager.GetResourceSet(culture, true, false));
                } catch { }
            }
            return resourceSets;
        }
    }
}