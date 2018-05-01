using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.Extensions {
    public static class SortedSetExtensions {
        public static T1 BeforeLast<T1>(this SortedSet<T1> sortedSet) {
            if (sortedSet.Count < 2) {
                throw new InvalidOperationException("The list does not contain enough elements.");
            }
            return sortedSet.ElementAt(sortedSet.Count - 2);
        }

        public static T1 Random<T1>(this SortedSet<T1> sortedSet) {
            if (sortedSet.Count == 0) {
                throw new InvalidOperationException("The list is empty.");
            }
            return sortedSet.ElementAt(RandomUtils.Next(sortedSet.Count));
        }
    }
}