using System;
using System.Collections.Generic;

namespace NoNameDev.CSharpCommon.Units {

    public class UnitConverter {

        private static readonly Dictionary<(Enum source, Enum target), decimal> CONVERSIONS = new Dictionary<(Enum, Enum), decimal>() {
            { (LengthUnits.Meters, LengthUnits.None), 1 },
            { (LengthUnits.Meters, LengthUnits.Yards), 1.09361m },
            { (LengthUnits.Meters, LengthUnits.Feet), 3.28084m },
            { (LengthUnits.Meters, LengthUnits.Inches), 39.3701m },
            { (LengthUnits.Meters, LengthUnits.Centimeters), 100 },
            { (LengthUnits.Meters, LengthUnits.Millimeters), 1000 },
            { (LengthUnits.Yards, LengthUnits.None), 1 },
            { (LengthUnits.Yards, LengthUnits.Feet), 3 },
            { (LengthUnits.Yards, LengthUnits.Inches), 36 },
            { (LengthUnits.Yards, LengthUnits.Centimeters), 91.44m },
            { (LengthUnits.Yards, LengthUnits.Millimeters), 914.4m },
            { (LengthUnits.Feet, LengthUnits.None), 1 },
            { (LengthUnits.Feet, LengthUnits.Inches), 12 },
            { (LengthUnits.Feet, LengthUnits.Centimeters), 30.48m },
            { (LengthUnits.Feet, LengthUnits.Millimeters), 304.8m },
            { (LengthUnits.Inches, LengthUnits.None), 1 },
            { (LengthUnits.Inches, LengthUnits.Centimeters), 2.54m },
            { (LengthUnits.Inches, LengthUnits.Millimeters), 25.4m },
            { (LengthUnits.Centimeters, LengthUnits.None), 1 },
            { (LengthUnits.Centimeters, LengthUnits.Millimeters), 10 },
            { (AreaUnits.SquareMeters, AreaUnits.None), 1 },
            { (AreaUnits.SquareMeters, AreaUnits.SquareYards), 1.19599m },
            { (AreaUnits.SquareMeters, AreaUnits.SquareFeet), 10.7639m },
            { (AreaUnits.SquareMeters, AreaUnits.SquareInches), 1550 },
            { (AreaUnits.SquareMeters, AreaUnits.SquareCentimeters), 10000 },
            { (AreaUnits.SquareMeters, AreaUnits.SquareMillimeters), 1000000 },
            { (AreaUnits.SquareYards, AreaUnits.None), 1 },
            { (AreaUnits.SquareYards, AreaUnits.SquareFeet), 9 },
            { (AreaUnits.SquareYards, AreaUnits.SquareInches), 1296 },
            { (AreaUnits.SquareYards, AreaUnits.SquareCentimeters), 8361.27m },
            { (AreaUnits.SquareYards, AreaUnits.SquareMillimeters), 836127 },
            { (AreaUnits.SquareFeet, AreaUnits.None), 1 },
            { (AreaUnits.SquareFeet, AreaUnits.SquareInches), 144 },
            { (AreaUnits.SquareFeet, AreaUnits.SquareCentimeters), 929.03m },
            { (AreaUnits.SquareFeet, AreaUnits.SquareMillimeters), 92903 },
            { (AreaUnits.SquareInches, AreaUnits.None), 1 },
            { (AreaUnits.SquareInches, AreaUnits.SquareCentimeters), 6.4516m },
            { (AreaUnits.SquareInches, AreaUnits.SquareMillimeters), 645.16m },
            { (AreaUnits.SquareCentimeters, AreaUnits.None), 1 },
            { (AreaUnits.SquareCentimeters, AreaUnits.SquareMillimeters), 100 },
            { (VolumeUnits.CubicMeters, VolumeUnits.None), 1 },
            { (VolumeUnits.CubicMeters, VolumeUnits.CubicYards), 1.30795m },
            { (VolumeUnits.CubicMeters, VolumeUnits.CubicFeet), 35.3147m },
            { (VolumeUnits.CubicMeters, VolumeUnits.BoardFeet), 423.776m },
            { (VolumeUnits.CubicMeters, VolumeUnits.CubicInches), 61023.7m },
            { (VolumeUnits.CubicMeters, VolumeUnits.CubicCentimeters), 1000000 },
            { (VolumeUnits.CubicMeters, VolumeUnits.CubicMillimeters), 1e+9m },
            { (VolumeUnits.CubicYards, VolumeUnits.None), 1 },
            { (VolumeUnits.CubicYards , VolumeUnits.CubicFeet), 27 },
            { (VolumeUnits.CubicYards, VolumeUnits.BoardFeet), 324 },
            { (VolumeUnits.CubicYards, VolumeUnits.CubicInches), 46656 },
            { (VolumeUnits.CubicYards, VolumeUnits.CubicCentimeters), 764555 },
            { (VolumeUnits.CubicYards, VolumeUnits.CubicMillimeters), 7.646e+8m },
            { (VolumeUnits.CubicFeet, VolumeUnits.None), 1 },
            { (VolumeUnits.CubicFeet, VolumeUnits.BoardFeet), 12 },
            { (VolumeUnits.CubicFeet, VolumeUnits.CubicInches), 1728 },
            { (VolumeUnits.CubicFeet, VolumeUnits.CubicCentimeters), 28316.8m },
            { (VolumeUnits.CubicFeet, VolumeUnits.CubicMillimeters), 2.832e+7m },
            { (VolumeUnits.BoardFeet, VolumeUnits.None), 1 },
            { (VolumeUnits.BoardFeet, VolumeUnits.CubicInches), 144 },
            { (VolumeUnits.BoardFeet, VolumeUnits.CubicCentimeters), 2359.74m },
            { (VolumeUnits.BoardFeet, VolumeUnits.CubicMillimeters), 2.36e+6m },
            { (VolumeUnits.CubicInches, VolumeUnits.None), 1 },
            { (VolumeUnits.CubicInches, VolumeUnits.CubicCentimeters), 16.3871m },
            { (VolumeUnits.CubicInches, VolumeUnits.CubicMillimeters), 16387.1m },
            { (VolumeUnits.CubicCentimeters, VolumeUnits.None), 1 },
            { (VolumeUnits.CubicCentimeters, VolumeUnits.CubicMillimeters), 1000 },
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