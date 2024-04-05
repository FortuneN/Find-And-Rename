using System;

namespace FR.Core
{
	internal interface IStringHelper
	{
		public string Reverse(string strValue);

		public string Replace(string strValue, string oldValue, string newValue, StringComparison comparisonType);
	}
}
