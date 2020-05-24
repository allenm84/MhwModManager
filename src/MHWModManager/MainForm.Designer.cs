namespace MHWModManager
{
    partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtModsFolder = new System.Windows.Forms.TextBox();
      this.txtMhwFolder = new System.Windows.Forms.TextBox();
      this.btnLoad = new System.Windows.Forms.Button();
      this.gridMods = new System.Windows.Forms.DataGridView();
      this.clmnIsInstalled = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mhwModMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mhwModBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridMods)).BeginInit();
      this.mhwModMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mhwModBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnLoad, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.gridMods, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 499);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.txtModsFolder, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.txtMhwFolder, 1, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(448, 60);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 15);
      this.label2.TabIndex = 0;
      this.label2.Text = "MHW Folder:";
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(79, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Mods Folder:";
      // 
      // txtModsFolder
      // 
      this.txtModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.txtModsFolder.Location = new System.Drawing.Point(88, 3);
      this.txtModsFolder.Name = "txtModsFolder";
      this.txtModsFolder.Size = new System.Drawing.Size(357, 23);
      this.txtModsFolder.TabIndex = 1;
      this.txtModsFolder.Text = "E:\\Mods\\MHW\\zips";
      // 
      // txtMhwFolder
      // 
      this.txtMhwFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMhwFolder.Location = new System.Drawing.Point(88, 33);
      this.txtMhwFolder.Name = "txtMhwFolder";
      this.txtMhwFolder.Size = new System.Drawing.Size(357, 23);
      this.txtMhwFolder.TabIndex = 2;
      this.txtMhwFolder.Text = "M:\\SteamLibrary\\steamapps\\common\\Monster Hunter World";
      // 
      // btnLoad
      // 
      this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnLoad.Location = new System.Drawing.Point(370, 63);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(75, 23);
      this.btnLoad.TabIndex = 2;
      this.btnLoad.Text = "Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // gridMods
      // 
      this.gridMods.AllowUserToAddRows = false;
      this.gridMods.AllowUserToDeleteRows = false;
      this.gridMods.AllowUserToResizeRows = false;
      this.gridMods.AutoGenerateColumns = false;
      this.gridMods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.gridMods.BackgroundColor = System.Drawing.SystemColors.Window;
      this.gridMods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.gridMods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.gridMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridMods.ColumnHeadersVisible = false;
      this.gridMods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIsInstalled,
            this.nameDataGridViewTextBoxColumn});
      this.gridMods.ContextMenuStrip = this.mhwModMenu;
      this.gridMods.DataSource = this.mhwModBindingSource;
      this.gridMods.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridMods.Location = new System.Drawing.Point(3, 93);
      this.gridMods.MultiSelect = false;
      this.gridMods.Name = "gridMods";
      this.gridMods.ReadOnly = true;
      this.gridMods.RowHeadersVisible = false;
      this.gridMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gridMods.Size = new System.Drawing.Size(442, 403);
      this.gridMods.TabIndex = 3;
      this.gridMods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridMods_CellFormatting);
      // 
      // clmnIsInstalled
      // 
      this.clmnIsInstalled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      this.clmnIsInstalled.DataPropertyName = "IsInstalled";
      this.clmnIsInstalled.FillWeight = 105.3364F;
      this.clmnIsInstalled.HeaderText = "Is Installed";
      this.clmnIsInstalled.MinimumWidth = 80;
      this.clmnIsInstalled.Name = "clmnIsInstalled";
      this.clmnIsInstalled.ReadOnly = true;
      this.clmnIsInstalled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.clmnIsInstalled.Width = 80;
      // 
      // mhwModMenu
      // 
      this.mhwModMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.toolStripSeparator2,
            this.installToolStripMenuItem,
            this.uninstallToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
      this.mhwModMenu.Name = "mhwModMenu";
      this.mhwModMenu.Size = new System.Drawing.Size(181, 126);
      this.mhwModMenu.Opening += new System.ComponentModel.CancelEventHandler(this.mhwModMenu_Opening);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // uninstallToolStripMenuItem
      // 
      this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
      this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.uninstallToolStripMenuItem.Text = "Uninstall";
      this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
      // 
      // installToolStripMenuItem
      // 
      this.installToolStripMenuItem.Name = "installToolStripMenuItem";
      this.installToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.installToolStripMenuItem.Text = "Install";
      this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
      // 
      // infoToolStripMenuItem
      // 
      this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
      this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.infoToolStripMenuItem.Text = "Info";
      this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.FillWeight = 154.0545F;
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // mhwModBindingSource
      // 
      this.mhwModBindingSource.DataSource = typeof(MHWModManager.MhwMod);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(468, 519);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "MainForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.Text = "MainForm";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridMods)).EndInit();
      this.mhwModMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.mhwModBindingSource)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridMods;
        private System.Windows.Forms.TextBox txtMhwFolder;
        private System.Windows.Forms.TextBox txtModsFolder;
        private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.BindingSource mhwModBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmnIsInstalled;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.ContextMenuStrip mhwModMenu;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
  }
}