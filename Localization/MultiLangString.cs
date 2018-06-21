using CSharpCommon.Utils.Extensions.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace CSharpCommon.Utils.Localization {
    public class MultiLangString
    {
        private Dictionary<CultureInfo, string> _values = new Dictionary<CultureInfo, string>();

        public MultiLangString() {
            
        }

        public MultiLangString(params (string, string)[] values) {
            foreach ((string, string) value in values) {
                _values.Add(CultureInfo.GetCultureInfo(value.Item1), value.Item2);
            }
        }

        public MultiLangString(Dictionary<string, string> values) {
            foreach(KeyValuePair<string, string> value in values) {
                _values.Add(CultureInfo.GetCultureInfo(value.Key), value.Value);
            }
        }

        public MultiLangString(Dictionary<CultureInfo, string> values) {
            _values = values;
        }

        public Dictionary<CultureInfo, string> Values { get => _values; }

        public void AddLocalization(string value, CultureInfo locale) {
            _values[locale] = value;
        }

        public string Get() {
            return Get(CultureInfo.CurrentCulture);
        }

        public string Get(CultureInfo locale) {
            return _values[locale];
        }

        public string GetOrDefault(CultureInfo locale) {
            return _values.GetOrDefault(locale) ?? _values.GetOrDefault(CultureInfo.InvariantCulture);
        }

        public override string ToString() {
            return GetOrDefault(CultureInfo.CurrentCulture);
        }

        public static MultiLangString Merge(MultiLangString multiLangString, string value, CultureInfo locale) {
            if (value == null) {
                return multiLangString;
            } else if (multiLangString == null) {
                multiLangString = new MultiLangString();
            }
            multiLangString.AddLocalization(value, locale);
            return multiLangString;
        }
    }
}
