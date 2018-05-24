using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class IDictionaryExtensions
    {
        public static Dictionary<T1, T2> CopyIntersectWith<T1, T2>(this IDictionary<T1, T2> dictionary, IEnumerable<T1> keys) {
            return dictionary.Keys.Intersect(keys).ToDictionary(v => v, v => dictionary[v]);
        }

        public static void AddOrReplace<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key, T2 value){
            if (dictionary.ContainsKey(key)) {
                dictionary[key] = value;
            } else {
                dictionary.Add(key, value);
            }
        }

        public static void AddToValueList<T1, T2>(this IDictionary<T1, List<T2>> dictionary, T1 key, T2 value) {
            List<T2> list;
            if (dictionary.ContainsKey(key)) {
                list = dictionary[key];
            } else {
                list = new List<T2>();
                dictionary.Add(key, list);
            }
            list.Add(value);
        }

        public static T2 GetOrDefault<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key) {
            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            } else {
                return default(T2);
            }
        }

        public static void Merge<T1, T2>(this IDictionary<T1, T2> dictionary, IReadOnlyDictionary<T1, T2> otherDictionary) {
            foreach (KeyValuePair<T1, T2> entry in otherDictionary) {
                dictionary[entry.Key] = entry.Value;
            }
        }

        public static void Remove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> predicate) {
            List<TKey> keysToRemove = dictionary.Where(predicate).Select(d => d.Key).ToList();
            foreach (TKey key in keysToRemove) {
                dictionary.Remove(key);
            }
        }

        public static void ForEach<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, Action<KeyValuePair<TKey, TValue>> action) {
            foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary) {
                action(keyValuePair);
            }
        }

    }
}