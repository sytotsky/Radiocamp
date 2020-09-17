using System;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public interface ISettings : ISettings<WindowsSettings>
	{

		event Action<Boolean> HotkeysIsEnabledChanged;

		String ApplicationName { get; }

		Double MainWindowWidth { get; set; }
		Double MainWindowHeight { get; set; }
		Double MainWindowLeft { get; set; }
		Double MainWindowTop { get; set; }
		WindowState MainWindowState { get; set; }
		Boolean HotkeysIsEnabled { get; set; }
		Boolean RunAtWindowsStart { get; set; }
		Boolean StartMinimized { get; set; }

	}
}