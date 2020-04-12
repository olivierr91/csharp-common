using System.Drawing;

namespace CSharpCommon.Extensions.Drawing {

    public static class ColorExtensions {

        public static string ToHex(this Color color) {
            if (color.A != 0) {
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
            } else {
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
        }
    }
}