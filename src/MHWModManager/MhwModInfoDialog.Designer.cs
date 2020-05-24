namespace MHWModManager
{
  partial class MhwModInfoDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.treeModInfo = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // treeModInfo
      // 
      this.treeModInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeModInfo.Location = new System.Drawing.Point(10, 10);
      this.treeModInfo.Name = "treeModInfo";
      this.treeModInfo.Size = new System.Drawing.Size(430, 488);
      this.treeModInfo.TabIndex = 0;
      // 
      // MhwModInfoDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 508);
      this.Controls.Add(this.treeModInfo);
      this.Font = new System.Drawing.Font("Hack", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "MhwModInfoDialog";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Info";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeModInfo;
  }
}