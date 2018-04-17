using System;

namespace CSharpCommon.Utils {
    public interface IReusable : IDisposable
    {
        void Init();
    }
}
