using CSharpCommon.Extensions;
using System;

namespace CSharpCommon.Units {

    public class Area : UnitAwareValue {
        private AreaUnits _units;

        public Area(decimal? value, AreaUnits units) : base(value, units) {
            if (units == AreaUnits.None && value.HasValue && value != 0) {
                throw new ArgumentException($"Unit {units} is not valid for non-empty values.");
            }
            _value = value;
            _units = units;
        }

        public AreaUnits Units { get => _units; }

        public static (Area Value1, Length Value2) Equalize(Area value1, Length value2) {
            if (value1 == null || value2 == null) {
                return (value1, value2);
            }
            var baseUnit = GetBaseUnit<LengthUnits>(value1.Units);
            if (baseUnit.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(baseUnit.Units));
            } else {
                return (value1.ConvertTo(FindKnownUnit<AreaUnits>(value2.Units, 2)), value2);
            }
        }

        public static Volume operator *(Area value1, Length value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return new Volume(equalizedValues.Value1.Value * equalizedValues.Value2.Value, FindKnownUnit<VolumeUnits>(equalizedValues.Value2.Units, 3));
        }

        public Area ConvertTo(AreaUnits targetUnits) {
            return new Area(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }
    }
}