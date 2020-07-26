using System;
using System.Collections.Generic;
using System.Linq;

namespace MHWModManager
{
  public static class CommonExtensions
  {
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
      foreach (T item in items)
      {
        collection.Add(item);
      }
    }
  }
}
