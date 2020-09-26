using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.UI.Native;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class MainWindowService : IMainWindow
	{

		private readonly ISettings settings;

#pragma warning disable 0067

		public event Action EscapeEvent;
		public event Action HideEvent;

#pragma warning restore 0067

		public RadiocampWindow Window
		{
			get => Application.Current.MainWindow as RadiocampWindow;
			private set => Application.Current.MainWindow = value;
		}

		public MainWindowService(ISettings settings)
		{
			this.settings = settings;
		}

		public void Initialize()
		{

			Window = new MainWindow();

			Show();
			HwndSource.FromHwnd(new WindowInteropHelper(Window).Handle).AddHook(WndProc);

			Window.WindowStateChanged += windowState => settings.MainWindowState = windowState;

			Window.InputBindings.AddRange(new List<InputBinding>()
			{
				new KeyBinding()
				{
					Command = new RelayCommand(OnEscape),
					Gesture = new KeyGesture(Key.Escape)
				}
			});

		}

		public void Show()
		{

			Window.Show();
			Window.Activate();
			Window.Focus();

			Boolean top = Window.Topmost;

			Window.Topmost = true;
			Window.Topmost = top;

		}

		private void OnEscape()
		{
			EscapeEvent?.Invoke();
		}

		private IntPtr WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
		{

			if (msg == NativeUtils.WM_SHOWME)
			{
				Show();
			}

			return IntPtr.Zero;

		}

	}
}