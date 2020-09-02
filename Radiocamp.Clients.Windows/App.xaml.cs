using System;
using System.IO;
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

			#if DEBUG
			String databaseConnectionSting = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Radiocamp", "Data.DEBUG.db")}";
			#else
			String databaseConnectionSting = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Radiocamp", "Data.db")}";
			#endif

			Dependencies.Services.AddDbContext<DatabaseContext>(builder =>
			{
				builder.UseSqlite(databaseConnectionSting);
			}, ServiceLifetime.Transient);

			Dependencies.Services.AddSingleton<ISettings, WindowsSettingsService>();
			Dependencies.Services.AddSingleton<IMainWindow, MainWindowService>();

			Dependencies.Build();

			Dependencies.Get<IMainWindow>().Initialize();

			ISettings settings = Dependencies.Get<ISettings>();

		}
	}
}