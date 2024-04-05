using FR.Core.Impl;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace FR.Core
{
	public class FindAndRename : IFindAndRename
	{
		public event Started Started;
		public event Status Status;
		public event Progress Progress;
		public event Stopped Stopped;
		public bool IsRunning => _engine.IsRunning;

		private readonly IFindAndRename _engine;

		public FindAndRename()
		{
			// services

			var services = new ServiceCollection();
			services.AddSingleton<IFileSystem, FileSystem>();
			services.AddSingleton<IFindAndRename, EngineImpl>();
			services.AddSingleton<INameFilter, NameFilterImpl>();
			services.AddSingleton<IStringHelper, StringHelperImpl>();
			services.AddSingleton<INameTransformer, NameTransformerImpl>();
			services.AddSingleton<IFileSystemHelper, FileSystemHelperImpl>();
			var serviceProvider = services.BuildServiceProvider(); 

			// engine

			_engine = serviceProvider.GetRequiredService<IFindAndRename>();
			_engine.Started += (s, e) => Started?.Invoke(this, e);
			_engine.Status += (s, e) => Status?.Invoke(this, e);
			_engine.Progress += (s, e) => Progress?.Invoke(this, e);
			_engine.Stopped += (s, e) => Stopped?.Invoke(this, e);
		}

		public Task StartAsync(FindAndRenameOptions options) => _engine.StartAsync(options);

		public Task StopAsync() => _engine.StopAsync();
	}
}