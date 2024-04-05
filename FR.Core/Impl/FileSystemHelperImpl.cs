using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;

namespace FR.Core.Impl
{
	internal class FileSystemHelperImpl : IFileSystemHelper
	{
		private readonly IFileSystem _fileSystem;
		private readonly IStringHelper _stringHelper;

		public FileSystemHelperImpl
		(
			IFileSystem fileSystem,
			IStringHelper stringHelper
		)
		{
			_fileSystem = fileSystem;
			_stringHelper = stringHelper;
		}

		public void CopyOrMergeDirectory(IDirectoryInfo sourceDirectoryInfo, IDirectoryInfo targetDirectoryInfo)
		{
			if (!targetDirectoryInfo.Exists)
			{
				targetDirectoryInfo.Create();
			}

			foreach (var fileInfo in sourceDirectoryInfo.GetFiles())
			{
				var fullFilePath = _fileSystem.Path.Combine(targetDirectoryInfo.FullName, fileInfo.Name);
				fileInfo.CopyTo(fullFilePath, true);
			}

			foreach (var directoryInfo in sourceDirectoryInfo.GetDirectories())
			{
				var targetSubDirectoryInfo = targetDirectoryInfo.CreateSubdirectory(directoryInfo.Name);
				CopyOrMergeDirectory(directoryInfo, targetSubDirectoryInfo);
			}
		}
		public void MoveOrMergeDirectory(IDirectoryInfo sourceDirectoryInfo, IDirectoryInfo targetDirectoryInfo)
		{
			CopyOrMergeDirectory(sourceDirectoryInfo, targetDirectoryInfo);
			sourceDirectoryInfo.Delete(true);
		}

		public void WriteLine(System.IO.Stream stream, string strValue)
		{
			var buffer = Encoding.UTF8.GetBytes($"{strValue}{Environment.NewLine}");
			stream.Write(buffer, 0, buffer.Length);
		}

		public IEnumerable<string> EnumerateFileSystemEntriesBottomUp(string folder, INameFilter filter, bool includeSubFolders, Action<long> entryCountCallback, Action<(string Folder, Exception Error)> skippedCallback)
		{
			long entryCount = 0;
			string fileSystemEntriesFile = null;

			try
			{
				// STEP 1 => enumerate paths into a file

				fileSystemEntriesFile = _fileSystem.Path.GetTempFileName();

				using var fileSystemEntriesStream = _fileSystem.FileStream.Create(fileSystemEntriesFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, 4096, System.IO.FileOptions.DeleteOnClose);

				{
					var queuedFolders = new Queue<string>(new[] { folder });

					while (queuedFolders.Any())
					{
						var queuedFolder = queuedFolders.Dequeue();

						try
						{
							foreach (var path in _fileSystem.Directory.EnumerateFiles(queuedFolder, "*", System.IO.SearchOption.TopDirectoryOnly))
							{
								if (filter.Accept(name: _fileSystem.Path.GetFileName(path), isFolder: false))
								{
									entryCountCallback(++entryCount);

									// write file entry to file

									WriteLine(fileSystemEntriesStream, path);
								}
							}

							if (!includeSubFolders)
							{
								break;
							}

							foreach (var path in _fileSystem.Directory.EnumerateDirectories(queuedFolder, "*", System.IO.SearchOption.TopDirectoryOnly))
							{
								if (filter.Accept(name: _fileSystem.Path.GetFileName(path), isFolder: true))
								{
									if (filter.Accept(name: _fileSystem.Path.GetFileName(path), isFolder: false))
									{
										entryCountCallback(++entryCount);
									}

									// write folder entry to file

									WriteLine(fileSystemEntriesStream, path);

									// enque folder entry for processing inthe next [while] iteration

									queuedFolders.Enqueue(path);
								}
							}
						}
						catch (Exception exception)
						{
							skippedCallback((folder, exception));
						}
					}

					fileSystemEntriesStream.Flush();
				}

				// STEP 2 => enumerate paths from file into memory bottom-up

				{
					var index = 0;
					var lineSb = new StringBuilder();

					while (-index < fileSystemEntriesStream.Length)
					{
						fileSystemEntriesStream.Seek(--index, System.IO.SeekOrigin.End);

						var _byte = fileSystemEntriesStream.ReadByte();

						if (_byte == 10 && lineSb.Length > 0)
						{
							var output1 = _stringHelper.Reverse(lineSb.ToString().Trim('\r', '\n'));

							if (!string.IsNullOrWhiteSpace(output1))
							{
								yield return output1;
							}

							lineSb.Remove(0, lineSb.Length);
						}

						lineSb.Append((char)_byte);
					}

					var output2 = _stringHelper.Reverse(lineSb.ToString().Trim('\r', '\n'));

					if (!string.IsNullOrWhiteSpace(output2))
					{
						yield return output2;
					}
				}
			}
			finally
			{
				if (!string.IsNullOrWhiteSpace(fileSystemEntriesFile))
				{
					try
					{
						_fileSystem.File.Delete(fileSystemEntriesFile);
					}
					catch
					{
						// ignore
					}
				}
			}
		}
	}
}
