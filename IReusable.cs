using System;

namespace CSharpCommon {
    public interface IReusable : IDisposable
    {
        void Init();
    }
}
