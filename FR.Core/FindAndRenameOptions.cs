using System.ComponentModel.DataAnnotations;

namespace FR.Core
{
	public class FindAndRenameOptions
	{
		[Required]
		public virtual string TopFolder { get; set; }
		
		public virtual bool IncludeSubFolders { get; set; }
		
		public virtual string[] ExcludeFolders { get; set; }

		public virtual string[] IncludeFiles { get; set; }
		
		public virtual string[] ExcludeFiles { get; set; }

		[Required]
		public virtual string Find_Text { get; set; }

		public virtual bool Find_CaseSensitive { get; set; }
		
		public virtual bool Find_RegularExpression { get; set; }
		
		public virtual string Replacement_Text { get; set; }
		
		public virtual bool Replacement_OverwriteIfFileExists { get; set; }
		
		public virtual bool FindOnly { get; set; }
	}
}
