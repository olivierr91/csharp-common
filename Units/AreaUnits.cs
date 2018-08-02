using NoNameDev.CSharpCommon.Utils.Resources;

namespace NoNameDev.CSharpCommon.Units {

    public enum AreaUnits {

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.None, baseUnitCount: 2)]
        [UnitPrecedence(7)]
        None = 0,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Meters, baseUnitCount: 2)]
        [UnitPrecedence(6)]
        SquareMeters = 1,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Yards, baseUnitCount: 2)]
        [UnitPrecedence(5)]
        SquareYards = 2,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Feet, baseUnitCount: 2)]
        [UnitPrecedence(4)]
        SquareFeet = 3,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Inches, baseUnitCount: 2)]
        [UnitPrecedence(3)]
        SquareInches = 4,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Centimeters, baseUnitCount: 2)]
        [UnitPrecedence(2)]
        SquareCentimeters = 5,

        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Millimeters, baseUnitCount: 2)]
        [UnitPrecedence(1)]
        SquareMillimeters = 6,
    }

    public static class AreaUnitExtensions {

        public static string GetAbbreviation(this AreaUnits units) {
            return ResourceUtils.GetString(units, units.ToString() + "_Abbr");
        }
    }
}