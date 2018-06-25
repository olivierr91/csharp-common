﻿using NoNameDev.CSharpCommon.Utils.Resources;

namespace NoNameDev.CSharpCommon.Units {
    public enum VolumeUnits
    {
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.None, baseUnitCount: 3)]
        [UnitPrecedence(8)]
        None = 0,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Meters, baseUnitCount: 3)]
        [UnitPrecedence(7)]
        CubicMeters = 1,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Yards, baseUnitCount: 3)]
        [UnitPrecedence(6)]
        CubicYards = 2,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Feet, baseUnitCount: 3)]
        [UnitPrecedence(5)]
        CubicFeet = 3,
        [UnitPrecedence(4)]
        BoardFeet = 4,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Inches, baseUnitCount: 3)]
        [UnitPrecedence(3)]
        CubicInches = 5,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Centimeters, baseUnitCount: 3)]
        [UnitPrecedence(2)]
        CubicCentimeters = 6,
        [UnitBase(baseUnitType: typeof(LengthUnits), baseUnitValue: (int)LengthUnits.Millimeters, baseUnitCount: 3)]
        [UnitPrecedence(1)]
        CubicMillimeters = 7,
    }

    public static class VolumeUnitExtensions {
        public static string GetAbbreviation(this VolumeUnits units) {
            return ResourceUtils.GetString(units, units.ToString() + "_Abbr");
        }
    }

}
