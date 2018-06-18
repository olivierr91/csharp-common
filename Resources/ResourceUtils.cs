using CSharpCommon.Utils.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace CSharpCommon.Utils.Resources {
    public static class ResourceUtils
    {
        public static string GetFileAsString(object caller, string identifier) {
            ResourceSet resourceSet = GetResourceSetOrInvariant(caller.GetType());
            object resource = resourceSet.GetObject(identifier);
            using (var memoryStream = new MemoryStream((byte[])resource))
            using (var streamReader = new StreamReader(memoryStream)) {
                return streamReader.ReadToEnd();
            }
        }

        public static LocalizedString FormatLocalizedString(object caller, string identifier, params object[] formatArguments) {
            LocalizedString value = GetLocalizedString(caller, identifier);
            string formattedNeutralValue = String.Format(CultureInfo.CurrentCulture, value.NeutralValue, formatArguments);
            string formattedLocalizedValue = String.Format(CultureInfo.CurrentCulture, value.LocalizedValue, formatArguments);
            return new LocalizedString(formattedNeutralValue, formattedLocalizedValue);
        }

        public static string FormatString(object caller, string identifier, params object[] formatArguments) {
            return FormatString(caller.GetType(), identifier, formatArguments);
        }

        public static string FormatString(Type callerType, string identifier, params object[] formatArguments) {
            return String.Format(GetString(callerType, identifier), formatArguments);
        }

        public static string GetString(object caller, string identifier) {
            return GetString(caller.GetType(), identifier);
        }

        public static string GetString(Type callerType, string identifier) {
            return GetString(callerType, identifier, CultureInfo.CurrentCulture);
        }

        public static string GetString(object caller, string identifier, CultureInfo locale) {
            return GetString(caller.GetType(), identifier, locale);
        }

        public static string GetString(Type callerType, string identifier, CultureInfo locale) {
            ResourceSet resourceSet = GetResourceSetOrInvariant(callerType, locale);
            try {
                return resourceSet?.GetString(identifier) ?? throw new ResourceNotFoundException($"Resource '{identifier}' in '{callerType}' could not be found for locale '{locale}'.");
            } catch (ResourceNotFoundException) {
                if (locale != CultureInfo.InvariantCulture) {
                    return GetString(callerType, identifier, CultureInfo.InvariantCulture);
                } else {
                    return "???";
                }
            }
        }

        public static LocalizedString GetLocalizedString(object caller, string identifier) {
            string neutralValue = GetString(caller, identifier, CultureInfo.InvariantCulture);
            string localizedValue = GetString(caller, identifier);
            return new LocalizedString(neutralValue, localizedValue);
        }

        public static MultiLangString GetMultiLangString(object caller, string identifier, string[] localeNames = null) {
            var multiLangString = new MultiLangString();
            Dictionary<CultureInfo, ResourceSet> resourceSets = GetResourceSets(caller.GetType());
            foreach (var resourceSet in resourceSets) {
                multiLangString.AddLocalization(resourceSet.Value.GetString(identifier), resourceSet.Key);
            }
            return multiLangString;
        }

        private static ResourceSet GetResourceSetOrInvariant(Type callerType) {
            return GetResourceSetOrInvariant(callerType, CultureInfo.CurrentCulture);
        }

        private static ResourceSet GetResourceSetOrInvariant(Type callerType, CultureInfo locale) {
            var resourceManager = GetResourceManager(callerType);
            return resourceManager.GetResourceSet(locale, true, false) ?? resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
        }

        private static Dictionary<CultureInfo, ResourceSet> GetResourceSets(Type callerType) {
            var resourceManager = GetResourceManager(callerType);
            var resourceSets = new Dictionary<CultureInfo, ResourceSet>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
                try {
                    resourceSets.Add(culture, resourceManager.GetResourceSet(culture, true, false));
                } catch { }
            }
            return resourceSets;
        }

        private static ResourceManager GetResourceManager(Type callerType) {
            return new ResourceManager(callerType.FullName, Assembly.GetAssembly(callerType));
        }
    }
}
