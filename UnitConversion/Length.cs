
using CSharpCommon.Utils.Extensions;
using System;

namespace CSharpCommon.Utils.Units
{
    public class Length : UnitAwareValue
    {
        private LengthUnits _units;

        public Length(decimal value, LengthUnits units): base(value, (UnitOfMeasure)units) {
            _value = value;
            _units = units;
        }

        public LengthUnits Units { get => _units; }

        public Length ConvertTo(LengthUnits targetUnits) {
            return new Length(UnitConverter.Convert(_value, (UnitOfMeasure)_units, (UnitOfMeasure)targetUnits), targetUnits);
        }

        public static Area operator *(Length value1, Length value2) {
            decimal value;
            AreaUnits units;
            switch (value1.Units) {
                case LengthUnits.Meters:
                    value = value1.Value * value2.ConvertTo(LengthUnits.Meters).Value;
                    units = AreaUnits.SquareMeters;
                    break;
                case LengthUnits.Feet:
                    value = value1.Value * value2.ConvertTo(LengthUnits.Feet).Value;
                    units = AreaUnits.SquareFeet;
                    break;
                case LengthUnits.Inches:
                    value = value1.Value * value2.ConvertTo(LengthUnits.Inches).Value;
                    units = AreaUnits.SquareFeet;
                    break;
                default:
                    throw new NotImplementedException($"Length multiplication of {value1.Units}, {value2.Units} is not defined.");
            }
            return new Area(value, units);
        }

        public Length ToFeet() {
            return new Length(UnitConverter.Convert(_value, (UnitOfMeasure)_units, (UnitOfMeasure)LengthUnits.Feet), LengthUnits.Feet);
        }

        public Length ToInches() {
            return new Length(UnitConverter.Convert(_value, (UnitOfMeasure)_units, (UnitOfMeasure)LengthUnits.Inches), LengthUnits.Inches);
        }
    }
}
