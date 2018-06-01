using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Units {
    public class UnitConverter
    {
        private static readonly Dictionary<(Enum source, Enum target), decimal> CONVERSIONS = new Dictionary<(Enum, Enum), decimal>() {
            { (LengthUnit.Meters, LengthUnit.None), 1 },
            { (LengthUnit.Meters, LengthUnit.Yards), 1.09361m },
            { (LengthUnit.Meters, LengthUnit.Feet), 3.28084m },
            { (LengthUnit.Meters, LengthUnit.Inches), 39.3701m },
            { (LengthUnit.Meters, LengthUnit.Centimeters), 100 },
            { (LengthUnit.Meters, LengthUnit.Millimeters), 1000 },
            { (LengthUnit.Yards, LengthUnit.None), 1 },
            { (LengthUnit.Yards, LengthUnit.Feet), 3 },
            { (LengthUnit.Yards, LengthUnit.Inches), 36 },
            { (LengthUnit.Yards, LengthUnit.Centimeters), 91.44m },
            { (LengthUnit.Yards, LengthUnit.Millimeters), 914.4m },
            { (LengthUnit.Feet, LengthUnit.None), 1 },
            { (LengthUnit.Feet, LengthUnit.Inches), 12 },
            { (LengthUnit.Feet, LengthUnit.Centimeters), 30.48m },
            { (LengthUnit.Feet, LengthUnit.Millimeters), 304.8m },
            { (LengthUnit.Inches, LengthUnit.None), 1 },
            { (LengthUnit.Inches, LengthUnit.Centimeters), 2.54m },
            { (LengthUnit.Inches, LengthUnit.Millimeters), 25.4m },
            { (LengthUnit.Centimeters, LengthUnit.None), 1 },
            { (LengthUnit.Centimeters, LengthUnit.Millimeters), 10 },
            { (AreaUnit.SquareMeters, AreaUnit.None), 1 },
            { (AreaUnit.SquareMeters, AreaUnit.SquareYards), 1.19599m },
            { (AreaUnit.SquareMeters, AreaUnit.SquareFeet), 10.7639m },
            { (AreaUnit.SquareMeters, AreaUnit.SquareInches), 1550 },
            { (AreaUnit.SquareMeters, AreaUnit.SquareCentimeters), 10000 },
            { (AreaUnit.SquareMeters, AreaUnit.SquareMillimeters), 1000000 },
            { (AreaUnit.SquareYards, AreaUnit.None), 1 },
            { (AreaUnit.SquareYards, AreaUnit.SquareFeet), 9 },
            { (AreaUnit.SquareYards, AreaUnit.SquareInches), 1296 },
            { (AreaUnit.SquareYards, AreaUnit.SquareCentimeters), 8361.27m },
            { (AreaUnit.SquareYards, AreaUnit.SquareMillimeters), 836127 },
            { (AreaUnit.SquareFeet, AreaUnit.None), 1 },
            { (AreaUnit.SquareFeet, AreaUnit.SquareInches), 144 },
            { (AreaUnit.SquareFeet, AreaUnit.SquareCentimeters), 929.03m },
            { (AreaUnit.SquareFeet, AreaUnit.SquareMillimeters), 92903 },
            { (AreaUnit.SquareInches, AreaUnit.None), 1 },
            { (AreaUnit.SquareInches, AreaUnit.SquareCentimeters), 6.4516m },
            { (AreaUnit.SquareInches, AreaUnit.SquareMillimeters), 645.16m },
            { (AreaUnit.SquareCentimeters, AreaUnit.None), 1 },
            { (AreaUnit.SquareCentimeters, AreaUnit.SquareMillimeters), 100 },
            { (VolumeUnit.CubicMeters, VolumeUnit.None), 1 },
            { (VolumeUnit.CubicMeters, VolumeUnit.CubicYards), 1.30795m },
            { (VolumeUnit.CubicMeters, VolumeUnit.CubicFeet), 35.3147m },
            { (VolumeUnit.CubicMeters, VolumeUnit.BoardFeet), 423.776m },
            { (VolumeUnit.CubicMeters, VolumeUnit.CubicInches), 61023.7m },
            { (VolumeUnit.CubicMeters, VolumeUnit.CubicCentimeters), 1000000 },
            { (VolumeUnit.CubicMeters, VolumeUnit.CubicMillimeters), 1e+9m },
            { (VolumeUnit.CubicYards, VolumeUnit.None), 1 },
            { (VolumeUnit.CubicYards , VolumeUnit.CubicFeet), 27 },
            { (VolumeUnit.CubicYards, VolumeUnit.BoardFeet), 324 },
            { (VolumeUnit.CubicYards, VolumeUnit.CubicInches), 46656 },
            { (VolumeUnit.CubicYards, VolumeUnit.CubicCentimeters), 764555 },
            { (VolumeUnit.CubicYards, VolumeUnit.CubicMillimeters), 7.646e+8m },
            { (VolumeUnit.CubicFeet, VolumeUnit.None), 1 },
            { (VolumeUnit.CubicFeet, VolumeUnit.BoardFeet), 12 },
            { (VolumeUnit.CubicFeet, VolumeUnit.CubicInches), 1728 },
            { (VolumeUnit.CubicFeet, VolumeUnit.CubicCentimeters), 28316.8m },
            { (VolumeUnit.CubicFeet, VolumeUnit.CubicMillimeters), 2.832e+7m },
            { (VolumeUnit.BoardFeet, VolumeUnit.None), 1 },
            { (VolumeUnit.BoardFeet, VolumeUnit.CubicInches), 144 },
            { (VolumeUnit.BoardFeet, VolumeUnit.CubicCentimeters), 2359.74m },
            { (VolumeUnit.BoardFeet, VolumeUnit.CubicMillimeters), 2.36e+6m },
            { (VolumeUnit.CubicInches, VolumeUnit.None), 1 },
            { (VolumeUnit.CubicInches, VolumeUnit.CubicCentimeters), 16.3871m },
            { (VolumeUnit.CubicInches, VolumeUnit.CubicMillimeters), 16387.1m },
            { (VolumeUnit.CubicCentimeters, VolumeUnit.None), 1 },
            { (VolumeUnit.CubicCentimeters, VolumeUnit.CubicMillimeters), 1000 },
        };

        public static decimal? Convert(decimal? value, Enum sourceUnits, Enum targetUnits) {
            if (value == null) {
                return null;
            } else if (Equals(sourceUnits, targetUnits)) {
                return value;
            }
            if (CONVERSIONS.ContainsKey((sourceUnits, targetUnits))) {
                return value * CONVERSIONS[(sourceUnits, targetUnits)];
            } else if (CONVERSIONS.ContainsKey((targetUnits, sourceUnits))) {
                return value / CONVERSIONS[(targetUnits, sourceUnits)];
            } else {
                throw new ArgumentException($"Conversion between '{sourceUnits}' and '{targetUnits}' is not defined.");
            }
        }
    }
}
