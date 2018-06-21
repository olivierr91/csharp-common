
using CSharpCommon.Extensions;
using System;

namespace CSharpCommon.Units {
    public class Volume : UnitAwareValue
    {
        private VolumeUnit _units;

        public Volume(decimal? value, VolumeUnit units): base(value, units) {
            if (units == VolumeUnit.None && value.HasValue && value != 0) {
                throw new ArgumentException($"Unit {units} is not valid for non-empty values.");
            }
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

        public static Volume operator +(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return new Volume(equalizedValues.Value1.Value + equalizedValues.Value2.Value, equalizedValues.Value1.Units);
        }
    
        public static decimal? operator /(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1.Value / equalizedValues.Value2.Value;
        }

        public static (Volume Value1, Volume Value2) Equalize(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return (value1, value2);
            } else if (value1.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(value1.Units));
            } else {
                return (value1.ConvertTo(value2.Units), value2);
            }
        }

        public static Volume Zero { get => new Volume(0, VolumeUnit.None); }
    }
}
