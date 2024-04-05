namespace FR.Core
{
	internal interface INameFilter
	{
		public void Configure(string[] excludeFolders, string[] includeFiles, string[] excludeFiles, string find, bool fine_caseSensitive, bool regularExpression);

		public bool Accept(string name, bool isFolder);
	}
}
