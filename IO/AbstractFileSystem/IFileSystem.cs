using System.Collections.Generic;
using System.IO;

namespace CSharpCommon.IO.AbstractFileSystem {

    public interface IFileSystem {

        void CreateDirectory(string path);

        Stream CreateFile(string path, FileMode mode, FileAccess access, FileShare share);

        void DeleteFile(string path);

        bool DirectoryExists(string path);

        bool FileExists(string path);

        List<string> GetDirectories(string path);

        List<string> GetFiles(string path);

        Stream OpenRead(string path);

        void WriteAllText(string path, string contents);
    }
}