using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Extensions {
    public static class IListExtensions
    {
        public static void Add<T>(this IList<T> list, params T[] items) {
            foreach (T item in items) {
                list.Add(item);
            }
        }

        public static void ExtendAndSetAtIfNoExist<T>(this IList<T> collection, int index, T value) where T : class {
            if (index < 0) {
                throw new IndexOutOfRangeException();
            } else if (index > collection.Count - 1) {
                collection.ExtendWithDefault(collection.Count - index + 1);
                collection[index] = value;
            }
        }

        public static void ExtendAndSetAt<T>(this IList<T> collection, int index, T value) where T : class {
            if (index < 0) {
                throw new IndexOutOfRangeException();
            } else if (index > collection.Count - 1) {
                collection.ExtendWithDefault(collection.Count - index + 1);
            }
            collection[index] = value;
        }

        public static void ExtendWithDefault<T>(this IList<T> collection, int index) {
            while (index + 1 > collection.Count) {
                collection.Add(default(T));
            }
        }
    }
}
