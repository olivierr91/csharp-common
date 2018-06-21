using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Extensions.Collections {
    public static class IEnumerableExtensions
    {
        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] values) {
            return values.Any(v => source.Contains(v));
        }

        public static T FindMax<T, C>(this IEnumerable<T> source, Func<T, C> selector) {
            var maxValue = source.Max(x => selector);
            return source.First(x => selector == maxValue);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
        }

        public static void ForEachPartition<T>(this IEnumerable<T> source, int partitonSize, Action<HashSet<T>> partition) {
            HashSet<T> partitionedSet = new HashSet<T>();
            foreach (T item in source) {
                partitionedSet.Add(item);
                if (partitionedSet.Count == partitonSize) {
                    partition(partitionedSet);
                    partitionedSet = new HashSet<T>();
                }
            }
            if (partitionedSet.Count > 0) {
                partition(partitionedSet);
            }
        }
    }
}
