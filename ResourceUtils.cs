using CSharpCommon.Utils.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace CSharpCommon.Utils {
    public static class ResourceUtils
    {
        public static string GetFileAsString(object caller, string identifier) {
            ResourceSet resourceSet = GetResourceSetOrInvariant(caller);
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
            return String.Format(GetString(caller, identifier), formatArguments);
        }

        public static string GetString(object caller, string identifier) {
            return GetString(caller, identifier, CultureInfo.CurrentCulture);
        }

        public static string GetString(object caller, string identifier, CultureInfo locale) {
            ResourceSet resourceSet = GetResourceSetOrInvariant(caller, locale);
            try {
                return resourceSet.GetString(identifier);
            } catch (Exception) {
#if DEBUG
                throw;
#else
                return "???";
#endif
            }
        }

        public static LocalizedString GetLocalizedString(object caller, string identifier) {
            string neutralValue = GetString(caller, identifier, CultureInfo.InvariantCulture);
            string localizedValue = GetString(caller, identifier);
            return new LocalizedString(neutralValue, localizedValue);
        }

        public static MultiLangString GetMultiLangString(object caller, string identifier, string[] localeNames = null) {
            var multiLangString = new MultiLangString();
            Dictionary<CultureInfo, ResourceSet> resourceSets = GetResourceSets(caller);
            foreach (var resourceSet in resourceSets) {
                multiLangString.AddLocalization(resourceSet.Value.GetString(identifier), resourceSet.Key);
            }
            return multiLangString;
        }

        private static ResourceSet GetResourceSetOrInvariant(object caller) {
            return GetResourceSetOrInvariant(caller, CultureInfo.CurrentCulture);
        }

        private static ResourceSet GetResourceSetOrInvariant(object caller, CultureInfo locale) {
            var resourceManager = GetResourceManager(caller);
            return resourceManager.GetResourceSet(locale, true, false) ?? resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
        }

        private static Dictionary<CultureInfo, ResourceSet> GetResourceSets(object caller) {
            var resourceManager = GetResourceManager(caller);
            var resourceSets = new Dictionary<CultureInfo, ResourceSet>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
                try {
                    resourceSets.Add(culture, resourceManager.GetResourceSet(culture, true, false));
                } catch { }
            }
            return resourceSets;
        }

        private static ResourceManager GetResourceManager(object caller) {
            return new ResourceManager(caller.GetType().FullName, Assembly.GetAssembly(caller.GetType()));
        }
    }
}
