using System;
using System.Reactive;
using System.Windows;
using System.Windows.Forms;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.UI.Utilities;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class CompactViewViewModel : ViewModel
	{

		private readonly ISettings settings;
		private readonly IMainWindow mainWindow;
		private readonly Boolean isImmediatelyAfterLaunch;

		[Reactive]
		public Double CompactHeight { get; private set; }

		[Reactive]
		public Visibility Visibility { get; private set; }

		[Reactive]
		public Int32 AdvancedRow { get; private set; }

		[Reactive]
		public GridLength TopRowHeight { get; private set; }

		[Reactive]
		public GridLength BottomRowHeight { get; private set; }

		[Reactive]
		public Visibility AdvancedVisibility { get; private set; }

		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> RegularModeCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> AdvancedModeCommand { get; private set; }

		public CompactViewViewModel(ISettings settings, IMainWindow mainWindow)
		{

			this.settings = settings;
			this.mainWindow = mainWindow;

			CompactHeight = this.mainWindow.Window.CompactHeight;

			isImmediatelyAfterLaunch = true;

			CloseCommand = ReactiveCommand.Create(Close);
			RegularModeCommand = ReactiveCommand.Create(RegularMode);
			AdvancedModeCommand = ReactiveCommand.Create(AdvancedMode);

			Visibility = settings.MainWindowMode == WindowMode.Regular ? Visibility.Collapsed : Visibility.Visible;

			this.settings.MainWindowModeChanged += OnMainWindowModeChanged;

			OnMainWindowModeChanged(settings.MainWindowMode);

			isImmediatelyAfterLaunch = false;

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
			if (settings.MainWindowMode == WindowMode.Compact)
			{
				settings.MainWindowMode = WindowMode.CompactAdvanced;
			}
			else if (settings.MainWindowMode == WindowMode.CompactAdvanced)
			{
				settings.MainWindowMode = WindowMode.Compact;
			}
		}

		private void OnMainWindowModeChanged(WindowMode mode)
		{
			
			Visibility = mode == WindowMode.Regular ? Visibility.Collapsed : Visibility.Visible;
			AdvancedVisibility = mode == WindowMode.CompactAdvanced ? Visibility.Visible : Visibility.Collapsed;

			if (mode == WindowMode.CompactAdvanced)
			{

				Double compactAdvancedHeight = settings.MainWindowCompactAdvancedHeight;
				Double advancedRowHeight = compactAdvancedHeight - mainWindow.Window.CompactHeight;
				WPFScreen wpfScreen = WPFScreen.GetScreenFrom(mainWindow.Window);
				Screen currentScreen = wpfScreen.Screen;
				System.Drawing.Rectangle currentWorkingArea = currentScreen.WorkingArea;
				Int32 workingHeight = currentWorkingArea.Height;
				Double windowTop = mainWindow.Window.Top;

				if (settings.MainWindowAdvancedCompactPosition == AdvancedCompactPosition.None)
				{
					settings.MainWindowAdvancedCompactPosition = workingHeight - (windowTop + compactAdvancedHeight) < 0 ? AdvancedCompactPosition.Top : AdvancedCompactPosition.Bottom;
				}

				if (settings.MainWindowAdvancedCompactPosition == AdvancedCompactPosition.Top)
				{
					
					AdvancedRow = 0;
					TopRowHeight = new GridLength(advancedRowHeight, GridUnitType.Star);
					BottomRowHeight = new GridLength(0);
					
					if (!isImmediatelyAfterLaunch)
					{
						mainWindow.Window.Top -= advancedRowHeight;
					}

				}
				else if (settings.MainWindowAdvancedCompactPosition == AdvancedCompactPosition.Bottom)
				{
					AdvancedRow = 2;
					TopRowHeight = new GridLength(0);
					BottomRowHeight = new GridLength(advancedRowHeight, GridUnitType.Star);
				}

			}
			else
			{
				
				TopRowHeight = new GridLength(0);
				BottomRowHeight = new GridLength(0);

				if (settings.MainWindowAdvancedCompactPosition == AdvancedCompactPosition.Top)
				{
					mainWindow.Window.Top += settings.MainWindowCompactAdvancedHeight - mainWindow.Window.CompactHeight;
				}

				settings.MainWindowAdvancedCompactPosition = AdvancedCompactPosition.None;

			}

		}

	}
}