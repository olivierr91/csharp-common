using System;

namespace NoNameDev.CSharpCommon.Extensions {

    public static class ArrayExtensions {

        public static void ForEach<T>(this T[] array, Action<T, int> action) {
            for (int i = 0; i < array.Length; i++) {
                action(array[i], i);
            }
        }
    }
}