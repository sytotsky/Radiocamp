using System;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class DialogWindowViewModel : ViewModel
	{

		public Control Content { get; set; }

		public void OnKeyDown(Object sender, KeyEventArgs args)
		{

			if (args.Key == Key.System && args.SystemKey == Key.F4)
			{
				args.Handled = true;
			}

			if (args.Key == Key.Escape)
			{
				Dependencies.Get<IHotkeys>().RegisterAll();
				(sender as DialogWindow).Close();
			}

		}

	}
}