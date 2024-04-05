using System;
using System.Text;

namespace FR.Core.Impl
{
	internal class StringHelperImpl : IStringHelper
	{
		public string Reverse(string strValue)
		{
			var array = strValue.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		public string Replace(string strValue, string oldValue, string newValue, StringComparison comparisonType)
		{
			// Check inputs.

			if (strValue == null)
			{
				// Same as original .NET C# string.Replace behavior.
				throw new ArgumentNullException(nameof(strValue));
			}

			if (strValue.Length == 0)
			{
				// Same as original .NET C# string.Replace behavior.
				return strValue;
			}

			if (oldValue == null)
			{
				// Same as original .NET C# string.Replace behavior.
				throw new ArgumentNullException(nameof(oldValue));
			}

			if (oldValue.Length == 0)
			{
				// Same as original .NET C# string.Replace behavior.
				throw new ArgumentException("String cannot be of zero length.");
			}


			//if (oldValue.Equals(newValue, comparisonType))
			//{
			//This condition has no sense
			//It will prevent method from replacesing: "Example", "ExAmPlE", "EXAMPLE" to "example"
			//return str;
			//}



			// Prepare string builder for storing the processed string.
			// Note: StringBuilder has a better performance than String by 30-40%.
			var resultStringBuilder = new StringBuilder(strValue.Length);



			// Analyze the replacement: replace or remove.
			bool isReplacementNullOrEmpty = string.IsNullOrEmpty(newValue);



			// Replace all values.
			const int valueNotFound = -1;
			int foundAt;
			int startSearchFromIndex = 0;
			while ((foundAt = strValue.IndexOf(oldValue, startSearchFromIndex, comparisonType)) != valueNotFound)
			{

				// Append all characters until the found replacement.
				int charsUntilReplacment = foundAt - startSearchFromIndex;
				bool isNothingToAppend = charsUntilReplacment == 0;
				if (!isNothingToAppend)
				{
					resultStringBuilder.Append(strValue, startSearchFromIndex, charsUntilReplacment);
				}



				// Process the replacement.
				if (!isReplacementNullOrEmpty)
				{
					resultStringBuilder.Append(newValue);
				}


				// Prepare start index for the next search.
				// This needed to prevent infinite loop, otherwise method always start search 
				// from the start of the string. For example: if an oldValue == "EXAMPLE", newValue == "example"
				// and comparisonType == "any ignore case" will conquer to replacing:
				// "EXAMPLE" to "example" to "example" to "example" … infinite loop.
				startSearchFromIndex = foundAt + oldValue.Length;
				if (startSearchFromIndex == strValue.Length)
				{
					// It is end of the input string: no more space for the next search.
					// The input string ends with a value that has already been replaced. 
					// Therefore, the string builder with the result is complete and no further action is required.
					return resultStringBuilder.ToString();
				}
			}


			// Append the last part to the result.
			int charsUntilStringEnd = strValue.Length - startSearchFromIndex;
			resultStringBuilder.Append(strValue, startSearchFromIndex, charsUntilStringEnd);


			return resultStringBuilder.ToString();
		}
	}
}
