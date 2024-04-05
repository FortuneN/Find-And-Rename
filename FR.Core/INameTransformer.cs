namespace FR.Core
{
	internal interface INameTransformer
	{
		public void Configure(string find, string replaceWith, bool find_caseSensitive, bool find_regularExpression);

		public string Transform(string name);
	}
}
