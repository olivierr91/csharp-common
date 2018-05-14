using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCommon.Utils.Extensions
{
    public static class ICollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) {
            foreach(T item in items) {
                collection.Add(item);
            }
        }
    }
}
