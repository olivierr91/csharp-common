using CSharpCommon.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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

        protected static T FindKnownUnit<T>(Enum baseUnit, int baseUnitCount) {
            return FindKnownUnit<T>(new Dictionary<Enum, int>() { { baseUnit, baseUnitCount } });
        }

        protected static T FindKnownUnit<T>(Dictionary<Enum, int> baseUnits) {
            foreach (T enum_ in Enum.GetValues(typeof(T))) {
                if (GetBaseUnits(enum_ as Enum).DictionaryEquals(baseUnits)) {
                    return enum_;
                }
            }
            throw new ArgumentException($"A unit with the specified base units could not be found.");
        }

        protected static Dictionary<Enum, int> GetBaseUnits(Enum knownUnit) {
            return knownUnit.GetAttributes<UnitBaseAttribute>().ToDictionary(b => (Enum)Enum.Parse(b.BaseUnitType, b.BaseUnitValue.ToString()), b => b.BaseUnitCount);
        }

        protected static (T Units, int Count) GetBaseUnit<T>(Enum knownUnit) {
            return knownUnit.GetAttributes<UnitBaseAttribute>().Where(b => b.BaseUnitType == typeof(T))
                .Select(b => ((T)Enum.Parse(b.BaseUnitType, b.BaseUnitValue.ToString()), b.BaseUnitCount))
                .Single();
        }

    }
}
