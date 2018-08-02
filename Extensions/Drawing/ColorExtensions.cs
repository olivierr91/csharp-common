using System.Drawing;

namespace NoNameDev.CSharpCommon.Extensions.Drawing {

    public static class ColorExtensions {

        public static string ToHex(this Color color) {
            if (color.A != 1) {
                return $"#{color.R:2X}{color.G:2X}{color.B:2X}{color.A:2X}";
            } else {
                return $"#{color.R:2X}{color.G:2X}{color.B:2X}";
            }
        }
    }
}