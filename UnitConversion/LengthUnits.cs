namespace CSharpCommon.Utils.Units {
    public enum LengthUnits {
        [UnitPrecedence(6)]
        Meters = 0,
        [UnitPrecedence(5)]
        Yards = 1,
        [UnitPrecedence(4)]
        Feet = 2,
        [UnitPrecedence(3)]
        Inches = 3,
        [UnitPrecedence(2)]
        Centimeters = 4,
        [UnitPrecedence(1)]
        Millimeters = 5,
    }
}
