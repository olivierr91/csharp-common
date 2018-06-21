using CSharpCommon.Extensions;
using System;
using System.Linq;

namespace CSharpCommon.IO {
    public enum FileFormat {
        [MimeType("application/octet-stream")]
        Unknown = 0,
        [MimeType("image/jpeg")]
        [FileExtensions("jpg", "jpeg")]
        Jpeg = 1,
        [MimeType("image/png")]
        [FileExtensions("png")]
        Png = 2,
        [MimeType("image/bmp")]
        [FileExtensions("bmp")]
        Bmp = 3,
        [MimeType("image/gif")]
        [FileExtensions("gif")]
        Gif = 4,
        [MimeType("application/pdf")]
        [FileExtensions("pdf")]
        Pdf = 5,
        [MimeType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [FileExtensions("xlsx")]
        Xlsx = 6,
        [MimeType("text/html")]
        [FileExtensions("html", "htm")]
        Html = 7
    }

    public static class FileFormatExtensions {
        public static string MimeType(this FileFormat value) {
            var attribute = value.GetAttributes<MimeTypeAttribute>().First();
            return attribute.MimeType;
        }

        public static FileFormat FromExtension(string extension) {
            foreach (FileFormat fileFormat in Enum.GetValues(typeof(FileFormat))) {
                if (fileFormat.GetAttribute<FileExtensionsAttribute>().Extensions.Any(e => String.Equals(extension, e, StringComparison.InvariantCultureIgnoreCase))) {
                    return fileFormat;
                }
            }
            return FileFormat.Unknown;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class FileExtensionsAttribute : Attribute {
        public string[] Extensions { get; set; }

        public FileExtensionsAttribute(params string[] extensions) {
            Extensions = extensions;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MimeTypeAttribute : Attribute {
        private readonly string _mimeType;

        public MimeTypeAttribute(string mimeType) {
            _mimeType = mimeType;
        }

        public string MimeType { get => _mimeType; }
    }
}