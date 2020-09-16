using System.ComponentModel;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class DialogDimmableOverlay : UserControl
	{
		public DialogDimmableOverlay()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<DialogDimmableOverlayViewModel>();
			}

		}
	}
}