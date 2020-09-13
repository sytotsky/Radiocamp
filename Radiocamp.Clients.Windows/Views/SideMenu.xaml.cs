using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class SideMenu : UserControl
	{

		private readonly SideMenuViewModel viewModel;

		public SideMenu()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				viewModel = Dependencies.Get<SideMenuViewModel>();
				DataContext = viewModel;
			}

		}

		private void SideMenu_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{
			viewModel?.SideMenu_OnMouseDown(sender, args);
		}

	}
}