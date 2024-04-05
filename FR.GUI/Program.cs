using FR.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace FR.GUI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// services
			
			var services = new ServiceCollection();
			services.AddSingleton<Main>();
			services.AddSingleton<IFindAndRename, FindAndRename>();
			var serviceProvider = services.BuildServiceProvider();

			// application

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(serviceProvider.GetRequiredService<Main>());
		}
	}
}