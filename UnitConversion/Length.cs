using CSharpCommon.Utils.Extensions;
using System;

namespace CSharpCommon.Utils.Units {
    public class Length : UnitAwareValue
    {
        private LengthUnits _units;

        public Length(decimal value, LengthUnits units): base(value, units) {
            _value = value;
            _units = units;
        }

        public LengthUnits Units { get => _units; }

        public Length ConvertTo(LengthUnits targetUnits) {
            return new Length(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }
    
        public static bool operator ==(Length value1, Length value2) {
            var equalizedValues = Equalize(value1, value2);
            return equalizedValues.Value1 == equalizedValues.Value2;
        }

        public static bool operator !=(Length value1, Length value2) {
            return !(value1 == value2);
        }

        public static Area operator *(Length value1, Length value2) {
            var equalizedValues = Equalize(value1, value2);
            return new Area(equalizedValues.Value1.Value * equalizedValues.Value2.Value, FindKnownUnit<AreaUnits>(equalizedValues.Value1.Units, 2));
        }

        public override int GetHashCode() {
            return new HashCodeBuilder().Add(_value).Add(_units).GetHashCode();
        }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Length length = (Length)obj;
            var equalizedValues = Equalize(this, length);
            return equalizedValues.Value1 == equalizedValues.Value2;
        }

        public static (Length Value1, Length Value2) Equalize(Length value1, Length value2) {
            if (value1.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(value1.Units));
            } else {
                return (value1.ConvertTo(value2.Units), value2);
            }
        }
    }
}
