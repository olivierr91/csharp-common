
using System;

namespace CSharpCommon.Utils.Units
{
    public class Area : UnitAwareValue
    {
        private AreaUnits _units;

        public Area(decimal value, AreaUnits units): base(value, (UnitOfMeasure)units) {
            _value = value;
            _units = units;
        }

        public AreaUnits Units { get => _units; }

        public static Volume operator *(Area value1, Length value2) {
            decimal value;
            VolumeUnits units;
            switch (value1.Units) {
                case AreaUnits.SquareFeet:
                    value = value1.Value * value2.ConvertTo(LengthUnits.Feet).Value;
                    units = VolumeUnits.CubicFeet;
                    break;
                case AreaUnits.SquareMeters:
                    value = value1.Value * value2.ConvertTo(LengthUnits.Meters).Value;
                    units = VolumeUnits.CubicMeters;
                    break;
                default:
                    throw new NotImplementedException($"Length multiplication of {value1.Units}, {value2.Units} is not defined.");
            }
            return new Volume(value, units);
        }
    }
}
