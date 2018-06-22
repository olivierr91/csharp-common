using System;

namespace NoNameDev.CSharpCommon.Units {
    public class UnitPrecedenceAttribute : Attribute {
        public UnitPrecedenceAttribute(int precedence) {
            Precedence = precedence;
        }
        public int Precedence { get; }
    }
}