using System.ComponentModel;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public abstract class SettingsView : UserControl
	{
		public SettingsView()
		{
			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = Dependencies.Get<SettingsViewModel>();
			}
		}
	}
}