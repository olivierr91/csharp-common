using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units {
    public class Length : UnitAwareValue
    {
        private static readonly Dictionary<(Enum value1Source, Enum value2Source), (Enum value1Target, Enum value2Target, Enum result)> NON_LOSSY_MULTIPLICATIONS = new Dictionary<(Enum, Enum), (Enum, Enum, Enum)>() {
            { (LengthUnits.Feet, LengthUnits.Feet), (LengthUnits.Feet, LengthUnits.Feet, AreaUnits.SquareFeet) },
            { (LengthUnits.Feet, LengthUnits.Inches), (LengthUnits.Inches, LengthUnits.Inches, AreaUnits.SquareInches) },
            { (LengthUnits.Inches, LengthUnits.Feet), (LengthUnits.Inches, LengthUnits.Inches, AreaUnits.SquareFeet) },
            { (LengthUnits.Inches, LengthUnits.Inches), (LengthUnits.Inches, LengthUnits.Inches, AreaUnits.SquareInches) },
        };

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
            var commonValue = MakeCommonValue(value1, value2);
            return commonValue.value1 == commonValue.value2;
        }

        public static bool operator !=(Length value1, Length value2) {
            return !(value1 == value2);
        }

        public static Area operator *(Length value1, Length value2) {
            var multiplicationDefinition = NON_LOSSY_MULTIPLICATIONS[(value1.Units, value2.Units)];
            value1 = value1.ConvertTo((LengthUnits)multiplicationDefinition.value1Target);
            value2 = value2.ConvertTo((LengthUnits)multiplicationDefinition.value2Target);
            return new Area(value1.Value * value2.Value, (AreaUnits)multiplicationDefinition.result);
        }

        public override int GetHashCode() {
            return new HashCodeBuilder().Add(_value).Add(_units).GetHashCode();
        }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Length length = (Length)obj;
            var commonValue = MakeCommonValue(this, length);
            return commonValue.value1 == commonValue.value2;
        }
    }
}
