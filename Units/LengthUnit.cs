namespace CSharpCommon.Utils.Units {
    public enum LengthUnit {
        [UnitPrecedence(7)]
        None = 0,
        [UnitPrecedence(6)]
        Meters = 1,
        [UnitPrecedence(5)]
        Yards = 2,
        [UnitPrecedence(4)]
        Feet = 3,
        [UnitPrecedence(3)]
        Inches = 4,
        [UnitPrecedence(2)]
        Centimeters = 5,
        [UnitPrecedence(1)]
        Millimeters = 6,
    }
}
