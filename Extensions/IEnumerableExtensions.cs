﻿using System;
using System.Collections.Generic;

namespace Common.Utils.Extensions {
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
        }
    }
}
