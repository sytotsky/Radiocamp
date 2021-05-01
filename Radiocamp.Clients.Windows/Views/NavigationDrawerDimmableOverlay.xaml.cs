using System;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class NavigationDrawerDimmableOverlay : View<NavigationDrawerDimmableOverlayViewModel>
	{

		public NavigationDrawerDimmableOverlay()
		{
			InitializeComponent();
		}

		private void NavigationDrawerDimmableOverlay_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{
			ViewModel.DimmableOverlay_OnMouseDown(sender, args);
		}

	}
}