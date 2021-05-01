using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class CompactPlayer : View<PlayerViewModel>
	{

		public CompactPlayer()
		{
			InitializeComponent();
		}

		protected override void OnMouseWheel(MouseWheelEventArgs args)
		{
			base.OnMouseWheel(args);
			ViewModel.OnMouseWheel(args);
		}

	}
}