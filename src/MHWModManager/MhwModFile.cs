using System.IO;

namespace MHWModManager
{
    public class MhwModFile
    {
        private readonly FileInfo _modFile;
        private readonly FileInfo _installedFile;
        
        public MhwModFile(FileInfo modFile, FileInfo installedFile)
        {
            _modFile = modFile;
            _installedFile = installedFile;
        }

        public string Name => _modFile?.Name;

        public bool Exists => (_installedFile?.Exists == true);
    }
}