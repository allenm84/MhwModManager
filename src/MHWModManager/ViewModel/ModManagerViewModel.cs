using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MHWModManager
{
  public class ModManagerViewModel : BaseNotifyPropertyChanged
  {
    private string _modsFolder = @"E:\Mods\MHW\zips";
    private string _monsterHunterFolder = @"M:\SteamLibrary\steamapps\common\Monster Hunter World";
    private ModFileViewModel _selectedMod;

    public ModManagerViewModel()
    {
      LoadCommand = new DelegateCommand(LoadMods, CanLoadMods);
    }

    public string ModsFolder
    {
      get => _modsFolder;
      set
      {
        _modsFolder = value;
        FirePropertyChanged();
        LoadCommand.Refresh();
      }
    }

    public string MonsterHunterFolder
    {
      get => _monsterHunterFolder;
      set
      {
        _monsterHunterFolder = value;
        FirePropertyChanged();
        LoadCommand.Refresh();
      }
    }

    public ObservableCollection<ModFileViewModel> Mods { get; } = new ObservableCollection<ModFileViewModel>();

    public ModFileViewModel SelectedMod
    {
      get => _selectedMod;
      set
      {
        _selectedMod = value;
        FirePropertyChanged();
      }
    }

    public DelegateCommand LoadCommand { get; }

    private bool CanLoadMods()
    {
      return
        !string.IsNullOrEmpty(ModsFolder) && Directory.Exists(ModsFolder) &&
        !string.IsNullOrEmpty(MonsterHunterFolder) && Directory.Exists(MonsterHunterFolder);
    }

    private void LoadMods()
    {
      foreach (var mod in Mods)
      {
        mod.Deleted -= OnModDeleted;
      }
      Mods.Clear();

      var source = new DirectoryInfo(ModsFolder);
      var dest = new DirectoryInfo(MonsterHunterFolder);

      foreach (var file in source.EnumerateFiles("*", SearchOption.AllDirectories))
      {
        if (string.Equals(".py", file.Extension, StringComparison.InvariantCultureIgnoreCase))
        {
          continue;
        }

        var mod = new ModFileViewModel(dest, file);
        mod.Deleted += OnModDeleted;

        Mods.Add(mod);
      }

      SelectedMod = Mods.FirstOrDefault();
    }

    private void OnModDeleted(object sender, EventArgs e)
    {
      if (sender is ModFileViewModel mod)
      {
        int index = Mods.IndexOf(mod);
        Mods.RemoveAt(index);
        index = Math.Min(index, Mods.Count - 1);
        if (-1 < index && index < Mods.Count)
        {
          SelectedMod = Mods[index];
        }
      }
    }
  }
}
