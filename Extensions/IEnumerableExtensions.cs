using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
        }

        public static T FindMax<T, C>(this IEnumerable<T> source, Func<T, C> selector) {
            var maxValue = source.Max(x => selector);
            return source.First(x => selector == maxValue);
        }
    }
}
