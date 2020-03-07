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
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void SetIsWorking(bool working)
    {
      Cursor = working ? Cursors.WaitCursor : Cursors.Default;
      tableLayoutPanel1.Enabled = !working;
    }

    private async void LoadMods(string modsFolder, string mhwInstallFolder)
    {
      SetIsWorking(true);

      mhwModBindingSource.Clear();

      var install = await Task.Run(() => new MhwInstall(mhwInstallFolder));
      var modDirectory = new DirectoryInfo(modsFolder);
      foreach (var mod in modDirectory.EnumerateFiles())
      {
        mhwModBindingSource.Add(new MhwMod(install, mod));
      }

      SetIsWorking(false);
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      var modsFolder = txtModsFolder.Text;
      var mhwInstallFolder = txtMhwFolder.Text;

      var folders = new[] { modsFolder, mhwInstallFolder };
      if (folders.All(f => !string.IsNullOrWhiteSpace(f) && Directory.Exists(f)))
      {
        LoadMods(modsFolder, mhwInstallFolder);
      }
      else
      {
        MessageBox.Show(this,
          "The mods folder and monster folder must be valid and exist",
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gridMods_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      
    }
  }
}