using NoNameDev.CSharpCommon.Utils.Resources;

namespace NoNameDev.CSharpCommon.Units {
    public enum LengthUnits {
        [UnitPrecedence(7)]
        None = 0,
        [UnitPrecedence(6)]
        Meters = 1,
        [UnitPrecedence(5)]
        Yards = 2,
        [UnitPrecedence(4)]
        Feet = 3,
        [UnitPrecedence(3)]
        Inches = 4,
        [UnitPrecedence(2)]
        Centimeters = 5,
        [UnitPrecedence(1)]
        Millimeters = 6,
    }

    public static class LengthUnitExtensions {
        public static string GetAbbreviation(this LengthUnits units) {
            return ResourceUtils.GetString(units, units.ToString() + "_Abbr");
        }
    }
}
