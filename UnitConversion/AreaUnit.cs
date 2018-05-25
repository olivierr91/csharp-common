using System;

namespace CSharpCommon.Utils.Units {
    public enum AreaUnit
    {
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Meters, baseUnitCount: 2)]
        [UnitPrecedence(6)]
        SquareMeters = 1,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Yards, baseUnitCount: 2)]
        [UnitPrecedence(5)]
        SquareYards = 4,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Feet, baseUnitCount: 2)]
        [UnitPrecedence(4)]
        SquareFeet = 2,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Inches, baseUnitCount: 2)]
        [UnitPrecedence(3)]
        SquareInches = 3,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Centimeters, baseUnitCount: 2)]
        [UnitPrecedence(2)]
        SquareCentimeters = 5,
        [UnitBase(baseUnitType: typeof(LengthUnit), baseUnitValue: (int)LengthUnit.Millimeters, baseUnitCount: 2)]
        [UnitPrecedence(1)]
        SquareMillimeters = 6,
    }

}
