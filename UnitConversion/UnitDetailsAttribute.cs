using System;

namespace CSharpCommon.Utils.Units {

    public class UnitDetailsAttribute : Attribute {
        public double IntermediateUnitConversionFactor { get; }

        public UnitDetailsAttribute(double siUnitConversionFactor) {
            IntermediateUnitConversionFactor = siUnitConversionFactor;
        }
    }
}
