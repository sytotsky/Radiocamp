﻿using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public interface ISettings
	{

		// Core

		void Initialize();
		Task ResetAsync();

		// Main window

		event Action<WindowMode> MainWindowModeChanged;

		Double MainWindowWidth { get; set; }
		Double MainWindowHeight { get; set; }
		Double MainWindowLeft { get; set; }
		Double MainWindowTop { get; set; }
		WindowMode MainWindowMode { get; set; }

		WindowState GetSetMainWindowState();
		void SetMainWindowState(WindowState windowState);

		// General

		String ApplicationName { get; }

		Boolean RunAtWindowsStart { get; set; }
		Boolean StartMinimized { get; set; }
		Boolean ShowFavoritesAtStart { get; set; }
		Boolean ShowOnlyCustomAtStart { get; set; }
		SearchEngine SearchEngine { get; set; }

		// Export radiostations

		String ExportRadiostationsFileFormat { get; }

		Boolean ExportRadiostationsAll { get; set; }
		Boolean ExportRadiostationsOnlyFavoritesOrCustom { get; set; }
		Boolean ExportRadiostationsFavoritesOnly { get; set; }
		Boolean ExportRadiostationsCustomOnly { get; set; }
		Boolean ExportRadiostationsSaveSoundSettings { get; set; }
		Boolean ExportRadiostationsSaveFavoritesTags { get; set; }
		ExportFormat ExportRadiostationsFormat { get; set; }
		String ExportRadiostationsPath { get; set; }
		
		// Tray

		event Action<Boolean> AlwaysShowTrayIconChanged;

		Boolean AlwaysShowTrayIcon { get; set; }
		Boolean HideApplicationOnCloseButtonClick { get; set; }
		Boolean HideApplicationOnMinimizeButtonClick { get; set; }

		// UI

		event Action<Localization> LocalizationChanged;
		event Action<Boolean> IsNightModeChanged;

		Localization Localization { get; set; }
		Boolean IsNightMode { get; set; }

		// Sound

		event Action<Int32> VolumeStepChanged;

		Int32 VolumeStep { get; set; }

		// Hotkeys

		event Action<Boolean> HotkeysIsEnabledChanged;

		Boolean HotkeysIsEnabled { get; set; }

	}
}