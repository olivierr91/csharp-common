using System.IO;
using System.Text;

namespace CSharpCommon.Utils.IO {
    public static class StreamUtils
    {
        public static MemoryStream FromString(string value) {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
