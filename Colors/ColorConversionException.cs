using System;

namespace CSharpCommon.Utils.Colors {
    public class ColorConversionException : Exception
    {
        public ColorConversionException(string message, Exception ex) : base(message, ex) { }
    }
}
