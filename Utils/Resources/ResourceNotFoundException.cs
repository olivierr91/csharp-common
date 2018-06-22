using System;

namespace NoNameDev.CSharpCommon.Utils.Resources {
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message) { }
    }
}
