using System.Threading.Tasks;

namespace FR.Core
{
	public interface IFindAndRename
	{
		bool IsRunning { get; }

		public event Started Started;
		
		public event Status Status;
		
		public event Progress Progress;
		
		public event Stopped Stopped;

		public Task StartAsync(FindAndRenameOptions options);

		public Task StopAsync();
	}
}
