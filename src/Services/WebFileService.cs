using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Miniblog.Core.Services
{
    public class WebFileService : IFileService
    {
        private string _baseFolder;

        public WebFileService(IHostingEnvironment env)
        {
            _baseFolder = env.WebRootPath;
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(BuildPath(path));
        }

        public Stream CreateFile(string path)
        {
            return File.Create(BuildPath(path));
        }

        public void DeleteFile(string path)
        {
            File.Delete(BuildPath(path));
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(BuildPath(path));
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFiles(BuildPath(path), searchPattern, searchOption)
                .Select( e => Path.GetRelativePath(_baseFolder,e) );
        }

        public bool FileExists(string path)
        {
            return File.Exists(BuildPath(path));
        }

        public Stream FileOpenRead(string path)
        {
            return File.OpenRead(BuildPath(path));
        }

        private string BuildPath(string path)
        {
            return Path.Combine(_baseFolder, path);
        }
    }
}
