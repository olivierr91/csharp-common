
using CSharpCommon.Utils.Extensions;

namespace CSharpCommon.Utils.Units {
    public class Volume : UnitAwareValue
    {
        private VolumeUnit _units;

        public Volume(decimal? value, VolumeUnit units): base(value, units) {
            _value = value;
            _units = units;
        }

        public VolumeUnit Units { get => _units; }

        public Volume ConvertTo(VolumeUnit targetUnits) {
            return new Volume(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }

        public static Volume operator *(Volume value1, decimal? value2) {
            if (value2 == null) {
                return null;
            }
            return new Volume(value1.Value * value2, value1.Units);
        }

        public static Volume operator *(decimal? value1, Volume value2) {
            return value2 * value1;
        }

        public static decimal? operator /(Volume value1, Volume value2) {
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1.Value / equalizedValues.Value2.Value;
        }

        public static (Volume Value1, Volume Value2) Equalize(Volume value1, Volume value2) {
            if (value1.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(value1.Units));
            } else {
                return (value1.ConvertTo(value2.Units), value2);
            }
        }
    }
}
