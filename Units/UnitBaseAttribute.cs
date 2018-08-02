using System;

namespace NoNameDev.CSharpCommon.Units {

    public class UnitBaseAttribute : Attribute {

        public UnitBaseAttribute(Type baseUnitType, int baseUnitValue, int baseUnitCount) {
            BaseUnitType = baseUnitType;
            BaseUnitValue = baseUnitValue;
            BaseUnitCount = baseUnitCount;
        }

        public int BaseUnitCount { get; }
        public Type BaseUnitType { get; }
        public int BaseUnitValue { get; }
    }
}