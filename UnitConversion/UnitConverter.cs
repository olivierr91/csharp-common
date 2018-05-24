using CSharpCommon.Utils.Extensions;
using System;

namespace CSharpCommon.Utils.Units {
    public class UnitConverter
    {
        public static decimal Convert(decimal value, UnitOfMeasure sourceUnit, UnitOfMeasure targetUnit) {
            if (sourceUnit == targetUnit) {
                return value;
            }
            ValidateConversion(sourceUnit, targetUnit);
            return value / 

            return value / (decimal)sourceUnit.GetAttribute<UnitDetailsAttribute>().IntermediateUnitConversionFactor * 
                (decimal)targetUnit.GetAttribute<UnitDetailsAttribute>().IntermediateUnitConversionFactor;
        }

        public static double Convert(double value, UnitOfMeasure sourceUnit, UnitOfMeasure targetUnit) {
            if (sourceUnit == targetUnit) {
                return value;
            }
            ValidateConversion(sourceUnit, targetUnit);
            return value / sourceUnit.GetAttribute<UnitDetailsAttribute>().IntermediateUnitConversionFactor * targetUnit.GetAttribute<UnitDetailsAttribute>().IntermediateUnitConversionFactor;
        }

        private static void ValidateConversion(UnitOfMeasure sourceUnit, UnitOfMeasure targetUnit) {
            if (sourceUnit.GetAttribute<UnitGroupAttribute>().EnumType != targetUnit.GetAttribute<UnitGroupAttribute>().EnumType) {
                throw new ArgumentException($"Cannot convert units from different groups ('{sourceUnit.GetAttribute<UnitGroupAttribute>().EnumType}' and '{targetUnit.GetAttribute<UnitGroupAttribute>().EnumType}').");
            }
        }
    }
}
