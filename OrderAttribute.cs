using System;

namespace CSharpCommon {

    public class OrderAttribute : Attribute {

        public OrderAttribute(int order) {
            Order = order;
        }

        public int Order { get; }
    }
}