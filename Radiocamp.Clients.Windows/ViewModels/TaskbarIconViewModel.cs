using System;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Settings;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class TaskbarIconViewModel : ViewModel
	{

		[Reactive]
		public Boolean Visible { get; private set; }

		[Reactive]
		public String IconSource { get; set; }

		public TaskbarIconViewModel(ISettings settings)
		{

			Visible = settings.AlwaysShowTrayIcon;

			settings.AlwaysShowTrayIconChanged += alwaysShowTrayIcon => Visible = alwaysShowTrayIcon;

			#if DEBUG
			IconSource = "../../Resources/Icons/TaskbarIcon_Debug.ico";
			#else
			IconSource = "../../Resources/Icons/TaskbarIcon.ico";
			#endif

		}

	}
}