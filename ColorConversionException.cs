using System;

namespace Common.Utils {
    public class ColorConversionException : Exception
    {
        public ColorConversionException(string message, Exception ex) : base(message, ex) { }
    }
}
