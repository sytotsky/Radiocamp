using System.Reactive;
using System.Windows;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class CompactViewViewModel : ViewModel
	{

		private readonly ISettings settings;
		private readonly IMainWindow mainWindow;

		[Reactive]
		public Visibility Visibility { get; private set; }

		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> RegularModeCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> AdvancedModeCommand { get; private set; }

		public CompactViewViewModel(ISettings settings, IMainWindow mainWindow)
		{

			this.settings = settings;
			this.mainWindow = mainWindow;

			CloseCommand = ReactiveCommand.Create(Close);
			RegularModeCommand = ReactiveCommand.Create(RegularMode);
			AdvancedModeCommand = ReactiveCommand.Create(AdvancedMode);

			Visibility = settings.MainWindowMode == WindowMode.Regular ? Visibility.Collapsed : Visibility.Visible;

			this.settings.MainWindowModeChanged += OnMainWindowModeChanged;

		}

		private void Close()
		{
			if (settings.AlwaysShowTrayIcon && settings.HideApplicationOnCloseButtonClick)
			{
				mainWindow.Hide();
			}
			else
			{
				mainWindow.Close();
			}
		}

		private void RegularMode()
		{
			settings.MainWindowMode = WindowMode.Regular;
		}

		private void AdvancedMode()
		{
		}

		private void OnMainWindowModeChanged(WindowMode mode)
		{
			Visibility = mode == WindowMode.Regular ? Visibility.Collapsed : Visibility.Visible;
		}

	}
}