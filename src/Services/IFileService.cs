using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniblog.Core.Services
{
    public interface IFileService
    {
        void CreateDirectory(string path);
        bool DirectoryExists(string path);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
        Stream CreateFile(string path);
        void DeleteFile(string path);
        bool FileExists(string path);
        Stream FileOpenRead(string path);
    }
}
