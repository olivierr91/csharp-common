namespace CSharpCommon.Utils.Units {
    public enum VolumeUnits
    {
        [UnitDetails(siUnitConversionFactor: 1)]
        CubicMeters = 6,
        [UnitDetails(siUnitConversionFactor: 35.3147)]
        CubicFeet = 7,
        [UnitDetails(siUnitConversionFactor: 423.776)]
        BoardFeet = 8,
    }

}
