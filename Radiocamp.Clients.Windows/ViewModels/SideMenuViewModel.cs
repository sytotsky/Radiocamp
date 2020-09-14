using System;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using ReactiveUI;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SideMenuViewModel : ViewModel
	{

		private readonly SideMenuDimmableOverlayViewModel sideMenuDimmableOverlayViewModel;

		[Reactive]
		public Boolean Visible { get; set; }

		public ICommand ToggleCommand { get; }

		public SideMenuViewModel(SideMenuDimmableOverlayViewModel sideMenuDimmableOverlayViewModel, IMainWindow mainWindow)
		{

			this.sideMenuDimmableOverlayViewModel = sideMenuDimmableOverlayViewModel;

			ToggleCommand = ReactiveCommand.Create(Toggle);

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

		public void SideMenu_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{
			Hide();
		}

		private void OnVisibleChanged(Boolean visible)
		{
			sideMenuDimmableOverlayViewModel.Visible = visible;
		}

	}
}