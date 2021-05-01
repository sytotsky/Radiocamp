using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class Player : View<PlayerViewModel>
	{

		public Player()
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