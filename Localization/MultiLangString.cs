using System.Collections.Generic;
using System.Globalization;

namespace CSharpCommon.Utils.Localization {
    public class MultiLangString
    {
        private Dictionary<string, string> _values = new Dictionary<string, string>();

        public MultiLangString(string defaultValue) {
            DefaultValue = defaultValue;
        }

        public MultiLangString(string defaultValue, Dictionary<string, string> values) : this(defaultValue) {
            _values = values;
        }

        public Dictionary<string, string> Values { get => _values; }

        public string DefaultValue { get; set; }

        public LocalizedString LocalizedString {
            get => GetLocalizedString(CultureInfo.CurrentCulture.Name);
        }

        public void AddLocalization(string value, string locale) {
            _values[locale] = value;
        }

        public LocalizedString GetLocalizedString(string locale) {
            string localizedValue = null;
            if (_values.ContainsKey(locale)) {
                localizedValue = _values[locale];
            } else {
                localizedValue = DefaultValue;
            }
            return new LocalizedString(DefaultValue, localizedValue);
        }

        public override string ToString() {
            return ToString(CultureInfo.CurrentCulture.Name);
        }

        public string ToString(string locale, bool fallbackToDefault = true) {
            if (_values.ContainsKey(locale)) {
                return _values[locale];
            } else if (fallbackToDefault) {
                return DefaultValue;
            } else {
                return null;
            }
        }

        public static MultiLangString Merge(MultiLangString multiLangString, string value, string locale) {
            if (value == null) {
                return multiLangString;
            } else if (multiLangString == null) {
                multiLangString = new MultiLangString(value);
            }
            multiLangString.AddLocalization(value, locale);
            return multiLangString;
        }

        public static MultiLangString MergeDefault(MultiLangString multiLangString, string value, string locale) {
            if (value == null) {
                return multiLangString;
            }
            multiLangString = Merge(multiLangString, value, locale);
            multiLangString.DefaultValue = value;
            return multiLangString;
        }
    }
}
