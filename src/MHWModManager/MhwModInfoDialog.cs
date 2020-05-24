using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHWModManager
{
  public partial class MhwModInfoDialog : Form
  {
    public MhwModInfoDialog(MhwMod mod)
    {
      InitializeComponent();
      Text = $"{mod.Name} Info";
      Mod = mod;
    }

    public MhwMod Mod { get; }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      LoadTree();
    }

    private void LoadTree()
    {
      treeModInfo.BeginUpdate();

      var tree = new TreeNode(Mod.Name);
      var lookup = new Dictionary<string, TreeNode>();
      var root_path = Mod.Root.FullName;

      foreach (var file in Mod.Files)
      {
        var node = new TreeNode(file.Name);

        var curr = file.Parent;
        var stack = new Stack<DirectoryInfo>();
        while (!string.Equals(curr.FullName, root_path))
        {
          stack.Push(curr);
          curr = curr.Parent;
        }

        var target = tree;
        while (stack.Count > 0)
        {
          var directory = stack.Pop();
          if (!lookup.TryGetValue(directory.FullName, out var candidate))
          {
            candidate = new TreeNode(directory.Name);
            lookup[directory.FullName] = candidate;
            target.Nodes.Add(candidate);
          }
          target = candidate;
        }
        target.Nodes.Add(node);
      }

      treeModInfo.Nodes.Add(tree);
      treeModInfo.EndUpdate();
      treeModInfo.ExpandAll();
    }
  }
}
