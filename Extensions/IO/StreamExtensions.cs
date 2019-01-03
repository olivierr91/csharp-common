using System.IO;
using System.Text;

namespace NoNameDev.CSharpCommon.Extensions.IO {

    public static class StreamExtensions {

        public static MemoryStream AsMemoryStream(this Stream stream, bool dispose = false) {
            var memoryStream = new MemoryStream();
            if (stream.CanSeek) {
                stream.Position = 0;
            }
            stream.CopyTo(memoryStream);
            if (dispose) {
                stream.Dispose();
            }
            return memoryStream;
        }

        public static string ReadToEnd(this Stream stream) {
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }

        public static void SaveToFile(this Stream stream, Stream outStream) {
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(outStream);
            outStream.Close();
        }
    }
}