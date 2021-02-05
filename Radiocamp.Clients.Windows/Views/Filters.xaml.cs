using System.ComponentModel;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class Filters : UserControl
	{
		public Filters()
		{
			
			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<RadiostationsListViewModel>();
			}

		}
	}
}