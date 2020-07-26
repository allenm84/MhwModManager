using System.Collections.Generic;

namespace MHWModManager
{
  public interface IMessengeHandler
  {
    bool Confirm(string message, string caption);
  }
}
