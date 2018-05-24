using System;

namespace CSharpCommon.Utils.Units {

    public class UnitDetailsAttribute : Attribute {
        public int BaseUnitValue { get; }

        public UnitDetailsAttribute(int baseUnitValue) {
            BaseUnitValue = baseUnitValue;
        }
    }
}
