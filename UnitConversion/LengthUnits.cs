namespace CSharpCommon.Utils.Units {
    public enum LengthUnits {
        [UnitDetails(siUnitConversionFactor: 1)]
        Meters = 0,
        [UnitDetails(siUnitConversionFactor: 1.093613)]
        Yards = 1,
        [UnitDetails(siUnitConversionFactor: 3.2808)]
        Feet = 2,
        [UnitDetails(siUnitConversionFactor: 39.37008)]
        Inches = 3,
        [UnitDetails(siUnitConversionFactor: 100)]
        Centimeters = 4,
        [UnitDetails(siUnitConversionFactor: 1000)]
        Millimeters = 5,
    }
}
