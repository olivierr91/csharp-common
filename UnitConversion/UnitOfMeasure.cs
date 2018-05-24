using CSharpCommon.Utils.Extensions;
using System;

namespace CSharpCommon.Utils.Units {

    public enum UnitOfMeasure {
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Meters)]
        Meters = 0,
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Yards)]
        Yards = 1,
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Feet)]
        Feet = 2,
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Inches)]
        Inches = 3,
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Centimeters)]
        Centimeters = 4,
        [UnitGroup(typeof(LengthUnits), specificUnitValue: (int)LengthUnits.Millimeters)]
        Millimeters = 5,
        [UnitGroup(typeof(VolumeUnits), specificUnitValue: (int)VolumeUnits.CubicMeters)]
        CubicMeters = 6,
        [UnitGroup(typeof(VolumeUnits), specificUnitValue: (int)VolumeUnits.CubicFeet)]
        CubicFeet = 7,
        [UnitGroup(typeof(VolumeUnits), specificUnitValue: (int)VolumeUnits.BoardFeet)]
        BoardFeet = 8,
        [UnitGroup(typeof(AreaUnits), specificUnitValue: (int)AreaUnits.SquareMeters)]
        SquareMeters = 9,
        [UnitGroup(typeof(AreaUnits), specificUnitValue: (int)AreaUnits.SquareFeet)]
        SquareFeet = 10,
        [UnitGroup(typeof(AreaUnits), specificUnitValue: (int)AreaUnits.SquareInches)]
        SquareInches = 11,
    }

    public class UnitGroupAttribute : Attribute {

        public Type EnumType { get; }
        public int SpecificUnitValue { get; }

        public UnitGroupAttribute(Type enumType, int specificUnitValue) {
            EnumType = enumType;
            SpecificUnitValue = specificUnitValue;
        }
    }

    public static class UnitOfMeasureExtensions {

        public decimal GetSIUnitConversionFactor(this UnitOfMeasure unitOfMeasure) {
            return unitOfMeasure.GetAttribute<UnitGroupAttribute>().EnumType.GetAttribute<>
        }
    }
}
