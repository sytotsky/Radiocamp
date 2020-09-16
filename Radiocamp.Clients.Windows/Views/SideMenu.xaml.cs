using System.ComponentModel;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class SideMenu : UserControl
	{
		public SideMenu()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<SideMenuViewModel>();
			}

		}
	}
}