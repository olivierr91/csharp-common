using System;

namespace CSharpCommon.Utils.Units {
    public class UnitAwareValue
    {
        protected decimal _value;
        private Enum _knownUnit;

        public UnitAwareValue(decimal value, Enum units) {
            _value = value;
            _knownUnit = units;
        }

        public UnitAwareValue(UnitAwareValue value, Enum units) {
            _value = UnitConverter.Convert(value.Value, value.KnownUnit, units);
            _knownUnit = units;
        }

        public decimal Value { get => _value; }
        public Enum KnownUnit { get => _knownUnit; }

        public static UnitAwareValue operator *(UnitAwareValue value1, long value2) {
            return new UnitAwareValue(value1.Value * value2, value1.KnownUnit);
        }

        public static UnitAwareValue operator *(long value1, UnitAwareValue value2) {
            return value2 * value1;
        }

        public UnitAwareValue ConvertTo(Enum targetUnits) {
            return new UnitAwareValue(UnitConverter.Convert(_value, _knownUnit, targetUnits), targetUnits);
        }

        public override string ToString() {
            return $"{_value} {_knownUnit}";
        }

        protected static (decimal value1, decimal value2, Enum commonUnit) MakeCommon(UnitAwareValue value1, UnitAwareValue value2) {
            return UnitConverter.MakeCommon(value1.Value, value1.KnownUnit, value2.Value, value2.KnownUnit);
        }
    }
}
