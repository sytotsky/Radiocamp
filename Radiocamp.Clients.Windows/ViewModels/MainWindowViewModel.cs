using System;
using System.Drawing;
using System.Reactive;
using System.Windows.Forms;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.UI.Utilities;
using Dartware.Radiocamp.Clients.Windows.Settings;

using WindowState = Dartware.Radiocamp.Clients.Windows.Settings.WindowState;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class MainWindowViewModel : ViewModel
	{

		private readonly ISettings settings;
		private readonly IMainWindow mainWindow;

		[Reactive]
		public Double Width { get; private set; }

		[Reactive]
		public Double Height { get; private set; }

		[Reactive]
		public Double Left { get; private set; }

		[Reactive]
		public Double Top { get; private set; }

		[Reactive]
		public Double CompactAdvancedHeight { get; set; }

		[Reactive]
		public String Title { get; private set; }

		public ReactiveCommand<Unit, Unit> MinimizeCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> CompactCommand { get; private set; }

		public MainWindowViewModel(ISettings settings, IMainWindow mainWindow)
		{
			
			this.settings = settings;
			this.mainWindow = mainWindow;

			MinimizeCommand = ReactiveCommand.Create(Minimize);
			CloseCommand = ReactiveCommand.Create(Close);
			CompactCommand = ReactiveCommand.Create(Compact);

			WindowState windowState = settings.GetSetMainWindowState();

			if (windowState.IsZero)
			{

				windowState = GetDefaultWindowState();

				settings.SetMainWindowState(windowState);

			}

			Width = windowState.Width;
			Height = windowState.Height;
			CompactAdvancedHeight = windowState.CompactAdvancedHeight;
			Left = windowState.Left;
			Top = windowState.Top;
			Title = "Radiocamp";

			mainWindow.Window.InputBindings.Add(new KeyBinding()
			{
				Command = new RelayCommand(Close),
				Gesture = new KeyGesture(Key.F4, ModifierKeys.Alt)
			});

		}

		private WindowState GetDefaultWindowState()
		{

			Double width = 400;
			Double height = 600;
			ScreenHelper screenHelper = new ScreenHelper();
			Screen primaryScreen = screenHelper.PrimaryScreen;
			Rectangle workingArea = primaryScreen.WorkingArea;
			Double left = (workingArea.Width - width) / 2;
			Double top = (workingArea.Height - height) / 2;

			return new WindowState(width, height, left, top, settings.MainWindowCompactAdvancedHeight);

		}

		private void Minimize()
		{
			if (settings.AlwaysShowTrayIcon && settings.HideApplicationOnMinimizeButtonClick)
			{
				mainWindow.Hide();
			}
			else
			{
				mainWindow.Minimize();
			}
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

		private void Compact()
		{
			settings.MainWindowMode = WindowMode.Compact;
		}

	}
}