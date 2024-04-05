using FR.Core;
using FR.GUI.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FR.GUI
{
	public partial class Main : Form
	{
		private readonly IFindAndRename _findAndRename;
		
		public Main(IFindAndRename findAndRename)
		{
			InitializeComponent();

			_findAndRename = findAndRename;
			_findAndRename.Started += Started;
			_findAndRename.Status += Status;
			_findAndRename.Stopped += Stopped;
			_findAndRename.Progress += Progress;
			
			UpdateUIState();
		}

		private void UpdateUIState()
		{
			lblTopFolder.Enabled = !_findAndRename.IsRunning;
			txtTopFolder.Enabled = !_findAndRename.IsRunning;
			btnSelectFolder.Enabled = !_findAndRename.IsRunning;

			chkIncludeSubFolders.Enabled = !_findAndRename.IsRunning;
			lblExcludeFolders.Enabled = !_findAndRename.IsRunning;
			txtExcludeFolders.Enabled = !_findAndRename.IsRunning;

			lblIncludeFiles.Enabled = !_findAndRename.IsRunning;
			txtIncludeFiles.Enabled = !_findAndRename.IsRunning;
			lblExcludeFiles.Enabled = !_findAndRename.IsRunning;
			txtExcludeFiles.Enabled = !_findAndRename.IsRunning;

			lblFind.Enabled = !_findAndRename.IsRunning;
			txtFindInName.Enabled = !_findAndRename.IsRunning;

			chkFindCaseSensitive.Enabled = !_findAndRename.IsRunning;
			chkRegularExpression.Enabled = !_findAndRename.IsRunning;
			chkOverwriteIfFileExists.Enabled = !_findAndRename.IsRunning;
			btnSwitch.Enabled = !_findAndRename.IsRunning;
			btnFindOnly.Enabled = !_findAndRename.IsRunning && txtTopFolder.Text.Trim().Length > 0 && txtFindInName.Text.Trim().Length > 0;

			lblReplaceWith.Enabled = !_findAndRename.IsRunning;
			txtReplaceWith.Enabled = !_findAndRename.IsRunning;
			btnRename.Enabled = !_findAndRename.IsRunning && txtTopFolder.Text.Trim().Length > 0 && txtFindInName.Text.Trim().Length > 0;

			btnCancel.Enabled = _findAndRename.IsRunning;
		}

		private FindAndRenameOptions GetOptions()
		{
			var options = new FindAndRenameOptions();
			options.TopFolder = txtTopFolder.Enabled ? txtTopFolder.Text : string.Empty;
			options.IncludeSubFolders = chkIncludeSubFolders.Enabled && chkIncludeSubFolders.Checked;
			options.ExcludeFolders = ToArray(txtExcludeFolders.Enabled ? txtExcludeFolders.Text : string.Empty);
			options.IncludeFiles = ToArray(txtIncludeFiles.Enabled ? txtIncludeFiles.Text : string.Empty);
			options.ExcludeFiles = ToArray(txtExcludeFiles.Enabled ? txtExcludeFiles.Text : string.Empty);
			options.Find_Text = txtFindInName.Enabled ? txtFindInName.Text : string.Empty;
			options.Find_CaseSensitive = chkFindCaseSensitive.Enabled && chkFindCaseSensitive.Checked;
			options.Find_RegularExpression = chkRegularExpression.Enabled && chkRegularExpression.Checked;
			options.Replacement_OverwriteIfFileExists = chkOverwriteIfFileExists.Enabled && chkOverwriteIfFileExists.Checked;
			options.Replacement_Text = txtReplaceWith.Enabled ? txtReplaceWith.Text : string.Empty;
			return options;
		}

		private void Started(object sender, StartedEventArgs e)
		{
			this.Invoke(() =>
			{
				dgvSkipped.Rows.Clear();
				lblTotalCount.Text = "0";				
				lblProcessedCount.Text = "0";
				lblStatus.Text = string.Empty;
				dgvFoundOrRenamed.Rows.Clear();
				UpdateUIState();
			});
		}

		private void Status(object sender, StatusEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(e.Status) && lblStatus.Text != e.Status)
			{
				lblStatus.Text = e.Status;
			}
		}

		private void Progress(object sender, ProgressEventArgs e)
		{
			this.Invoke(() =>
			{
				if (pbProgress.Maximum != 100)
				{
					pbProgress.Maximum = 100;
				}

				var totalCount = ((int)e.TotalCount).ToString();

				if (e.TotalCount > 0 && lblTotalCount.Text != totalCount)
				{
					lblTotalCount.Text = totalCount;
				}

				var processedCount = ((int)e.ProcessedCount).ToString();

				if (e.ProcessedCount > 0 && lblProcessedCount.Text != processedCount)
				{
					lblProcessedCount.Text = processedCount;
				}

				var progressPercent = (int)e.ProgressPercent;

				if (progressPercent > 0 && pbProgress.Value != progressPercent)
				{
					pbProgress.Value = progressPercent > 100 ? 100 : progressPercent;
				}

				if (!string.IsNullOrWhiteSpace(e.OldPath))
				{
					if (e.Renamed)
					{
						dgvFoundOrRenamed.Rows.Add(e.OldPathRelative, e.NewName);
						dgvFoundOrRenamed.FirstDisplayedScrollingRowIndex = dgvFoundOrRenamed.RowCount - 1;
					}
					else
					{
						dgvSkipped.Rows.Add(e.OldPathRelative, e.Issue);
						dgvSkipped.FirstDisplayedScrollingRowIndex = dgvSkipped.RowCount - 1;
					}
				}
			});
		}

		private void Stopped(object sender, StoppedEventArgs e)
		{
			this.Invoke(() =>
			{
				UpdateUIState();

				if (e.Error != null)
				{
					lblStatus.Text = $"Error : {e.Error.Message}";
					MessageBox.Show(e.Error.Message);
				}
				else if (e.Cancelled)
				{
					lblStatus.Text = "Cancelled";
				}
				else
				{
					lblStatus.Text = "Stopped";
				}
			});
		}

		private void btnSelectFolder_Click(object sender, EventArgs e)
		{
			var folderText = txtTopFolder.Text.Trim();

			if (System.IO.Directory.Exists(folderText))
			{
				fbdSelectFolder.SelectedPath = folderText;
			}

			var result = fbdSelectFolder.ShowDialog();

			if (result != DialogResult.OK)
			{
				return;
			}

			txtTopFolder.Text = fbdSelectFolder.SelectedPath;
		}

		private void txtFindInName_TextChanged(object sender, EventArgs e)
		{
			UpdateUIState();
		}

		private void btnSwitch_Click(object sender, EventArgs e)
		{
			var findInNameText = txtFindInName.Text;
			var replaceWithText = txtReplaceWith.Text;

			txtFindInName.Text = replaceWithText;
			txtReplaceWith.Text = findInNameText;
		}

		private void btnFindOnly_Click(object sender, EventArgs e)
		{
			var options = GetOptions();
			options.FindOnly = true;
			_findAndRename.StartAsync(options);
		}

		private void btnRename_Click(object sender, EventArgs e)
		{
			var options = GetOptions();
			_findAndRename.StartAsync(options);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_findAndRename.StopAsync();
		}

		private void txtTopFolder_TextChanged(object sender, EventArgs e)
		{
			UpdateUIState();
		}

		private static string[] ToArray(string strValue)
		{
			return (strValue ?? string.Empty)
			.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
			.Select(x => x.Trim())
			.ToArray();
		}
	}
}
