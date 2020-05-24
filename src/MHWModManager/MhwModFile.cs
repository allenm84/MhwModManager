using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MHWModManager
{
  public class MhwModFile
  {
    private readonly DirectoryInfo _rootDir;
    private readonly FileInfo _modFile;
    private readonly FileInfo _installedFile;

    public MhwModFile(DirectoryInfo root, FileInfo modFile, FileInfo installedFile)
    {
      _rootDir = root;
      _modFile = modFile;
      _installedFile = installedFile;
    }

    public string Name => _modFile.Name;

    public bool Exists => (_installedFile?.Exists == true);

    public DirectoryInfo Parent => _modFile.Directory;
    public string FullName => _modFile.FullName;

    private static bool IsNativePc(DirectoryInfo dir)
    {
      return string.Equals(dir.Name, "nativepc", StringComparison.InvariantCultureIgnoreCase);
    }

    private void CopyModTo(string target_dir)
    {
      if (!Directory.Exists(target_dir))
      {
        Directory.CreateDirectory(target_dir);
      }

      var full_path = Path.Combine(target_dir, _modFile.Name);
      _modFile.CopyTo(full_path, true);
    }

    public static IEnumerable<string> Reverse(IEnumerable<string> value)
    {
      return value.Reverse();
    }

    public bool Uninstall()
    {
      return FileSystem.Delete(_installedFile);
    }

    public bool Install(MhwInstall install)
    {
      try
      {
        if (FileSystem.AreDirectoriesEqual(_modFile.Directory, _rootDir))
        {
          CopyModTo(install.FullPath);
          return true;
        }

        var path = new List<string>();

        DirectoryInfo dir = _modFile.Directory;
        do
        {
          path.Add(dir.Name);

          if (IsNativePc(dir))
          {
            var partial_path = string.Join(@"\", Reverse(path));
            var target_dir = Path.Combine(install.FullPath, partial_path);
            CopyModTo(target_dir);
            break;
          }

          dir = dir.Parent;
        }
        while (dir != null);
      }
      catch
      {
        return false;
      }

      return true;
    }
  }
}