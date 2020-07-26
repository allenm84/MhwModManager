using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWModManager
{
  public class ModFileItemViewModel : BaseNotifyPropertyChanged
  {
    public ModFileItemViewModel(FileInfo source, DirectoryInfo dest)
    {
      IsInstalled = dest.Exists && dest.Contains(source);
      Source = source;
      Destination = dest;

      Name = Source.Name;
    }

    public bool IsInstalled { get; }
    public string Name { get; }

    public FileInfo Source { get; }
    public DirectoryInfo Destination { get; }
  }
}
