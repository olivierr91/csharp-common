using System.IO;
using System.Text;

namespace CSharpCommon.Utils.Extensions {
    public static class StreamExtensions
    {
        public static string ReadToEnd(this Stream stream) {
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }
    }
}
