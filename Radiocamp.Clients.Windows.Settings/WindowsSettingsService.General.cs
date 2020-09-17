using System;
using System.Reflection;
using Microsoft.Win32;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		public String ApplicationName => "Radiocamp";

		[Default(false)]
		[UserSetting]
		public Boolean RunAtWindowsStart
		{
			get => GetAutostart();
			set => SetAutostart(value);
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