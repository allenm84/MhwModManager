using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWModManager
{
  public static class FileSystem
  {
    public static string GetRelativePath(string filespec, string folder)
    {
      Uri pathUri = new Uri(filespec);
      // Folders must end in a slash
      if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
      {
        folder += Path.DirectorySeparatorChar;
      }
      Uri folderUri = new Uri(folder);
      return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
    }

    public static bool AreFilesEqual(FileInfo file_x, FileInfo file_y) =>
      AreFilesEqual(file_x.FullName, file_y.FullName);

    public static bool AreFilesEqual(string file_path_x, string file_path_y)
    {
      var bytes_x = File.ReadAllBytes(file_path_x);
      var bytes_y = File.ReadAllBytes(file_path_y);
      return bytes_x.Length == bytes_y.Length && bytes_x.SequenceEqual(bytes_y);
    }

    public static bool Contains(this DirectoryInfo directory, FileInfo file)
    {
      var filepath = Path.Combine(directory.FullName, file.Name);
      if (!File.Exists(filepath))
      {
        return false;
      }

      return AreFilesEqual(filepath, file.FullName);
    }
  }
}
