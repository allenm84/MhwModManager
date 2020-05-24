using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MHWModManager
{
  public class MhwInstall : IEnumerable<FileInfo>
  {
    private readonly List<FileInfo> _potentialFiles;

    public MhwInstall(string directory)
    {
      var files = Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly);
      var nativePc = Path.Combine(directory, "nativePC");
      if (Directory.Exists(nativePc))
      {
        files = files.Concat(Directory.EnumerateFiles(nativePc, "*.*", SearchOption.AllDirectories));
      }

      FullPath = directory;
      _potentialFiles = files.Select(f => new FileInfo(f)).ToList();
    }

    public string FullPath { get; }

    IEnumerator<FileInfo> IEnumerable<FileInfo>.GetEnumerator()
    {
      return _potentialFiles.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _potentialFiles.GetEnumerator();
    }
  }
}