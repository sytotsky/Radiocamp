using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class NavigationDrawerViewModel : ViewModel
	{

		private readonly IApplication application;
		private readonly IDialogs dialogs;
		private readonly IMainWindow mainWindow;
		private readonly IRadiostations radiostations;

		[Reactive]
		public Boolean Visible { get; set; }

		public ICommand ToggleCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand SettingsCommand { get; }
		public ICommand AboutCommand { get; }
		public ICommand ExitCommand { get; }

		public NavigationDrawerViewModel(IMainWindow mainWindow, IApplication application, IDialogs dialogs, ISettings settings, IRadiostations radiostations)
		{

			this.application = application;
			this.dialogs = dialogs;
			this.mainWindow = mainWindow;
			this.radiostations = radiostations;

			ToggleCommand = ReactiveCommand.Create(Toggle);
			CreateCommand = ReactiveCommand.CreateFromTask(Create);
			SettingsCommand = ReactiveCommand.CreateFromTask(Settings);
			AboutCommand = ReactiveCommand.CreateFromTask(About);
			ExitCommand = ReactiveCommand.Create(Exit);

			Dependencies.Get<NavigationDrawerDimmableOverlayViewModel>().Click += Hide;
			mainWindow.EscapeEvent += Hide;
			mainWindow.HideEvent += Hide;
			dialogs.ShowDialog += Hide;
			settings.MainWindowModeChanged += mode => Hide();

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

		private async Task Create()
		{
			await radiostations.CreateAsync();
		}

		private async Task Settings()
		{
			await dialogs.Show<SettingsDialog, SettingsViewModel>(null);
		}

		private async Task About()
		{
			await dialogs.Show<AboutDialog, AboutDialogViewModel>(new DialogArgs(mainWindow.Window));
		}

		private void Exit()
		{
			application.Shutdown();
		}

		private void OnVisibleChanged(Boolean visible)
		{
			Dependencies.Get<NavigationDrawerDimmableOverlayViewModel>().Visible = visible;
		}

	}
}