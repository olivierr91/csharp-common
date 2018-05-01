using System;

namespace CSharpCommon.Utils {
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayNameAttribute : Attribute {

        public string DisplayName { get; }

        public DisplayNameAttribute(string displayName) {
            DisplayName = displayName;
        }
    }
}
