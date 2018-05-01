using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CSharpCommon.Utils.Extensions {
    public static class ListExtensions
    {
        public static void Add<T>(this List<T> list, params T[] items) {
            foreach (T item in items) {
                list.Add(item);
            }
        }

        public static void Sort<TSource, TKey>(this List<TSource> list, Func<TSource, TKey> keySelector) where TKey : IComparable {
            list.Sort((obj1, obj2) => keySelector(obj1).CompareTo(keySelector(obj2)));
        }
    }
}
