using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace FR.Core.Impl
{
	internal class EngineImpl : IFindAndRename
	{
		// state

		public bool IsRunning { get; private set; }

		// events

		public event Started Started;
		public event Status Status;
		public event Progress Progress;
		public event Stopped Stopped;

		// internal state

		private Thread _thread;
		private readonly IFileSystem _fileSystem;
		private readonly INameFilter _nameFilter;
		private readonly IServiceProvider _serviceProvider;
		private readonly INameTransformer _nameTransformer;
		private readonly IFileSystemHelper _fileSystemHelper;

		// constructors

		public EngineImpl
		(
			INameFilter nameFilter,
			IFileSystem fileSystem,
			IServiceProvider serviceProvider,
			INameTransformer nameTransformer,
			IFileSystemHelper fileSystemHelper
		)
		{
			_nameFilter = nameFilter;
			_fileSystem = fileSystem;
			_serviceProvider = serviceProvider;
			_nameTransformer = nameTransformer;
			_fileSystemHelper = fileSystemHelper;
		}

		// methods

		public Task StartAsync(FindAndRenameOptions options)
		{
			// input validation

			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}

			Validator.ValidateObject(options, new ValidationContext(options, _serviceProvider, default), true);

			// process

			var taskCompletionSource = new TaskCompletionSource<int>();

			_thread = new Thread(() =>
			{
				var cancelled = false;
				var error = default(Exception);

				try
				{
					Status?.Invoke(this, new StatusEventArgs
					{
						Status = "Initializing ..."
					});

					IsRunning = true;

					// announce start

					Started?.Invoke(this, new StartedEventArgs
					{
					});

					// check if top folder exists

					if (!_fileSystem.Directory.Exists(options.TopFolder))
					{
						throw new Exception($"Folder not found '{options.TopFolder}'");
					}

					// renaming

					Status?.Invoke(this, new StatusEventArgs
					{
						Status = "Finding ..."
					});

					_nameTransformer.Configure(options.Find_Text, options.Replacement_Text, options.Find_CaseSensitive, options.Find_RegularExpression);

					_nameFilter.Configure(options.ExcludeFolders, options.IncludeFiles, options.ExcludeFiles, options.Find_Text, options.Find_CaseSensitive, options.Find_RegularExpression);

					var totalEntryCount = 0m;

					var processedEntryCount = 0m;

					var paths = _fileSystemHelper.EnumerateFileSystemEntriesBottomUp(options.TopFolder, _nameFilter, options.IncludeSubFolders,
					entryCount =>
					{
						totalEntryCount = entryCount;

						Progress?.Invoke(this, new ProgressEventArgs
						{
							TotalCount = totalEntryCount,
							ProcessedCount = processedEntryCount,
							ProgressPercent = totalEntryCount <= 0 ? 0 : processedEntryCount / totalEntryCount * 100m,
						});
					},
					skipped =>
					{
						Progress?.Invoke(this, new ProgressEventArgs
						{
							Renamed = false,
							OldPath = skipped.Folder,
							TotalCount = totalEntryCount,
							Issue = skipped.Error.Message,
							ProcessedCount = processedEntryCount,
							OldName = _fileSystem.Path.GetFileName(skipped.Folder),
							ProgressPercent = totalEntryCount <= 0 ? 0 : processedEntryCount / totalEntryCount * 100m,
						});
					});

					var emitRenamingStatus = true;

					foreach (var fullPath in paths)
					{
						if (emitRenamingStatus)
						{
							emitRenamingStatus = false;

							Status?.Invoke(this, new StatusEventArgs
							{
								Status = $"Renaming ..."
							});
						}

						var issue = string.Empty;
						var newName = string.Empty;
						var newPath = string.Empty;
						var name = _fileSystem.Path.GetFileName(fullPath);
						var parentFolder = _fileSystem.Path.GetDirectoryName(fullPath);
						var relativePath = fullPath.Substring(options.TopFolder.Length).Trim('/', '\\', ' '); ;

						try
						{
							// change name

							newName = _nameTransformer.Transform(name);
							newPath = _fileSystem.Path.Combine(parentFolder, newName);

							if (!name.Equals(newName, StringComparison.Ordinal))
							{ 
								if (_fileSystem.Directory.Exists(fullPath))
								{
									if (!options.FindOnly)
									{
										var sourceDirectoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(fullPath);
										var targetDirectoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(newPath);
										_fileSystemHelper.MoveOrMergeDirectory(sourceDirectoryInfo, targetDirectoryInfo);
									}
								}
								else
								{
									if (_fileSystem.File.Exists(newPath) && !options.Replacement_OverwriteIfFileExists)
									{
										issue = $"'{newName}' already exists";
									}
									else
									{
										if (!options.FindOnly)
										{
											_fileSystem.FileInfo.FromFileName(fullPath).MoveTo(newPath);
										}
									}
								}
							}
						}
						catch (Exception exception)
						{
							issue = exception.Message;
						}
						finally
						{
							if (_nameFilter.Accept(name: name, isFolder: false))
							{
								processedEntryCount++;
								
								Progress?.Invoke(this, new ProgressEventArgs
								{
									Issue = issue,
									OldName = name,
									NewName = newName,
									NewPath = newPath,
									OldPath = fullPath,
									TotalCount = totalEntryCount,
									OldPathRelative = relativePath,
									ProcessedCount = processedEntryCount,
									Renamed = string.IsNullOrWhiteSpace(issue),
									ProgressPercent = processedEntryCount / totalEntryCount * 100,
								});
							}
						}
					}

					Progress?.Invoke(this, new ProgressEventArgs
					{
						ProgressPercent = 100m,
						TotalCount = processedEntryCount,
						ProcessedCount = processedEntryCount,
					});
				}
				catch (Exception exception)
				{
					if (exception is ThreadAbortException)
					{
						cancelled = true;
					}
					else
					{
						error = exception;
					}
				}
				finally
				{
					try
					{
						IsRunning = false;

						Stopped?.Invoke(this, new StoppedEventArgs
						{
							Error = error,
							Cancelled = cancelled,
						});
					}
					finally
					{
						taskCompletionSource.SetResult(default);
					}
				}
			});

			_thread.Start();

			return taskCompletionSource.Task;
		}

		public Task StopAsync()
		{
			try
			{
				_thread?.Abort();
			}
			catch
			{
				// ignore
			}

			return Task.CompletedTask;
		}
	}
}
