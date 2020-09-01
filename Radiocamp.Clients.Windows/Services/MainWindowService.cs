using System;
using System.Windows;
using System.Windows.Interop;
using Dartware.Radiocamp.Clients.Windows.UI.Native;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class MainWindowService : IMainWindow
	{

		public MainWindow Window
		{
			get => Application.Current.MainWindow as MainWindow;
			private set => Application.Current.MainWindow = value;
		}

		public void Initialize()
		{

			Window = new MainWindow();

			Show();
			HwndSource.FromHwnd(new WindowInteropHelper(Window).Handle).AddHook(WndProc);

		}

		public void Show()
		{

			Window.Show();

			Boolean top = Window.Topmost;

			Window.Topmost = true;
			Window.Topmost = top;

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