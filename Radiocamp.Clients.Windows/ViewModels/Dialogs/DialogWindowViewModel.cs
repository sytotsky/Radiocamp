using System;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels.Dialogs
{
	public sealed class DialogWindowViewModel : ViewModel
	{

		private readonly DialogWindow window;

		public Control Content { get; set; }

		public DialogWindowViewModel(DialogWindow window)
		{
			this.window = window;
		}

		public void OnKeyDown(Object sender, KeyEventArgs args)
		{

			if (args.Key == Key.System && args.SystemKey == Key.F4)
			{
				args.Handled = true;
			}

			if (args.Key == Key.Escape)
			{
				Dependencies.Get<IHotkeys>().RegisterAll();
				window.Close();
			}

		}

	}
}