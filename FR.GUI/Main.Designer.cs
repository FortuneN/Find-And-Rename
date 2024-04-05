
namespace FR.GUI
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.lblTopFolder = new System.Windows.Forms.Label();
			this.txtTopFolder = new System.Windows.Forms.TextBox();
			this.btnSelectFolder = new System.Windows.Forms.Button();
			this.chkIncludeSubFolders = new System.Windows.Forms.CheckBox();
			this.lblExcludeFolders = new System.Windows.Forms.Label();
			this.txtExcludeFolders = new System.Windows.Forms.TextBox();
			this.txtFindInName = new System.Windows.Forms.TextBox();
			this.lblFind = new System.Windows.Forms.Label();
			this.chkFindCaseSensitive = new System.Windows.Forms.CheckBox();
			this.chkRegularExpression = new System.Windows.Forms.CheckBox();
			this.btnFindOnly = new System.Windows.Forms.Button();
			this.txtReplaceWith = new System.Windows.Forms.TextBox();
			this.lblReplaceWith = new System.Windows.Forms.Label();
			this.btnRename = new System.Windows.Forms.Button();
			this.btnSwitch = new System.Windows.Forms.Button();
			this.chkOverwriteIfFileExists = new System.Windows.Forms.CheckBox();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblFoundOrRenamed = new System.Windows.Forms.Label();
			this.dgvFoundOrRenamed = new System.Windows.Forms.DataGridView();
			this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fbdSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.lblIncludeFiles = new System.Windows.Forms.Label();
			this.txtIncludeFiles = new System.Windows.Forms.TextBox();
			this.txtExcludeFiles = new System.Windows.Forms.TextBox();
			this.lblExcludeFiles = new System.Windows.Forms.Label();
			this.dgvSkipped = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblSkipped = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblProcessed = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblProcessedCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblTotalCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.dgvFoundOrRenamed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkipped)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTopFolder
			// 
			this.lblTopFolder.AutoSize = true;
			this.lblTopFolder.Location = new System.Drawing.Point(12, 13);
			this.lblTopFolder.Name = "lblTopFolder";
			this.lblTopFolder.Size = new System.Drawing.Size(61, 13);
			this.lblTopFolder.TabIndex = 0;
			this.lblTopFolder.Text = "Top Folder:";
			// 
			// txtTopFolder
			// 
			this.txtTopFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTopFolder.Location = new System.Drawing.Point(110, 10);
			this.txtTopFolder.Name = "txtTopFolder";
			this.txtTopFolder.Size = new System.Drawing.Size(673, 20);
			this.txtTopFolder.TabIndex = 1;
			this.txtTopFolder.TextChanged += new System.EventHandler(this.txtTopFolder_TextChanged);
			// 
			// btnSelectFolder
			// 
			this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectFolder.Location = new System.Drawing.Point(781, 9);
			this.btnSelectFolder.Name = "btnSelectFolder";
			this.btnSelectFolder.Size = new System.Drawing.Size(27, 22);
			this.btnSelectFolder.TabIndex = 2;
			this.btnSelectFolder.Text = "...";
			this.btnSelectFolder.UseVisualStyleBackColor = true;
			this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
			// 
			// chkIncludeSubFolders
			// 
			this.chkIncludeSubFolders.AutoSize = true;
			this.chkIncludeSubFolders.Checked = true;
			this.chkIncludeSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeSubFolders.Location = new System.Drawing.Point(110, 38);
			this.chkIncludeSubFolders.Name = "chkIncludeSubFolders";
			this.chkIncludeSubFolders.Size = new System.Drawing.Size(115, 17);
			this.chkIncludeSubFolders.TabIndex = 3;
			this.chkIncludeSubFolders.Text = "Include sub-folders";
			this.chkIncludeSubFolders.UseVisualStyleBackColor = true;
			// 
			// lblExcludeFolders
			// 
			this.lblExcludeFolders.AutoSize = true;
			this.lblExcludeFolders.Enabled = false;
			this.lblExcludeFolders.Location = new System.Drawing.Point(401, 39);
			this.lblExcludeFolders.Name = "lblExcludeFolders";
			this.lblExcludeFolders.Size = new System.Drawing.Size(108, 13);
			this.lblExcludeFolders.TabIndex = 4;
			this.lblExcludeFolders.Text = "Exclude folders (csv):";
			// 
			// txtExcludeFolders
			// 
			this.txtExcludeFolders.Enabled = false;
			this.txtExcludeFolders.Location = new System.Drawing.Point(509, 36);
			this.txtExcludeFolders.Name = "txtExcludeFolders";
			this.txtExcludeFolders.Size = new System.Drawing.Size(299, 20);
			this.txtExcludeFolders.TabIndex = 5;
			this.txtExcludeFolders.Text = ".git,";
			// 
			// txtFindInName
			// 
			this.txtFindInName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFindInName.Location = new System.Drawing.Point(110, 88);
			this.txtFindInName.Multiline = true;
			this.txtFindInName.Name = "txtFindInName";
			this.txtFindInName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFindInName.Size = new System.Drawing.Size(698, 50);
			this.txtFindInName.TabIndex = 8;
			this.txtFindInName.TextChanged += new System.EventHandler(this.txtFindInName_TextChanged);
			// 
			// lblFind
			// 
			this.lblFind.AutoSize = true;
			this.lblFind.Location = new System.Drawing.Point(13, 91);
			this.lblFind.Name = "lblFind";
			this.lblFind.Size = new System.Drawing.Size(76, 13);
			this.lblFind.TabIndex = 9;
			this.lblFind.Text = "Find (in name):";
			// 
			// chkFindCaseSensitive
			// 
			this.chkFindCaseSensitive.AutoSize = true;
			this.chkFindCaseSensitive.Checked = true;
			this.chkFindCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFindCaseSensitive.Location = new System.Drawing.Point(110, 144);
			this.chkFindCaseSensitive.Name = "chkFindCaseSensitive";
			this.chkFindCaseSensitive.Size = new System.Drawing.Size(152, 17);
			this.chkFindCaseSensitive.TabIndex = 10;
			this.chkFindCaseSensitive.Text = "Case sensitive (on finding):";
			this.chkFindCaseSensitive.UseVisualStyleBackColor = true;
			// 
			// chkRegularExpression
			// 
			this.chkRegularExpression.AutoSize = true;
			this.chkRegularExpression.Location = new System.Drawing.Point(316, 144);
			this.chkRegularExpression.Name = "chkRegularExpression";
			this.chkRegularExpression.Size = new System.Drawing.Size(177, 17);
			this.chkRegularExpression.TabIndex = 12;
			this.chkRegularExpression.Text = "Regular expression (on findeing)";
			this.chkRegularExpression.UseVisualStyleBackColor = true;
			// 
			// btnFindOnly
			// 
			this.btnFindOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindOnly.Enabled = false;
			this.btnFindOnly.Location = new System.Drawing.Point(733, 144);
			this.btnFindOnly.Name = "btnFindOnly";
			this.btnFindOnly.Size = new System.Drawing.Size(75, 23);
			this.btnFindOnly.TabIndex = 14;
			this.btnFindOnly.Text = "Find Only";
			this.btnFindOnly.UseVisualStyleBackColor = true;
			this.btnFindOnly.Click += new System.EventHandler(this.btnFindOnly_Click);
			// 
			// txtReplaceWith
			// 
			this.txtReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReplaceWith.Location = new System.Drawing.Point(110, 213);
			this.txtReplaceWith.Multiline = true;
			this.txtReplaceWith.Name = "txtReplaceWith";
			this.txtReplaceWith.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtReplaceWith.Size = new System.Drawing.Size(698, 50);
			this.txtReplaceWith.TabIndex = 20;
			// 
			// lblReplaceWith
			// 
			this.lblReplaceWith.AutoSize = true;
			this.lblReplaceWith.Location = new System.Drawing.Point(13, 216);
			this.lblReplaceWith.Name = "lblReplaceWith";
			this.lblReplaceWith.Size = new System.Drawing.Size(72, 13);
			this.lblReplaceWith.TabIndex = 21;
			this.lblReplaceWith.Text = "Replace with:";
			// 
			// btnRename
			// 
			this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRename.Enabled = false;
			this.btnRename.Location = new System.Drawing.Point(733, 269);
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(75, 23);
			this.btnRename.TabIndex = 22;
			this.btnRename.Text = "Rename";
			this.btnRename.UseVisualStyleBackColor = true;
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// btnSwitch
			// 
			this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
			this.btnSwitch.Location = new System.Drawing.Point(573, 144);
			this.btnSwitch.Name = "btnSwitch";
			this.btnSwitch.Size = new System.Drawing.Size(75, 63);
			this.btnSwitch.TabIndex = 23;
			this.btnSwitch.UseVisualStyleBackColor = true;
			this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
			// 
			// chkOverwriteIfFileExists
			// 
			this.chkOverwriteIfFileExists.AutoSize = true;
			this.chkOverwriteIfFileExists.Location = new System.Drawing.Point(110, 167);
			this.chkOverwriteIfFileExists.Name = "chkOverwriteIfFileExists";
			this.chkOverwriteIfFileExists.Size = new System.Drawing.Size(186, 17);
			this.chkOverwriteIfFileExists.TabIndex = 16;
			this.chkOverwriteIfFileExists.Text = "Overwrite if file exists (on replace):";
			this.chkOverwriteIfFileExists.UseVisualStyleBackColor = true;
			// 
			// pbProgress
			// 
			this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbProgress.Location = new System.Drawing.Point(110, 522);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(617, 23);
			this.pbProgress.TabIndex = 25;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(733, 521);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 25);
			this.btnCancel.TabIndex = 26;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblFoundOrRenamed
			// 
			this.lblFoundOrRenamed.AutoSize = true;
			this.lblFoundOrRenamed.Location = new System.Drawing.Point(12, 3);
			this.lblFoundOrRenamed.Name = "lblFoundOrRenamed";
			this.lblFoundOrRenamed.Size = new System.Drawing.Size(56, 13);
			this.lblFoundOrRenamed.TabIndex = 27;
			this.lblFoundOrRenamed.Text = "Renamed:";
			// 
			// dgvFoundOrRenamed
			// 
			//this.dgvFoundOrRenamed.AllowFaultToAddRows = false;
			//this.dgvFoundOrRenamed.AllowFaultToDeleteRows = false;
			this.dgvFoundOrRenamed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFoundOrRenamed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvFoundOrRenamed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFoundOrRenamed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.NewName});
			this.dgvFoundOrRenamed.Location = new System.Drawing.Point(110, 2);
			this.dgvFoundOrRenamed.Name = "dgvFoundOrRenamed";
			this.dgvFoundOrRenamed.ReadOnly = true;
			this.dgvFoundOrRenamed.RowHeadersVisible = false;
			this.dgvFoundOrRenamed.Size = new System.Drawing.Size(698, 100);
			this.dgvFoundOrRenamed.TabIndex = 28;
			// 
			// Path
			// 
			this.Path.HeaderText = "Path";
			this.Path.Name = "Path";
			this.Path.ReadOnly = true;
			this.Path.Width = 54;
			// 
			// NewName
			// 
			this.NewName.HeaderText = "New Name";
			this.NewName.Name = "NewName";
			this.NewName.ReadOnly = true;
			this.NewName.Width = 85;
			// 
			// fbdSelectFolder
			// 
			this.fbdSelectFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// lblIncludeFiles
			// 
			this.lblIncludeFiles.AutoSize = true;
			this.lblIncludeFiles.Location = new System.Drawing.Point(12, 64);
			this.lblIncludeFiles.Name = "lblIncludeFiles";
			this.lblIncludeFiles.Size = new System.Drawing.Size(92, 13);
			this.lblIncludeFiles.TabIndex = 30;
			this.lblIncludeFiles.Text = "Include files (csv):";
			// 
			// txtIncludeFiles
			// 
			this.txtIncludeFiles.Location = new System.Drawing.Point(110, 61);
			this.txtIncludeFiles.Name = "txtIncludeFiles";
			this.txtIncludeFiles.Size = new System.Drawing.Size(273, 20);
			this.txtIncludeFiles.TabIndex = 31;
			this.txtIncludeFiles.Tag = "z";
			// 
			// txtExcludeFiles
			// 
			this.txtExcludeFiles.Location = new System.Drawing.Point(509, 62);
			this.txtExcludeFiles.Name = "txtExcludeFiles";
			this.txtExcludeFiles.Size = new System.Drawing.Size(299, 20);
			this.txtExcludeFiles.TabIndex = 32;
			// 
			// lblExcludeFiles
			// 
			this.lblExcludeFiles.AutoSize = true;
			this.lblExcludeFiles.Location = new System.Drawing.Point(401, 65);
			this.lblExcludeFiles.Name = "lblExcludeFiles";
			this.lblExcludeFiles.Size = new System.Drawing.Size(95, 13);
			this.lblExcludeFiles.TabIndex = 33;
			this.lblExcludeFiles.Text = "Exclude files (csv):";
			// 
			// dgvSkipped
			// 
			//this.dgvSkipped.AllowFaultToAddRows = false;
			//this.dgvSkipped.AllowFaultToDeleteRows = false;
			this.dgvSkipped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSkipped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvSkipped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSkipped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Reason});
			this.dgvSkipped.Location = new System.Drawing.Point(110, 0);
			this.dgvSkipped.Name = "dgvSkipped";
			this.dgvSkipped.ReadOnly = true;
			this.dgvSkipped.RowHeadersVisible = false;
			this.dgvSkipped.Size = new System.Drawing.Size(698, 105);
			this.dgvSkipped.TabIndex = 34;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Path";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 54;
			// 
			// Reason
			// 
			this.Reason.HeaderText = "Reason";
			this.Reason.Name = "Reason";
			this.Reason.ReadOnly = true;
			this.Reason.Width = 69;
			// 
			// lblSkipped
			// 
			this.lblSkipped.AutoSize = true;
			this.lblSkipped.Location = new System.Drawing.Point(13, 0);
			this.lblSkipped.Name = "lblSkipped";
			this.lblSkipped.Size = new System.Drawing.Size(46, 13);
			this.lblSkipped.TabIndex = 35;
			this.lblSkipped.Text = "Skipped";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 298);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lblSkipped);
			this.splitContainer1.Panel1.Controls.Add(this.dgvSkipped);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lblFoundOrRenamed);
			this.splitContainer1.Panel2.Controls.Add(this.dgvFoundOrRenamed);
			this.splitContainer1.Size = new System.Drawing.Size(819, 224);
			this.splitContainer1.SplitterDistance = 106;
			this.splitContainer1.SplitterIncrement = 2;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 36;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProcessed,
            this.lblProcessedCount,
            this.toolStripStatusLabel1,
            this.lblTotalCount,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 554);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(820, 22);
			this.statusStrip1.TabIndex = 37;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblProcessed
			// 
			this.lblProcessed.Name = "lblProcessed";
			this.lblProcessed.Size = new System.Drawing.Size(69, 17);
			this.lblProcessed.Text = "Processed : ";
			// 
			// lblProcessedCount
			// 
			this.lblProcessedCount.Name = "lblProcessedCount";
			this.lblProcessedCount.Size = new System.Drawing.Size(13, 17);
			this.lblProcessedCount.Text = "0";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
			this.toolStripStatusLabel1.Text = "/";
			// 
			// lblTotalCount
			// 
			this.lblTotalCount.Name = "lblTotalCount";
			this.lblTotalCount.Size = new System.Drawing.Size(13, 17);
			this.lblTotalCount.Text = "0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
			this.toolStripStatusLabel2.Text = "          ";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(48, 17);
			this.toolStripStatusLabel3.Text = "Status : ";
			// 
			// lblStatus
			// 
			this.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(16, 17);
			this.lblStatus.Text = "...";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 576);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.lblExcludeFiles);
			this.Controls.Add(this.txtExcludeFiles);
			this.Controls.Add(this.txtIncludeFiles);
			this.Controls.Add(this.lblIncludeFiles);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pbProgress);
			this.Controls.Add(this.btnSwitch);
			this.Controls.Add(this.btnRename);
			this.Controls.Add(this.lblReplaceWith);
			this.Controls.Add(this.txtReplaceWith);
			this.Controls.Add(this.chkOverwriteIfFileExists);
			this.Controls.Add(this.btnFindOnly);
			this.Controls.Add(this.chkRegularExpression);
			this.Controls.Add(this.chkFindCaseSensitive);
			this.Controls.Add(this.lblFind);
			this.Controls.Add(this.txtFindInName);
			this.Controls.Add(this.txtExcludeFolders);
			this.Controls.Add(this.lblExcludeFolders);
			this.Controls.Add(this.chkIncludeSubFolders);
			this.Controls.Add(this.btnSelectFolder);
			this.Controls.Add(this.txtTopFolder);
			this.Controls.Add(this.lblTopFolder);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(836, 615);
			this.Name = "Main";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Find And Rename";
			((System.ComponentModel.ISupportInitialize)(this.dgvFoundOrRenamed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkipped)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTopFolder;
		private System.Windows.Forms.TextBox txtTopFolder;
		private System.Windows.Forms.Button btnSelectFolder;
		private System.Windows.Forms.CheckBox chkIncludeSubFolders;
		private System.Windows.Forms.Label lblExcludeFolders;
		private System.Windows.Forms.TextBox txtExcludeFolders;
		private System.Windows.Forms.TextBox txtFindInName;
		private System.Windows.Forms.Label lblFind;
		private System.Windows.Forms.CheckBox chkFindCaseSensitive;
		private System.Windows.Forms.CheckBox chkRegularExpression;
		private System.Windows.Forms.Button btnFindOnly;
		private System.Windows.Forms.TextBox txtReplaceWith;
		private System.Windows.Forms.Label lblReplaceWith;
		private System.Windows.Forms.Button btnRename;
		private System.Windows.Forms.Button btnSwitch;
		private System.Windows.Forms.CheckBox chkOverwriteIfFileExists;
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblFoundOrRenamed;
		private System.Windows.Forms.DataGridView dgvFoundOrRenamed;
		private System.Windows.Forms.FolderBrowserDialog fbdSelectFolder;
		private System.Windows.Forms.Label lblIncludeFiles;
		private System.Windows.Forms.TextBox txtIncludeFiles;
		private System.Windows.Forms.TextBox txtExcludeFiles;
		private System.Windows.Forms.Label lblExcludeFiles;
		private System.Windows.Forms.DataGridView dgvSkipped;
		private System.Windows.Forms.Label lblSkipped;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
		private System.Windows.Forms.DataGridViewTextBoxColumn Path;
		private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblProcessed;
		private System.Windows.Forms.ToolStripStatusLabel lblProcessedCount;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel lblTotalCount;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
	}
}

