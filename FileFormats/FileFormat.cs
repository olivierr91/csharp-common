using CSharpCommon.Utils.Extensions;
using System;
using System.Linq;

namespace CSharpCommon.Utils.FileFormats {
    public enum FileFormat {
        [MimeType("application/octet-stream")]
        Unknown = 0,
        [MimeType("image/jpeg")]
        Jpeg = 0,
        [MimeType("image/png")]
        Png = 1,
        [MimeType("image/bmp")]
        Bmp = 2,
        [MimeType("image/gif")]
        Gif = 3,
        [MimeType("application/pdf")]
        Pdf = 4,
        [MimeType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        Xlsx = 5,
        [MimeType("text/html")]
        Html = 6
    }

    public static class FileFormatExtensions {
        public static string MimeType(this FileFormat value) {
            var attribute = value.GetAttributes<MimeTypeAttribute>().First();
            return attribute.MimeType;
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