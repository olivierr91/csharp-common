using System.Collections.Generic;
using System.Net.Http.Headers;

namespace CSharpCommon.Utils.Extensions.Net {
    public static class HttpRequestHeadersExtension
    {
        public static void AddOrReplace(this HttpRequestHeaders headers, string name, string value) {
            if (headers.Contains(name)) {
                headers.Remove(name);
            }
            headers.Add(name, value);
        }

        public static void AddOrReplaceAll(this HttpRequestHeaders headers, Dictionary<string, string> values) {
            foreach(KeyValuePair<string, string> value in values) {
                headers.AddOrReplace(value.Key, value.Value);
            }
        }

        public static void RemoveAll(this HttpRequestHeaders headers, Dictionary<string, string> values) {
            foreach (KeyValuePair<string, string> value in values) {
                if (headers.Contains(value.Key)) {
                    headers.Remove(value.Key);
                }
            }
        }
    }
}
