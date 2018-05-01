using System;
using System.Drawing;

namespace CSharpCommon.Utils.Colors {
    public static class ColorUtils
    {
        public static Color FromHex(string hex) {
            hex = hex.TrimStart('#');
            try {
                return Color.FromArgb(Convert.ToInt32(hex, 16));
            } catch (Exception ex) {
                throw new ColorConversionException($"'{hex}' cannot be parsed to a color.", ex);
            }
        }
    }
}
