using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class DictionaryExtensions
    {
        public static T2 GetOrDefault<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key) {
            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            } else {
                return default(T2);
            }
        }

        public static void AddOrReplace<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key, T2 value){
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static void Remove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> predicate) {
            List<TKey> keysToRemove = dictionary.Where(predicate).Select(d => d.Key).ToList();
            foreach (TKey key in keysToRemove) {
                dictionary.Remove(key);
            }
        }
    }
}