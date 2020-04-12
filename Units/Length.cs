using CSharpCommon.Extensions;
using System;

namespace CSharpCommon.Units {

    public class Length : UnitAwareValue, IComparable, IComparable<Length> {
        private LengthUnits _units;

        public Length(decimal? value, LengthUnits units) : base(value, units) {
            if (units == LengthUnits.None && value.HasValue && value != 0) {
                throw new ArgumentException($"Unit {units} is not valid for non-empty values.");
            }
            _value = value;
            _units = units;
        }

        public LengthUnits Units { get => _units; }

        public static (Length Value1, Length Value2) Equalize(Length value1, Length value2) {
            if (value1 == null || value2 == null) {
                return (value1, value2);
            } else if (value1.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(value1.Units));
            } else {
                return (value1.ConvertTo(value2.Units), value2);
            }
        }

        public static bool operator !=(Length value1, Length value2) {
            return !(value1 == value2);
        }

        public static Area operator *(Length value1, Length value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return new Area(equalizedValues.Value1.Value * equalizedValues.Value2.Value, FindKnownUnit<AreaUnits>(equalizedValues.Value1.Units, 2));
        }

        public static bool operator ==(Length value1, Length value2) {
            if (ReferenceEquals(value1, null) && ReferenceEquals(value2, null)) {
                return true;
            } else if (ReferenceEquals(value1, null) || ReferenceEquals(value2, null)) {
                return false;
            }
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1?.Value == equalizedValues.Value2?.Value;
        }

        public int CompareTo(Length length) {
            var equalizedValues = Equalize(this, length);
            return Nullable.Compare(equalizedValues.Value1?.Value, equalizedValues.Value2?.Value);
        }

        public int CompareTo(object obj) {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentException($"Cannot compare to object {obj}.");

            return CompareTo((Length)obj);
        }

        public Length ConvertTo(LengthUnits targetUnits) {
            return new Length(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Length length = (Length)obj;
            var equalizedValues = Equalize(this, length);
            return equalizedValues.Value1?.Value == equalizedValues.Value2?.Value;
        }

        public override int GetHashCode() {
            return new HashCodeBuilder().Add(_value).Add(_units).GetHashCode();
        }
    }
}