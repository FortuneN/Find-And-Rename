using System;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace FR.Core
{
	internal interface IFileSystemHelper
	{
		public void WriteLine(System.IO.Stream stream, string strValue);

		public void CopyOrMergeDirectory(IDirectoryInfo sourceDirectoryInfo, IDirectoryInfo targetDirectoryInfo);

		public void MoveOrMergeDirectory(IDirectoryInfo sourceDirectoryInfo, IDirectoryInfo targetDirectoryInfo);

		public IEnumerable<string> EnumerateFileSystemEntriesBottomUp(string folder, INameFilter filter, bool includeSubFolders, Action<long> entryCountCallback, Action<(string Folder, Exception Error)> skippedCallback);
	}
}
