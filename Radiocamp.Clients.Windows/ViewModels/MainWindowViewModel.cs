using System;
using System.Drawing;
using System.Windows.Forms;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.UI.Models;
using Dartware.Radiocamp.Clients.Windows.UI.Utilities;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class MainWindowViewModel : ViewModel
	{

		[Reactive]
		public Double Width { get; private set; }

		[Reactive]
		public Double Height { get; private set; }

		[Reactive]
		public Double Left { get; private set; }

		[Reactive]
		public Double Top { get; private set; }

		public MainWindowViewModel(ISettings settings)
		{

			if (settings.MainWindowState.IsZero)
			{
				settings.MainWindowState = GetDefaultWindowState();
			}

			Width = settings.MainWindowWidth;
			Height = settings.MainWindowHeight;
			Left = settings.MainWindowLeft;
			Top = settings.MainWindowTop;

		}

		private WindowState GetDefaultWindowState()
		{

			Double width = 400;
			Double height = 600;
			ScreenHelper screenHelper = new ScreenHelper();
			Screen primaryScreen = screenHelper.PrimaryScreen;
			Rectangle workingArea = primaryScreen.WorkingArea;
			Double top = (workingArea.Height - height) / 2;
			Double left = (workingArea.Width - width) / 2;

			return new WindowState(width, height, left, top);

		}

	}
}