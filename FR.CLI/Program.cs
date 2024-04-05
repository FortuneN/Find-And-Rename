using FR.Core;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FR.CLI
{
	[Command(Name = "firen", FullName = "Find And Rename")]
	public class Program : FindAndRenameOptions
	{
		[Option(LongName = "--top-folder", ShortName = "-tf", Description = "Top Folder")]
		public override string TopFolder { get; set; }

		[Option(LongName = "--include-sub-folders", ShortName = "-isf", Description = "Include Sub-Folders")]
		public override bool IncludeSubFolders { get; set; }

		[Option(LongName = "--exclude-folders", ShortName = "-efo", Description = "Exclude Folders")]
		public override string[] ExcludeFolders { get; set; }

		[Option(LongName = "--include-files", ShortName = "-if", Description = "Include Files")]
		public override string[] IncludeFiles { get; set; }

		[Option(LongName = "--exclude-file", ShortName = "-efi", Description = "Exclude Files")]
		public override string[] ExcludeFiles { get; set; }

		[Required]
		[Option(LongName = "--find-text", ShortName = "-ft", Description = "Find : Text")]
		public override string Find_Text { get; set; }

		[Option(LongName = "--find-case-sensitive", ShortName = "-fcs", Description = "Find : Case Sensitive")]
		public override bool Find_CaseSensitive { get; set; }

		[Option(LongName = "--find-regular-expression", ShortName = "-fre", Description = "Find : Regular Expression")]
		public override bool Find_RegularExpression { get; set; }

		[Option(LongName = "--replacement-text", ShortName = "-rt", Description = "Replacement : Text")]
		public override string Replacement_Text { get; set; }

		[Option(LongName = "--replacement-overwrite", ShortName = "-ro", Description = "Replacement : Overwrite if file exists (on rename)")]
		public override bool Replacement_OverwriteIfFileExists { get; set; }

		[Option(LongName = "--find-only", ShortName = "-fo", Description = "Find only (no replace)")]
		public override bool FindOnly { get; set; }

		public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

		public async Task<int> OnExecuteAsync(CommandLineApplication app, IConsole console)
		{
			var validationResult = app.GetValidationResult();

			if (!string.IsNullOrWhiteSpace(validationResult.ErrorMessage))
			{
				app.ShowHelp();
				console.WriteLine(validationResult.ErrorMessage);
				return 1;
			}

			var findAndRename = new FindAndRename();

			await findAndRename.StartAsync(this);
			
			return 0;
		}
	}
}
