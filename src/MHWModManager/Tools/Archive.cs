using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MHWModManager
{
  public static class Archive
  {
    private static readonly string OutputDirectory;

    static Archive()
    {
      OutputDirectory = @"C:\_MhwModManager";
      if (!Directory.Exists(OutputDirectory))
      {
        Directory.CreateDirectory(OutputDirectory);
      }
    }

    public static async Task<(bool, DirectoryInfo)> Extract(FileInfo file)
    {
      return await Task.Run(() => Run7Z(file));
    }

    private static (bool, DirectoryInfo) Run7Z(FileInfo file)
    {
      if (file == null)
      {
        throw new ArgumentNullException(nameof(file));
      }

      var name = Path.GetFileNameWithoutExtension(file.FullName);
      var outputDir = Path.Combine(OutputDirectory, name);

      using (var p = new Process())
      {
        p.StartInfo.FileName = "7z.exe";
        p.StartInfo.Arguments = $@"x ""{file.FullName}"" -o""{outputDir}"" -r -aoa";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
        p.WaitForExit();
        var exitCode = p.ExitCode;
        return (0 <= exitCode && exitCode <= 1, new DirectoryInfo(outputDir));
      }
    }
  }
}