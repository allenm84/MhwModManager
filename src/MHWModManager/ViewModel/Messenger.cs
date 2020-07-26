using System.Collections.Generic;

namespace MHWModManager
{
  public static class Messenger
  {
    static IMessengeHandler sHandler;

    public static void Register(IMessengeHandler handler)
    {
      sHandler = handler;
    }

    public static bool Confirm(string message, string caption)
    {
      return sHandler?.Confirm(message, caption) ?? false;
    }
  }
}
