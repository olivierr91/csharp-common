using System;

namespace NoNameDev.CSharpCommon {
    public interface IReusable : IDisposable
    {
        void Init();
    }
}
