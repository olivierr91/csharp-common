﻿using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units {
    public class UnitConverter
    {
        private static readonly Dictionary<(Enum source, Enum target), decimal> EXACT_CONVERSIONS = new Dictionary<(Enum, Enum), decimal>() {
            { (AreaUnits.SquareMeters, AreaUnits.SquareInches), 1550 },
            { (AreaUnits.SquareFeet, AreaUnits.SquareInches), 144m },
            { (LengthUnits.Feet, LengthUnits.Inches), 12m },
            { (VolumeUnits.CubicFeet, VolumeUnits.CubicInches), 1728m },
            { (VolumeUnits.BoardFeet, VolumeUnits.CubicInches), 144m },
        };

        public static (decimal value1, decimal value2, Enum commonUnit) MakeCommonValue(decimal value1, Enum value1Units, decimal value2, Enum value2Units) {
            var preferredUnit = GetPreferredCommonUnit(value1Units, value2Units);
            return (Convert(value1, value1Units, preferredUnit), Convert(value2, value2Units, preferredUnit), preferredUnit);
        }

        public static decimal Convert(decimal value, Enum sourceUnits, Enum targetUnits) {
            if (Equals(sourceUnits, targetUnits)) {
                return value;
            }
            if (EXACT_CONVERSIONS.ContainsKey((sourceUnits, targetUnits))) {
                return value * EXACT_CONVERSIONS[(sourceUnits, targetUnits)];
            } else if (EXACT_CONVERSIONS.ContainsKey((targetUnits, sourceUnits))) {
                return value / EXACT_CONVERSIONS[(targetUnits, sourceUnits)];
            } else {
                throw new ArgumentException($"Conversion between '{sourceUnits}' and '{targetUnits}' is not defined.");
            }
        }

        public static Enum GetPreferredCommonUnit(Enum value1Units, Enum value2Units) {
            if (Equals(value1Units, value2Units)) {
                return value1Units;
            } else if (EXACT_CONVERSIONS.ContainsKey((value1Units, value2Units))) {
                return value2Units;
            } else if (EXACT_CONVERSIONS.ContainsKey((value2Units, value1Units))) {
                return value1Units;
            } else {
                return value1Units;
            }
        }

        public static double Convert(double value, Enum sourceUnit, Enum targetUnit) {
            if (Equals(sourceUnit, targetUnit)) {
                return value;
            }
            if (EXACT_CONVERSIONS.ContainsKey((sourceUnit, targetUnit))) {
                return value * (double)EXACT_CONVERSIONS[(sourceUnit, targetUnit)];
            } else if (EXACT_CONVERSIONS.ContainsKey((targetUnit, sourceUnit))) {
                return value / (double)EXACT_CONVERSIONS[(targetUnit, sourceUnit)];
            } else {
                throw new ArgumentException($"Conversion between '{sourceUnit.GetType()}' and '{targetUnit.GetType()}' is not defined.");
            }
        }
    }
}
