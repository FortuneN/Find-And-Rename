using System;
using System.Linq;
using System.Text.RegularExpressions;
using WildcardMatch;

namespace FR.Core.Impl
{
	internal class NameFilterImpl : INameFilter
	{
		private string[] _excludeFolders;
		private string[] _includeFiles;
		private string[] _excludeFiles;
		private string _find;
		private bool _find_caseSensitive;
		private Regex _find_regularExpression;

		public void Configure(string[] excludeFolders, string[] includeFiles, string[] excludeFiles, string find, bool find_caseSensitive, bool find_regularExpression)
		{
			_excludeFolders = (excludeFolders ?? new string[0]).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();
			_includeFiles = (includeFiles ?? new string[0]).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();
			_excludeFiles = (excludeFiles ?? new string[0]).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();
			_find = find;
			_find_caseSensitive = find_caseSensitive;
			_find_regularExpression = find_regularExpression ? new Regex(find, find_caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase) : null;
		}

		public bool Accept(string name, bool isFolder)
		{
			if (string.IsNullOrEmpty(name))
			{
				return false;
			}

			// includes and excludes

			if (isFolder)
			{
				if (_excludeFolders.Any(pattern => pattern.WildcardMatch(name, true)))
				{
					return false;
				}
			}
			else
			{
				if (_excludeFiles.Any(pattern => pattern.WildcardMatch(name, true)))
				{
					return false;
				}

				if (_includeFiles.Any(pattern => !pattern.WildcardMatch(name, true)))
				{
					return false;
				}

				if (!string.IsNullOrWhiteSpace(_find))
				{
					if (_find_regularExpression != null)
					{
						if (!_find_regularExpression.IsMatch(name))
						{
							return false;
						}
					}
					else
					{
						if (name.IndexOf(_find, _find_caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) == -1)
						{
							return false;
						}
					}
				}
			}

			// success return

			return true;
		}
	}
}
