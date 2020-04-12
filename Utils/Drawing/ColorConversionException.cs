using System;

namespace CSharpCommon.Utils.Drawing {

    public class ColorConversionException : Exception {

        public ColorConversionException(string message, Exception ex) : base(message, ex) {
        }
    }
}