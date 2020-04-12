using System;
using System.Collections.Generic;

namespace CSharpCommon.Extensions.Collections {

    public static class ArrayExtensions {

        public static List<T> ToList<T>(this Array array) {
            return new List<T>((T[])array);
        }
    }
}