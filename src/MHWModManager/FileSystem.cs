using System.IO;
using System.Linq;

namespace MHWModManager
{
    public static class FileSystem
    {
        public static bool AreFilesEqual(FileInfo file_x, FileInfo file_y)
        {
            var bytes_x = File.ReadAllBytes(file_x.FullName);
            var bytes_y = File.ReadAllBytes(file_y.FullName);
            return bytes_x.Length == bytes_y.Length && bytes_x.SequenceEqual(bytes_y);
        }
    }
}