namespace CSharpCommon.Utils.Units {
    public enum VolumeUnit
    {
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Meters, baseUnitCount: 3)]
        [UnitPrecedence(4)]
        CubicMeters = 0,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Yards, baseUnitCount: 3)]
        [UnitPrecedence(4)]
        CubicYards = 4,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Feet, baseUnitCount: 3)]
        [UnitPrecedence(3)]
        CubicFeet = 1,
        [UnitPrecedence(2)]
        BoardFeet = 3,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Inches, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicInches = 2,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Centimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicCentimeters = 5,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Millimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicMillimeters = 6,
    }

}
