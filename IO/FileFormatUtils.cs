using NoNameDev.CSharpCommon.Extensions;
using System;
using System.Linq;

namespace NoNameDev.CSharpCommon.IO {

    public static class FileFormatUtils {

        public static FileFormat FromMimeType(string mimeType) {
            foreach (FileFormat fileFormat in Enum.GetValues(typeof(FileFormat))) {
                if (fileFormat.GetAttributes<MimeTypeAttribute>().First().MimeType == mimeType) {
                    return fileFormat;
                }
            }
            throw new NotSupportedException($"MIME type '{mimeType}' cannot be mapped to a supported image format.");
        }
    }
}