namespace CSharpCommon.Utils.Units {
    public enum VolumeUnits
    {
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Meters, baseUnitCount: 3)]
        [UnitPrecedence(4)]
        CubicMeters = 0,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Yards, baseUnitCount: 3)]
        [UnitPrecedence(4)]
        CubicYards = 4,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Feet, baseUnitCount: 3)]
        [UnitPrecedence(3)]
        CubicFeet = 1,
        [UnitPrecedence(2)]
        BoardFeet = 3,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Inches, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicInches = 2,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Centimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicCentimeters = 5,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Millimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicMillimeters = 6,
    }

}
