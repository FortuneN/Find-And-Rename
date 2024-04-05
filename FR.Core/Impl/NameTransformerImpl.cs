using System;
using System.Text.RegularExpressions;

namespace FR.Core.Impl
{
	internal class NameTransformerImpl : INameTransformer
	{
		private string _find;
		private string _replaceWith;
		private bool _find_caseSensitive;
		private Regex _find_regularExpression;

		private readonly IStringHelper _stringHelper;

		public NameTransformerImpl(IStringHelper stringHelper)
		{
			_stringHelper = stringHelper;
		}

		public void Configure(string find, string replaceWith, bool find_caseSensitive, bool find_regularExpression)
		{
			_find = find;
			_replaceWith = replaceWith;
			_find = find;
			_find_caseSensitive = find_caseSensitive;
			_find_regularExpression = find_regularExpression ? new Regex(find, find_caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase) : null;
		}

		public string Transform(string name)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(_find))
			{
				return name;
			}

			var result = default(string);

			if (_find_regularExpression != null)
			{
				result = _find_regularExpression.Replace(name, _replaceWith);
			}
			else
			{
				result = _stringHelper.Replace(name, _find, _replaceWith, _find_caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
			}

			return result;
		}
	}
}
