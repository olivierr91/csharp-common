using System;
using System.Collections.Generic;

namespace CSharpCommon.Extensions.Collections {

    public static class ListExtensions {

        public static void Sort<TSource, TKey>(this List<TSource> list, Func<TSource, TKey> keySelector) where TKey : IComparable {
            list.Sort((obj1, obj2) => keySelector(obj1).CompareTo(keySelector(obj2)));
        }

        public static void Sort<TSource, TKey>(this List<TSource> list, Func<TSource, TKey?> keySelector) where TKey : struct {
            list.Sort((obj1, obj2) => Nullable.Compare(keySelector(obj1), keySelector(obj2)));
        }
    }
}