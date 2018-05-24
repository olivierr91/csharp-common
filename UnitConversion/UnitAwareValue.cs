using CSharpCommon.Utils.Extensions;
using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units {
    public abstract class UnitAwareValue
    {
        protected decimal _value;
        private Enum _knownUnit;

        public UnitAwareValue(decimal value, Enum knownUnit) {
            _value = value;
            _knownUnit = knownUnit;
        }

        public Enum KnownUnit { get => _knownUnit; }
        public decimal Value { get => _value; }

        public override string ToString() {
            return $"{_value} {KnownUnit.ToString()}";
        }

        protected static (decimal value1, decimal value2, Enum commonUnit) MakeCommonValue(UnitAwareValue value1, UnitAwareValue value2) {
            return UnitConverter.MakeCommonValue(value1.Value, value1.KnownUnit, value2.Value, value2.KnownUnit);
        }
    }
}
