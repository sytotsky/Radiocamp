using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class NavigationDrawerDimmableOverlay : UserControl
	{

		public NavigationDrawerDimmableOverlay()
		{
			
			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<NavigationDrawerDimmableOverlayViewModel>();
			}

		}

		private void NavigationDrawerDimmableOverlay_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{
			if (DataContext is NavigationDrawerDimmableOverlayViewModel viewModel)
			{
				viewModel.DimmableOverlay_OnMouseDown(sender, args);
			}
		}

	}
}