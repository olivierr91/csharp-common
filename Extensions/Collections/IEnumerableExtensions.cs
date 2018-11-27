using NoNameDev.CSharpCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoNameDev.CSharpCommon.Extensions.Collections {

    public static class IEnumerableExtensions {

        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] values) {
            return values.Any(v => source.Contains(v));
        }

        public static T FindMax<T, C>(this IEnumerable<T> source, Func<T, C> selector) where C : IComparable<C> {
            return source.Aggregate((i1, i2) => selector(i1).CompareTo(selector(i2)) > 0 ? i1 : i2);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action) {
            int index = 0;
            foreach (var item in source) {
                action(item, index);
                index++;
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

        public static IEnumerable<T> ForEachThenReturn<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
            return source;
        }

        public static string JoinString(this IEnumerable<string> source, string separator) {
            return String.Join(separator, source);
        }

        public static T RandomElement<T>(this IEnumerable<T> list) {
            return RandomUtils.RandomElement(list);
        }

        public static IEnumerable<TResult> SelectDistinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            return source.GroupBy(selector).Select(g => g.Key);
        }

        public static IEnumerable<IGrouping<TSourceKey, IGrouping<TKey, TSource>>> ThenBy<TSource, TKey, TSourceKey>(this IEnumerable<IGrouping<TSourceKey, TSource>> source, Func<TSource, TKey> keySelector) {
            return source
                .SelectMany(g => g.GroupBy(keySelector), (grp1, grp2) => (grp1, grp2))
                .GroupBy(temp0 => temp0.grp1.Key, temp0 => temp0.grp2);
        }

        public static OrderedSet<T> ToOrderedSet<T>(this IEnumerable<T> source) {
            return new OrderedSet<T>(source);
        }
    }
}