using System;
using System.Text;

namespace NoNameDev.CSharpCommon.Extensions.Text {

    public static class StringBuilderExtensions {

        public static StringBuilder Append(this StringBuilder stringBuilder, string appendValue, string delimiter) {
            if (String.IsNullOrEmpty(appendValue)) {
                return stringBuilder;
            } else if (stringBuilder.Length > 0) {
                stringBuilder.Append(delimiter);
                stringBuilder.Append(appendValue);
                return stringBuilder;
            } else {
                stringBuilder.Append(appendValue);
                return stringBuilder;
            }
        }
    }
}