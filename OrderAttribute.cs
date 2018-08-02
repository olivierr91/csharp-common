using System;

namespace NoNameDev.CSharpCommon {

    public class OrderAttribute : Attribute {

        public OrderAttribute(int order) {
            Order = order;
        }

        public int Order { get; }
    }
}