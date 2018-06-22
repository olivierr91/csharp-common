using System;
using System.Collections.Generic;

namespace NoNameDev.CSharpCommon.Extensions.Collections {
    public static class IListExtensions
    {
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
    }
}
