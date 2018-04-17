using System;

namespace Common.Utils {
    public interface IReusable : IDisposable
    {
        void Init();
    }
}
