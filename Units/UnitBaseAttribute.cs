using System;

namespace CSharpCommon.Units {
    public class UnitBaseAttribute : Attribute {
        public UnitBaseAttribute(Type baseUnitType, int baseUnitValue, int baseUnitCount) {
            BaseUnitType = baseUnitType;
            BaseUnitValue = baseUnitValue;
            BaseUnitCount = baseUnitCount;
        }
        
        public Type BaseUnitType { get; }
        public int BaseUnitValue { get; }
        public int BaseUnitCount { get; }
    }
}