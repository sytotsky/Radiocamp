using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class SideMenuDimmableOverlay : UserControl
	{

		public SideMenuDimmableOverlay()
		{
			
			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<SideMenuDimmableOverlayViewModel>();
			}

		}

		private void SideMenuDimmableOverlay_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{
			if (DataContext is SideMenuDimmableOverlayViewModel viewModel)
			{
				viewModel.DimmableOverlay_OnMouseDown(sender, args);
			}
		}

	}
}