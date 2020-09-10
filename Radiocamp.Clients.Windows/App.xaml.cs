using System;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;

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
			Dependencies.Services.AddSingleton<IHotkeys, HotkeysService>();

			Dependencies.Services.AddSingleton<MainWindowViewModel>();
			Dependencies.Services.AddSingleton<DialogDimmableOverlayViewModel>();

			Dependencies.Build();

			Dependencies.Get<ISettings>().Initialize();
			Dependencies.Get<IHotkeys>().Initialize();
			Dependencies.Get<IMainWindow>().Initialize();

		}
	}
}