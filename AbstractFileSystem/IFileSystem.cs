using System.Collections.Generic;
using System.IO;

namespace CSharpCommon.Utils.AbstractFileSystem {
    public interface IFileSystem
    {
        Stream CreateFile(string path, FileMode mode, FileAccess access, FileShare share);
        Stream OpenRead(string path);
        void DeleteFile(string path);
        void CreateDirectory(string path);
        bool FileExists(string path);
        bool DirectoryExists(string path);
        List<string> GetDirectories(string path);
        List<string> GetFiles(string path);
        void WriteAllText(string path, string contents);
    }
}
