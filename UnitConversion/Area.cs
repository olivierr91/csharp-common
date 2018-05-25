﻿
using CSharpCommon.Utils.Extensions;

namespace CSharpCommon.Utils.Units
{
    public class Area : UnitAwareValue
    {
        private AreaUnits _units;

        public Area(decimal value, AreaUnits units): base(value, units) {
            _value = value;
            _units = units;
        }

        public AreaUnits Units { get => _units; }

        public Area ConvertTo(AreaUnits targetUnits) {
            return new Area(UnitConverter.Convert(_value, _units, targetUnits), targetUnits);
        }
    
        public static Volume operator *(Area value1, Length value2) {
            var equalizedValues = Equalize(value1, value2);
            return new Volume(equalizedValues.Value1.Value * equalizedValues.Value2.Value, FindKnownUnit<VolumeUnits>(equalizedValues.Value2.Units, 3));
        }

        public static (Area Value1, Length Value2) Equalize(Area value1, Length value2) {
            var baseUnit = GetBaseUnit<LengthUnits>(value1.Units);
            if (baseUnit.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence < value2.Units.GetAttribute<UnitPrecedenceAttribute>().Precedence) {
                return (value1, value2.ConvertTo(baseUnit.Units));
            } else {
                return (value1.ConvertTo(FindKnownUnit<AreaUnits>(value2.Units, 2)), value2);
            }
        }
    }
}
