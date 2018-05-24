
using System;

namespace CSharpCommon.Utils.Units
{
    public class Volume : UnitAwareValue
    {
        private VolumeUnits _units;

        public Volume(decimal value, VolumeUnits units): base(value, (UnitOfMeasure)units) {
            _value = value;
            _units = units;
        }

        public VolumeUnits Units { get => _units; }

        public Volume ConvertTo(VolumeUnits targetUnits) {
            return new Volume(UnitConverter.Convert(_value, (UnitOfMeasure)_units, (UnitOfMeasure)targetUnits), targetUnits);
        }

        public static Volume operator *(Volume value1, decimal value2) {
            return new Volume(value1.Value * value2, value1.Units);
        }

        public static Volume operator *(decimal value1, Volume value2) {
            return value2 * value1;
        }

        public static decimal operator /(Volume value1, Volume value2) {
            return value1.Value / value2.ConvertTo(value1.Units).Value;
        }

        public Volume ToBoardFeet() {
            return new Volume(UnitConverter.Convert(_value, (UnitOfMeasure)_units, (UnitOfMeasure)VolumeUnits.BoardFeet), VolumeUnits.BoardFeet);
        }
    }
}
