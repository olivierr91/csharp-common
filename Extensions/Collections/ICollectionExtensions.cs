using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCommon.Utils.Extensions.Collections
{
    public static class ICollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) {
            foreach(T item in items) {
                collection.Add(item);
            }
        }

        public static void ExtendWithDefault<T>(this ICollection<T> collection, int index) {
            while (index + 1 > collection.Count) {
                collection.Add(default(T));
            }
        }
    }
}
