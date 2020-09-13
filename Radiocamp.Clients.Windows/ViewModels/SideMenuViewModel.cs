using System;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SideMenuViewModel : ViewModel
	{

		[Reactive]
		public Boolean Visible { get; set; }

		public SideMenuViewModel(SideMenuDimmableOverlayViewModel sideMenuDimmableOverlayViewModel, IMainWindow mainWindow)
		{
			sideMenuDimmableOverlayViewModel.Click += Hide;
			mainWindow.EscapeEvent += Hide;
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

	}
}