
using CSharpCommon.Utils.Extensions;
using System;

namespace CSharpCommon.Utils.Units
{
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
            var commonValue = MakeCommon(value1, value2);
            return commonValue.value1 == commonValue.value2;
        }

        public static bool operator !=(Length value1, Length value2) {
            return !(value1 == value2);
        }

        public static Area operator *(Length value1, Length value2) {
            var commonValue = MakeCommon(value1, value2);
            AreaUnits units;
            switch (commonValue.commonUnit) {
                case LengthUnits.Meters:
                    units = AreaUnits.SquareMeters;
                    break;
                case LengthUnits.Feet:
                    units = AreaUnits.SquareFeet;
                    break;
                case LengthUnits.Inches:
                    units = AreaUnits.SquareInches;
                    break;
                default:
                    throw new NotImplementedException($"Length multiplication of {value1.Units}, {value2.Units} is not defined.");
            }
            return new Area(commonValue.value1 * commonValue.value2, units);
        }

        public Length ToFeet() {
            return new Length(UnitConverter.Convert(_value, _units, LengthUnits.Feet), LengthUnits.Feet);
        }

        public Length ToInches() {
            return new Length(UnitConverter.Convert(_value, _units, LengthUnits.Inches), LengthUnits.Inches);
        }
    }
}
