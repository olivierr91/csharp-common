using System.Collections.Generic;

namespace CSharpCommon.Utils.Extensions {
    public static class IListExtensions
    {
        public static void Add<T>(this IList<T> list, params T[] items) {
            foreach (T item in items) {
                list.Add(item);
            }
        }

        public static T TryGet<T>(this IList<T> collection, int index) where T : class {
            if (index < 0 || index > collection.Count - 1) {
                return null;
            } else {
                return collection[index];
            }
        }
    }
}
