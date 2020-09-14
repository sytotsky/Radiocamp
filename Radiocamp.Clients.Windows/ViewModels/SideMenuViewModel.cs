using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SideMenuViewModel : ViewModel
	{

		private readonly IApplication application;
		private readonly SideMenuDimmableOverlayViewModel sideMenuDimmableOverlayViewModel;

		[Reactive]
		public Boolean Visible { get; set; }

		public ICommand ToggleCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand SettingsCommand { get; }
		public ICommand AboutCommand { get; }
		public ICommand ExitCommand { get; }

		public SideMenuViewModel(SideMenuDimmableOverlayViewModel sideMenuDimmableOverlayViewModel, IMainWindow mainWindow, IApplication application)
		{

			this.sideMenuDimmableOverlayViewModel = sideMenuDimmableOverlayViewModel;
			this.application = application;

			ToggleCommand = ReactiveCommand.Create(Toggle);
			CreateCommand = ReactiveCommand.Create(Create);
			SettingsCommand = ReactiveCommand.Create(Settings);
			AboutCommand = ReactiveCommand.Create(About);
			ExitCommand = ReactiveCommand.Create(Exit);

			sideMenuDimmableOverlayViewModel.Click += Hide;
			mainWindow.EscapeEvent += Hide;

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

		private void Settings()
		{
		}

		private void About()
		{
		}

		private void Exit()
		{
			application.Shutdown();
		}

		private void OnVisibleChanged(Boolean visible)
		{
			sideMenuDimmableOverlayViewModel.Visible = visible;
		}

	}
}