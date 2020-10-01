using System;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SideMenuViewModel : ViewModel
	{

		private readonly IApplication application;
		private readonly IDialogs dialogs;
		private readonly IMainWindow mainWindow;

		[Reactive]
		public Boolean Visible { get; set; }

		public ICommand ToggleCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand SettingsCommand { get; }
		public ICommand AboutCommand { get; }
		public ICommand ExitCommand { get; }

		public SideMenuViewModel(IMainWindow mainWindow, IApplication application, IDialogs dialogs)
		{

			this.application = application;
			this.dialogs = dialogs;
			this.mainWindow = mainWindow;

			ToggleCommand = ReactiveCommand.Create(Toggle);
			CreateCommand = ReactiveCommand.Create(Create);
			SettingsCommand = ReactiveCommand.Create(Settings);
			AboutCommand = ReactiveCommand.Create(About);
			ExitCommand = ReactiveCommand.Create(Exit);

			Dependencies.Get<SideMenuDimmableOverlayViewModel>().Click += Hide;
			mainWindow.EscapeEvent += Hide;
			mainWindow.HideEvent += Hide;
			dialogs.ShowDialog += Hide;

			this.WhenAnyValue(viewModel => viewModel.Visible).Subscribe(OnVisibleChanged);
			
		}

		public void Show()
		{
			Visible = true;
		}

		public void Hide()
		{
			Visible = false;
		}

		public void Toggle()
		{
			Visible = !Visible;
		}

		private void Create()
		{
		}

		private async void Settings()
		{
			await dialogs.Show<SettingsDialog, SettingsViewModel>(null);
		}

		private async void About()
		{
			await dialogs.Show<AboutDialog, AboutDialogViewModel>(new DialogArgs(mainWindow.Window));
		}

		private void Exit()
		{
			application.Shutdown();
		}

		private void OnVisibleChanged(Boolean visible)
		{
			Dependencies.Get<SideMenuDimmableOverlayViewModel>().Visible = visible;
		}

	}
}