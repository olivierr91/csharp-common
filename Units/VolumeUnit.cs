namespace CSharpCommon.Units {
    public enum VolumeUnit
    {
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.None, baseUnitCount: 3)]
        [UnitPrecedence(8)]
        None = 0,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Meters, baseUnitCount: 3)]
        [UnitPrecedence(7)]
        CubicMeters = 1,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Yards, baseUnitCount: 3)]
        [UnitPrecedence(6)]
        CubicYards = 2,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Feet, baseUnitCount: 3)]
        [UnitPrecedence(5)]
        CubicFeet = 3,
        [UnitPrecedence(4)]
        BoardFeet = 4,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Inches, baseUnitCount: 3)]
        [UnitPrecedence(3)]
        CubicInches = 5,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Centimeters, baseUnitCount: 3)]
        [UnitPrecedence(2)]
        CubicCentimeters = 6,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Millimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicMillimeters = 7,
    }

}
