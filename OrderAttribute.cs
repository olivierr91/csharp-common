using System;

namespace CSharpCommon.Utils {
    public class OrderAttribute : Attribute {
        public int Order { get; }

        public OrderAttribute(int order) {
            Order = order;
        }
    }
}