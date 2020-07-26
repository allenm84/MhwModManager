using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWModManager
{
  public enum ModInstallType
  {
    None,
    Error,
    NoFiles,
    PartialInstall,
    NotInstalled,
    Installed,
  }
}
