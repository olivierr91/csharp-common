using System;
using System.Text;

namespace NoNameDev.CSharpCommon.Extensions.Text {
    public static class StringBuilderExtensions
    {
        public static StringBuilder Append(this StringBuilder stringBuilder, string value, string delimiter) {
            if (!String.IsNullOrWhiteSpace(value)) {
                stringBuilder.Append(delimiter);
                stringBuilder.Append(value);
            }
            return stringBuilder;
        }
    }
}
