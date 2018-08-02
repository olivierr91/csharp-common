using System;
using System.Collections.Generic;

namespace NoNameDev.CSharpCommon.Extensions.Collections {

    public static class IListExtensions {

        public static void ExtendAndSetAt<T>(this IList<T> list, int index, T value) where T : class {
            if (index < 0) {
                throw new IndexOutOfRangeException();
            } else if (index > list.Count - 1) {
                list.ExtendWithDefault(list.Count - index + 1);
            }
            list[index] = value;
        }

        public static void ExtendAndSetAtIfNoExist<T>(this IList<T> list, int index, T value) where T : class {
            if (index < 0) {
                throw new IndexOutOfRangeException();
            } else if (index > list.Count - 1) {
                list.ExtendWithDefault(list.Count - index + 1);
                list[index] = value;
            }
        }
    }
}