using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs args)
		{
			
			base.OnStartup(args);

			Dependencies.Services.AddDbContext<WindowsDatabaseContext>(builder =>
			{
				builder.UseSqlite("Data Source=Database.db");
			}, ServiceLifetime.Transient);

			Dependencies.Services.AddSingleton<ISettings, WindowsSettingsService>();
			Dependencies.Services.AddSingleton<IMainWindow, MainWindowService>();

			Dependencies.Build();

			Dependencies.Get<IMainWindow>().Initialize();

		}
	}
}