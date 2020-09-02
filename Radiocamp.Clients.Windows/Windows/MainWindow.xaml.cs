using System.ComponentModel;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Windows
{
	public partial class MainWindow : RadiocampWindow
	{
		public MainWindow()
		{

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<MainWindowViewModel>();
			}

			InitializeComponent();

		}
	}
}