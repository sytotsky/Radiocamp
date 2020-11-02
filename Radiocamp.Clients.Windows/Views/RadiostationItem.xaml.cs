using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class RadiostationItem : UserControl
	{
		
		public RadiostationItem()
		{
			InitializeComponent();
		}

		protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs args)
		{
			base.OnMouseLeftButtonDown(args);
			await (DataContext as RadiostationItemViewModel)?.Click();
		}

	}
}