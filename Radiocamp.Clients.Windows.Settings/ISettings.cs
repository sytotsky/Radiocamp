using System;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public interface ISettings : ISettings<WindowsSettings>
	{

		event Action<Boolean> HotkeysIsEnabledChanged;
		event Action<Localization> LocalizationChanged;
		event Action<Boolean> IsNightModeChanged;

		String ApplicationName { get; }

		Double MainWindowWidth { get; set; }
		Double MainWindowHeight { get; set; }
		Double MainWindowLeft { get; set; }
		Double MainWindowTop { get; set; }
		WindowState MainWindowState { get; set; }
		Boolean RunAtWindowsStart { get; set; }
		Boolean StartMinimized { get; set; }
		Boolean ShowFavoritesAtStart { get; set; }
		Boolean ShowOnlyCustomAtStart { get; set; }
		SearchEngine SearchEngine { get; set; }
		Localization Localization { get; set; }
		Boolean IsNightMode { get; set; }
		Boolean HotkeysIsEnabled { get; set; }

	}
}