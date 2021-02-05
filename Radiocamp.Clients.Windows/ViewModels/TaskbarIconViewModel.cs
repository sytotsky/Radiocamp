using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class TaskbarIconViewModel : ViewModel
	{

		[Reactive]
		public Boolean Visible { get; private set; }

		[Reactive]
		public String IconSource { get; set; }

		public ReactiveCommand<Unit, Unit> OpenCommand { get; }
		public ReactiveCommand<Unit, Unit> QuitCommand { get; }
		public ReactiveCommand<Unit, Unit> ToggleMainWindowCommand { get; }

		public TaskbarIconViewModel(ISettings settings, IMainWindow mainWindow, IApplication application)
		{

			Visible = settings.AlwaysShowTrayIcon;

			settings.AlwaysShowTrayIconChanged += alwaysShowTrayIcon => Visible = alwaysShowTrayIcon;
			application.ShutdownFast += () => Visible = false;

			OpenCommand = ReactiveCommand.Create(mainWindow.Show);
			QuitCommand = ReactiveCommand.Create(application.Shutdown);
			ToggleMainWindowCommand = ReactiveCommand.Create(mainWindow.Toggle);

			#if DEBUG
			IconSource = "../../Resources/Icons/TaskbarIcon_Debug.ico";
			#else
			IconSource = "../../Resources/Icons/TaskbarIcon.ico";
			#endif

		}

	}
}