using System;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.UI.ColorThemes;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;

namespace Dartware.Radiocamp.Clients.Windows
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs args)
		{
			
			base.OnStartup(args);

			#if DEBUG
			String databaseConnectionSting = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Radiocamp", "Data.DEBUG.V1.db")}";
			#else
			String databaseConnectionSting = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Radiocamp", "Data.V1.db")}";
			#endif

			Dependencies.Services.AddDbContext<DatabaseContext>(builder =>
			{
				builder.UseSqlite(databaseConnectionSting);
			}, ServiceLifetime.Transient);

			Dependencies.Services.AddSingleton<MainWindowViewModel>();
			Dependencies.Services.AddSingleton<NavigationDrawerDimmableOverlayViewModel>();
			Dependencies.Services.AddSingleton<NavigationDrawerViewModel>();
			Dependencies.Services.AddSingleton<SettingsViewModel>(provider => new SettingsViewModel(new DialogArgs(Dependencies.Get<IMainWindow>().Window)));
			Dependencies.Services.AddSingleton<TaskbarIconViewModel>();
			Dependencies.Services.AddSingleton<PlayerViewModel>();
			Dependencies.Services.AddSingleton<RegularViewViewModel>();
			Dependencies.Services.AddSingleton<CompactViewViewModel>();
			Dependencies.Services.AddSingleton<RadiostationsListViewModel>();

			Dependencies.Services.AddSingleton<IApplication, ApplicationService>();
			Dependencies.Services.AddSingleton<ISettings, SettingsService<DatabaseContext>>();
			Dependencies.Services.AddSingleton<IMainWindow, MainWindowService>();
			Dependencies.Services.AddSingleton<IHotkeys, HotkeysService<DatabaseContext>>();
			Dependencies.Services.AddSingleton<IDialogs, DialogsService>();
			Dependencies.Services.AddSingleton<IBrowser, BrowserService>();
			Dependencies.Services.AddSingleton<ILocalization, LocalizationService>();
			Dependencies.Services.AddSingleton<IColorThemes, ColorThemesService>();
			Dependencies.Services.AddSingleton<IRadiostations, RadiostationsService>();

			Dependencies.Build();

			ISettings settings = Dependencies.Get<ISettings>();

			settings.Initialize();
			Dependencies.Get<IMainWindow>().Initialize();
			Dependencies.Get<IHotkeys>().Initialize();
			Dependencies.Get<ILocalization>().Apply(settings.Localization);

			Dependencies.Get<IColorThemes>().IsNightMode = settings.IsNightMode;

		}

	}
}