using NoNameDev.CSharpCommon.Extensions;
using System;

namespace NoNameDev.CSharpCommon.Units {

    public class Volume : UnitAwareValue {
        private VolumeUnits _units;

        public Volume(decimal? value, VolumeUnits units) : base(value, units) {
            if (units == VolumeUnits.None && value.HasValue && value != 0) {
                throw new ArgumentException($"Unit {units} is not valid for non-empty values.");
            }
            _value = value;
            _units = units;
        }

        public static Volume Zero { get => new Volume(0, VolumeUnits.None); }
        public VolumeUnits Units { get => _units; }

        public static (Volume Value1, Volume Value2) Equalize(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return (value1, value2);
            } else if (value1.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(value1.Units));
            } else {
                return (value1.ConvertTo(value2.Units), value2);
            }
        }

        public static bool operator !=(Volume value1, Volume value2) {
            return !(value1 == value2);
        }

        public static Volume operator *(Volume value1, decimal? value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            return new Volume(value1.Value * value2, value1.Units);
        }

        public static Volume operator *(decimal? value1, Volume value2) {
            return value2 * value1;
        }

        public static decimal? operator /(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1.Value / equalizedValues.Value2.Value;
        }

        public static Volume operator +(Volume value1, Volume value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return new Volume(equalizedValues.Value1.Value + equalizedValues.Value2.Value, equalizedValues.Value1.Units);
        }

        public static bool operator ==(Volume value1, Volume value2) {
            if (ReferenceEquals(value1, null) && ReferenceEquals(value2, null)) {
                return true;
            } else if (ReferenceEquals(value1, null) || ReferenceEquals(value2, null)) {
                return false;
            }
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1?.Value == equalizedValues.Value2?.Value;
        }

        public Volume ConvertTo(VolumeUnits targetUnits) {
            return new Volume(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Volume volume = (Volume)obj;
            var equalizedValues = Equalize(this, volume);
            return equalizedValues.Value1?.Value == equalizedValues.Value2?.Value;
        }

        public override int GetHashCode() {
            return new HashCodeBuilder().Add(_value).Add(_units).GetHashCode();
        }
    }
}