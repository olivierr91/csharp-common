
using System;

namespace CSharpCommon.Utils.Units
{
    public class Volume : UnitAwareValue
    {
        private VolumeUnits _units;

        public Volume(decimal value, VolumeUnits units): base(value, units) {
            _value = value;
            _units = units;
        }

        public VolumeUnits Units { get => _units; }

        public Volume ConvertTo(VolumeUnits targetUnits) {
            return new Volume(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }

        public static Volume operator *(Volume value1, decimal? value2) {
            if (value2 == null) {
                return null;
            } else {
                return new Volume(value1.Value * value2.Value, value1.Units);
            }
        }

        public static Volume operator *(decimal? value1, Volume value2) {
            return value2 * value1;
        }

        public static decimal operator /(Volume value1, Volume value2) {
            var commonValue = MakeCommonValue(value1, value2);
            return commonValue.value1 / commonValue.value2;
        }
    }
}
