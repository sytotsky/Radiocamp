using System.ComponentModel;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class TopBar : UserControl
	{
		public TopBar()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				SideMenuToggleButton.DataContext = Dependencies.Get<SideMenuViewModel>();
			}

		}
	}
}