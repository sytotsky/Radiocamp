using System.ComponentModel;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class TopBar : View
	{
		public TopBar()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				NavigationDrawerToggleButton.DataContext = Dependencies.Get<NavigationDrawerViewModel>();
			}

		}
	}
}