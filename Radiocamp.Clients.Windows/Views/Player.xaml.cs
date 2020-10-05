using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class Player : UserControl
	{

		public Player()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<PlayerViewModel>();
			}

		}

		protected override void OnMouseWheel(MouseWheelEventArgs args)
		{

			base.OnMouseWheel(args);

			(DataContext as PlayerViewModel)?.OnMouseWheel(args);

		}

	}
}