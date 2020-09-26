using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public interface ISettings
	{

		// Core

		void Initialize();
		Task ResetAsync();

		// Main window

		Double MainWindowWidth { get; set; }
		Double MainWindowHeight { get; set; }
		Double MainWindowLeft { get; set; }
		Double MainWindowTop { get; set; }
		WindowState MainWindowState { get; set; }

		// General

		String ApplicationName { get; }

		Boolean RunAtWindowsStart { get; set; }
		Boolean StartMinimized { get; set; }
		Boolean ShowFavoritesAtStart { get; set; }
		Boolean ShowOnlyCustomAtStart { get; set; }
		SearchEngine SearchEngine { get; set; }

		// Export radiostations

		String ExportRadiostationsFileFormat { get; }

		public Boolean ExportRadiostationsAll { get; set; }
		public Boolean ExportRadiostationsOnlyFavoritesOrCustom { get; set; }
		public Boolean ExportRadiostationsFavoritesOnly { get; set; }
		public Boolean ExportRadiostationsCustomOnly { get; set; }
		public Boolean ExportRadiostationsSaveSoundSettings { get; set; }
		public Boolean ExportRadiostationsSaveFavoritesTags { get; set; }
		public ExportFormat ExportRadiostationsFormat { get; set; }
		public String ExportRadiostationsPath { get; set; }

		// UI

		event Action<Localization> LocalizationChanged;
		event Action<Boolean> IsNightModeChanged;

		Localization Localization { get; set; }
		Boolean IsNightMode { get; set; }

		// Hotkeys

		event Action<Boolean> HotkeysIsEnabledChanged;

		Boolean HotkeysIsEnabled { get; set; }

	}
}