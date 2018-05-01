using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCommon.Utils.Extensions
{
    public static class HashSetExtensions
    {
        public static void ForEachPartition<T>(this HashSet<T> source, int partitonSize, Action<HashSet<T>> partition) {
            HashSet<T> partitionedSet = new HashSet<T>();
            foreach (T item in source) {
                partitionedSet.Add(item);
                if (partitionedSet.Count == partitonSize) {
                    partition(partitionedSet);
                    partitionedSet = new HashSet<T>();
                }
            }
            if (partitionedSet.Count > 0) {
                partition(partitionedSet);
            }
        }
    }
}
