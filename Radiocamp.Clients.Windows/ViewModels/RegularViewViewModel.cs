using System.Windows;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RegularViewViewModel : ViewModel
	{

		[Reactive]
		public Visibility Visibility { get; private set; }

		public RegularViewViewModel(ISettings settings)
		{

			Visibility = settings.MainWindowMode == WindowMode.Regular ? Visibility.Visible : Visibility.Collapsed;

			settings.MainWindowModeChanged += OnMainWindowModeChanged;

		}

		private void OnMainWindowModeChanged(WindowMode mode)
		{
			Visibility = mode == WindowMode.Regular ? Visibility.Visible : Visibility.Collapsed;
		}

	}
}