using System.Collections.Generic;
using System.IO;

namespace CSharpCommon.IO.AbstractFileSystem {
    public class PhysicalFileSystem : IFileSystem
    {
        public Stream CreateFile(string path, FileMode mode, FileAccess access, FileShare share) {
            return new FileStream(path, mode, access, share);
        }

        public Stream OpenRead(string path) {
            return File.OpenRead(path);
        }

        public void DeleteFile(string path) {
            File.Delete(path);
        }

        public void CreateDirectory(string path) {
            Directory.CreateDirectory(path);
        }

        public bool FileExists(string path) {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path) {
            return Directory.Exists(path);
        }

        public List<string> GetDirectories(string path) {
            return new List<string>(Directory.GetDirectories(path));
        }

        public List<string> GetFiles(string path) {
            return new List<string>(Directory.GetFiles(path));
        }

        public void WriteAllText(string path, string contents) {
            File.WriteAllText(path, contents);
        }
    }
}
