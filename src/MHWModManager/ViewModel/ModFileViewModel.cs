using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MHWModManager
{
  public class ModFileViewModel : BaseNotifyPropertyChanged
  {
    const string ModFolderName = "nativePC";

    private readonly DirectoryInfo _monsterHunterFolder;
    private readonly FileInfo _modFile;

    private ModInstallType _installType = ModInstallType.None;
    private string _name = "";

    public ModFileViewModel(DirectoryInfo monsterHunterFolder, FileInfo modFile)
    {
      _monsterHunterFolder = monsterHunterFolder;
      _modFile = modFile;

      Name = modFile.Name;

      InstallCommand = new DelegateCommand(DoInstall, CanInstalll);
      UninstallCommand = new DelegateCommand(DoUninstall, CanUninstall);
      DeleteCommand = new DelegateCommand(DoDelete);

      Refresh();
    }

    public ModInstallType InstallType
    {
      get => _installType;
      private set
      {
        _installType = value;
        FirePropertyChanged();
      }
    }

    public string Name
    {
      get => _name;
      private set
      {
        _name = value;
        FirePropertyChanged();
      }
    }

    public ObservableCollection<ModFileItemViewModel> Files { get; } = new ObservableCollection<ModFileItemViewModel>();

    public DelegateCommand InstallCommand { get; }
    public DelegateCommand UninstallCommand { get; }
    public DelegateCommand DeleteCommand { get; }

    internal event EventHandler Deleted;

    private void RefreshCommands()
    {
      InstallCommand.Refresh();
      UninstallCommand.Refresh();
    }

    private void DoDelete()
    {
      var isInstalled = CanUninstall();

      var text = isInstalled
        ? "Are you sure you want to uninstall and delete this mod?"
        : "Are you sure you want to delete this mod?";

      if (Messenger.Confirm(text, "Confirm"))
      {
        if (isInstalled)
        {
          DoUninstall();
        }

        _modFile.Delete();
        Deleted?.Invoke(this, EventArgs.Empty);
      }
    }

    private bool CanUninstall() => 
      InstallType == ModInstallType.Installed || InstallType == ModInstallType.PartialInstall;

    private void DoUninstall()
    {
      foreach (var file in Files.Where(f => f.IsInstalled))
      {
        var filepath = Path.Combine(file.Destination.FullName, file.Source.Name);
        File.Delete(filepath);
      }
      Refresh();
    }

    private bool CanInstalll() =>
      InstallType == ModInstallType.NotInstalled || InstallType == ModInstallType.PartialInstall;

    private void DoInstall()
    {
      foreach (var file in Files.Where(f => !f.IsInstalled))
      {
        var filepath = Path.Combine(file.Destination.FullName, file.Source.Name);
        if (!file.Destination.Exists)
        {
          file.Destination.Create();
          file.Destination.Refresh();
        }
        File.Copy(file.Source.FullName, filepath, true);
      }
      Refresh();
    }

    private async void Refresh()
    {
      Files.Clear();

      var (succeeded, mod_dir) = await Archive.Extract(_modFile);
      if (!succeeded)
      {
        InstallType = ModInstallType.Error;
        return;
      }

      var mod_folders = mod_dir.GetDirectories();
      if (mod_folders.Length == 0)
      {
        // none of the direct children are folders; the files must exist in the root
        Files.AddRange(mod_dir
          .EnumerateFiles()
          .Select(f => new ModFileItemViewModel(f, _monsterHunterFolder)));
      }
      else
      {
        // create a regex to split off the nativePC\ part of the file path
        var strip = new Regex($@"(^({ModFolderName}\\))?(?<path>.+)", RegexOptions.IgnoreCase);

        // mods must go in nativePC. If there are files *and* folders, and no nativePC, assume
        // that they go to nativePC
        var nativePC = Path.Combine(_monsterHunterFolder.FullName, ModFolderName);
        foreach (var file in mod_dir.EnumerateFiles("*", SearchOption.AllDirectories))
        {
          // figure out where this file should ultimately be installed
          var relative_path_raw = FileSystem.GetRelativePath(file.FullName, mod_dir.FullName);
          var match = strip.Match(relative_path_raw);
          var relative_path_corrected = match.Groups["path"].Value;
          var full_file_path = Path.GetFullPath(Path.Combine(nativePC, relative_path_corrected));
          var dest_dir = new DirectoryInfo(Path.GetDirectoryName(full_file_path));
          Files.Add(new ModFileItemViewModel(file, dest_dir));
        }
      }

      InstallType = GetInstallType(Files.Count, Files.Count(f => f.IsInstalled));
      RefreshCommands();
    }

    private static ModInstallType GetInstallType(int expected, int actual)
    {
      if (expected == actual)
      {
        if (actual > 0)
        {
          return ModInstallType.Installed;
        }
        else
        {
          return ModInstallType.NoFiles;
        }
      }
      else
      {
        if (actual > 0)
        {
          return ModInstallType.PartialInstall;
        }
        else
        {
          return ModInstallType.NotInstalled;
        }
      }
    }
  }
}
