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
    private MhwMod mod_under_mouse;
    private Font bold_font;

    public MainForm()
    {
      InitializeComponent();
      mhwModBindingSource.ListChanged += MhwModBindingSource_ListChanged;
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

      foreach (var modCategory in modDirectory.EnumerateDirectories())
      {
        foreach (var modArchive in modCategory.EnumerateFiles())
        {
          mhwModBindingSource.Add(new MhwMod(install, modArchive));
        }
      }

      SetIsWorking(false);
    }

    private bool Confirm(string message)
    {
      var result = MessageBox.Show(this, message, "Confirm",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return (result == DialogResult.Yes);
    }

    private MhwMod GetModAt(int rowIndex)
    {
      if ((uint)rowIndex < (uint)gridMods.RowCount)
      {
        var row = gridMods.Rows[rowIndex];
        if (row?.DataBoundItem is MhwMod mod)
        {
          return mod;
        }
      }

      return null;
    }

    private void MhwModBindingSource_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemChanged)
      {
        gridMods.InvalidateRow(e.NewIndex);
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      bold_font = new Font(Font, FontStyle.Bold);
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

    private void gridMods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      var mod = GetModAt(e.RowIndex);
      if (mod?.IsInstalled == true)
      {
        e.CellStyle.Font = bold_font;
      }
    }

    private void mhwModMenu_Opening(object sender, CancelEventArgs e)
    {
      var screen_pt = Cursor.Position;
      var client_pt = gridMods.PointToClient(screen_pt);
      var info = gridMods.HitTest(client_pt.X, client_pt.Y);

      mod_under_mouse = GetModAt(info.RowIndex);
      if (mod_under_mouse != null)
      {
        installToolStripMenuItem.Enabled = (mod_under_mouse.IsInstalled == false);
        uninstallToolStripMenuItem.Enabled = (mod_under_mouse.IsInstalled == true);
      }
      else
      {
        e.Cancel = true;
      }
    }

    private void infoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mod_under_mouse != null)
      {
        var dlg = new MhwModInfoDialog(mod_under_mouse);
        dlg.Show(this);
      }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mod_under_mouse != null
        && Confirm("Are you sure you want to delete this mod?")
        && mod_under_mouse.Delete())
      {
        mhwModBindingSource.Remove(mod_under_mouse);
      }
    }

    private void installToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mod_under_mouse != null)
      {
        mod_under_mouse.Install();
        btnLoad.PerformClick();
      }
    }

    private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mod_under_mouse != null)
      {
        mod_under_mouse.Uninstall();
        btnLoad.PerformClick();
      }
    }
  }
}