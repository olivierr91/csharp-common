using CSharpCommon.Utils.Extensions;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units {
    public class UnitAwareValue
    {
        protected decimal _value;
        private UnitOfMeasure _knownUnit;

        public UnitAwareValue(decimal value, UnitOfMeasure units) {
            _value = value;
            _knownUnit = units;
        }

        public UnitAwareValue(UnitAwareValue value, UnitOfMeasure units) {
            _value = UnitConverter.Convert(value.Value, value.KnownUnit, units);
            _knownUnit = units;
        }

        public decimal Value { get => _value; }
        public UnitOfMeasure KnownUnit { get => _knownUnit; }

        public static UnitAwareValue operator *(UnitAwareValue value1, long value2) {
            return new UnitAwareValue(value1.Value * value2, value1.KnownUnit);
        }

        public static UnitAwareValue operator *(long value1, UnitAwareValue value2) {
            return value2 * value1;
        }

        public UnitAwareValue ConvertTo(UnitOfMeasure targetUnits) {
            return new UnitAwareValue(UnitConverter.Convert(_value, _knownUnit, targetUnits), targetUnits);
        }
    }
}
