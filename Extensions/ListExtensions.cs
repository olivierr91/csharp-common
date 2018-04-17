using System.Collections.Generic;

namespace Common.Utils.Extensions {
    public static class ListExtensions
    {
        public static void Add<T>(this List<T> list, params T[] items) {
            foreach (T item in items) {
                list.Add(item);
            }
        }
    }
}
