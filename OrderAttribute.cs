using System;

namespace NoNameDev.CSharpCommon {
    public class OrderAttribute : Attribute {
        public int Order { get; }

        public OrderAttribute(int order) {
            Order = order;
        }
    }
}