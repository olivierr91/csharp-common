using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Units.Extensions {

    public static class VolumeExtensions {

        public static Volume Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Volume> selector) {
            return source.Select(selector).Aggregate(Volume.Zero, (left, right) => left + right);
        }
    }
}