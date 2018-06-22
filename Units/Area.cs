
using NoNameDev.CSharpCommon.Extensions;
using System;

namespace NoNameDev.CSharpCommon.Units
{
    public class Area : UnitAwareValue
    {
        private AreaUnit _units;

        public Area(decimal? value, AreaUnit units): base(value, units) {
            if (units == AreaUnit.None && value.HasValue && value != 0) {
                throw new ArgumentException($"Unit {units} is not valid for non-empty values.");
            }
            _value = value;
            _units = units;
        }

        public AreaUnit Units { get => _units; }

        public Area ConvertTo(AreaUnit targetUnits) {
            return new Area(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }
    
        public static Volume operator *(Area value1, Length value2) {
            if (value1 == null || value2 == null) {
                return null;
            }
            var equalizedValues = Equalize(value1, value2);
            return new Volume(equalizedValues.Value1.Value * equalizedValues.Value2.Value, FindKnownUnit<VolumeUnit>(equalizedValues.Value2.Units, 3));
        }

        public static (Area Value1, Length Value2) Equalize(Area value1, Length value2) {
            if (value1 == null || value2 == null) {
                return (value1, value2);
            }
            var baseUnit = GetBaseUnit<LengthUnit>(value1.Units);
            if (baseUnit.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(baseUnit.Units));
            } else {
                return (value1.ConvertTo(FindKnownUnit<AreaUnit>(value2.Units, 2)), value2);
            }
        }
    }
}
