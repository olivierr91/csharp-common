
using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units
{
    public class Area : UnitAwareValue
    {

        private static readonly Dictionary<(Enum value1Source, Enum value2Source), (Enum value1Target, Enum value2Target, Enum result)> MULTIPLICATIONS_DEFINITIONS 
            = new Dictionary<(Enum, Enum), (Enum, Enum, Enum)>() {
            { (AreaUnits.SquareFeet, LengthUnits.Feet), (AreaUnits.SquareFeet, LengthUnits.Feet, VolumeUnits.CubicFeet) },
            { (AreaUnits.SquareFeet, LengthUnits.Inches), (AreaUnits.SquareInches, LengthUnits.Inches, VolumeUnits.CubicInches) },
            { (AreaUnits.SquareInches, LengthUnits.Feet), (AreaUnits.SquareInches, LengthUnits.Inches, VolumeUnits.CubicInches) },
            { (AreaUnits.SquareInches, LengthUnits.Inches), (AreaUnits.SquareInches, LengthUnits.Inches, VolumeUnits.CubicInches) },
        };

        private AreaUnits _units;

        public Area(decimal value, AreaUnits units): base(value, units) {
            _value = value;
            _units = units;
        }

        public AreaUnits Units { get => _units; }

        public Area ConvertTo(AreaUnits targetUnits) {
            return new Area(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }
    
        public static Volume operator *(Area value1, Length value2) {
            var multiplicationDefinition = MULTIPLICATIONS_DEFINITIONS[(value1.Units, value2.Units)];
            value1 = value1.ConvertTo((AreaUnits)multiplicationDefinition.value1Target);
            value2 = value2.ConvertTo((LengthUnits)multiplicationDefinition.value2Target);
            return new Volume(value1.Value * value2.Value, (VolumeUnits)multiplicationDefinition.result);
        }
    }
}
