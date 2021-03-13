using System;
using System.Reflection;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Boolean startMinimized;
		private Boolean showFavoritesAtStart;
		private Boolean showOnlyCustomAtStart;
		private SearchEngine searchEngine;
		private Boolean showOnlyFavorites;
		private SortingType sortingType;

#pragma warning restore 0649

		public String ApplicationName => "Radiocamp";

		[NoStorage]
		[UserSetting]
		[Default(false)]
		public Boolean RunAtWindowsStart
		{
			get => GetAutostart();
			set => SetAutostart(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(startMinimized))]
		public Boolean StartMinimized
		{
			get => startMinimized;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(showFavoritesAtStart))]
		public Boolean ShowFavoritesAtStart
		{
			get => showFavoritesAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(ShowOnlyCustomAtStart))]
		public Boolean ShowOnlyCustomAtStart
		{
			get => showOnlyCustomAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(SearchEngine.Google)]
		[Field(nameof(searchEngine))]
		public SearchEngine SearchEngine
		{
			get => searchEngine;
			set => SetValue(value);
		}
		
		[Field(nameof(showOnlyFavorites))]
		public Boolean ShowOnlyFavorites
		{
			get => showOnlyFavorites;
			set => SetValue(value);
		}
		
		[Field(nameof(sortingType))]
		public SortingType SortingType
		{
			get => sortingType;
			set => SetValue(value);
		}

		private Boolean GetAutostart()
		{

			RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			Object value = registryKey.GetValue(ApplicationName);

			if (value == null)
			{
				return false;
			}

			if (((String) value) != Assembly.GetExecutingAssembly().Location)
			{
				return false;
			}

			return true;

		}

		private void SetAutostart(Boolean launchOnWindowsStart)
		{

			if (launchOnWindowsStart == GetAutostart())
			{
				return;
			}

			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			if (launchOnWindowsStart)
			{
				registryKey.SetValue(ApplicationName, Assembly.GetExecutingAssembly().Location);
			}
			else
			{
				registryKey.DeleteValue(ApplicationName);
			}

		}

	}
}