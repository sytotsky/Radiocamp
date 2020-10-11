using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.UI.Native;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Clients.Windows.Windows;
using DispatcherPriority = System.Windows.Threading.DispatcherPriority;
using WindowState = System.Windows.WindowState;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class MainWindowService : IMainWindow
	{

		private readonly ISettings settings;
		private readonly IApplication application;
		private readonly IHotkeys hotkeys;

		private Boolean visible;

		public RadiocampWindow Window
		{
			get => Application.Current.MainWindow as RadiocampWindow;
			private set => Application.Current.MainWindow = value;
		}

#pragma warning disable 0067

		public event Action EscapeEvent;
		public event Action HideEvent;

#pragma warning restore 0067

		public MainWindowService(ISettings settings, IApplication application, IHotkeys hotkeys)
		{
			this.settings = settings;
			this.application = application;
			this.hotkeys = hotkeys;
		}

		public void Initialize()
		{

			Window = new MainWindow();

			settings.MainWindowModeChanged += OnModeChanged;

			Show();
			OnModeChanged(settings.MainWindowMode);
			OnTopmostChanged(settings.MainWindowTopmost, settings.MainWindowTopmostOnlyCompact);
			OnHideInTaskbarChanged(settings.HideInTaskbar, settings.HideInTaskbarOnlyCompact);

			if (settings.AlwaysShowTrayIcon && settings.StartMinimized)
			{
				Hide();
			}

			HwndSource.FromHwnd(new WindowInteropHelper(Window).Handle).AddHook(WndProc);

			Window.WindowStateChanged += windowState => settings.SetMainWindowState(windowState);

			Window.InputBindings.AddRange(new List<InputBinding>()
			{
				new KeyBinding()
				{
					Command = new RelayCommand(OnEscape),
					Gesture = new KeyGesture(Key.Escape)
				}
			});

			hotkeys.ShowHideSwitchHotkeyPressed += OnShowHideSwitchHotkey;
			settings.MainWindowTopmostChanged += topmost => OnTopmostChanged(topmost, settings.MainWindowTopmostOnlyCompact);
			settings.MainWindowTopmostOnlyCompactChanged += onlyCompact => OnTopmostChanged(settings.MainWindowTopmost, onlyCompact);
			settings.HideInTaskbarChanged += hideInTaskbar => OnHideInTaskbarChanged(hideInTaskbar, settings.HideInTaskbarOnlyCompact);
			settings.HideInTaskbarOnlyCompactChanged += hideInTaskbarOnlyCompact => OnHideInTaskbarChanged(settings.HideInTaskbar, hideInTaskbarOnlyCompact);

		}

		public void Show()
		{

			Window.Show();
			Window.Activate();
			Window.Focus();

			Window.WindowState = WindowState.Normal;

			Boolean top = Window.Topmost;

			Window.Topmost = true;
			Window.Topmost = top;
			visible = true;

		}

		public void Hide()
		{

			visible = false;

			HideEvent?.Invoke();
			Window?.Hide();

		}

		public void Minimize()
		{
			Window.WindowState = WindowState.Minimized;
		}

		public void Toggle()
		{
			if (visible)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}

		public void Close()
		{
			Hide();
			application.Shutdown();
		}

		private void OnEscape()
		{
			EscapeEvent?.Invoke();
		}

		private void OnShowHideSwitchHotkey()
		{
			if (settings.AlwaysShowTrayIcon)
			{
				Toggle();
			}
		}

		private void OnModeChanged(WindowMode mode)
		{

			if (mode == WindowMode.Compact || mode == WindowMode.CompactAdvanced)
			{
				Window.WindowState = WindowState.Normal;
			}

			Window.Mode = mode;

			if (mode == WindowMode.Regular)
			{
				Window.Height = settings.MainWindowHeight;
			}
			else if (mode == WindowMode.CompactAdvanced)
			{
				Window.Height = settings.MainWindowCompactAdvancedHeight;
			}

			OnTopmostChanged(settings.MainWindowTopmost, settings.MainWindowTopmostOnlyCompact);
			OnHideInTaskbarChanged(settings.HideInTaskbar, settings.HideInTaskbarOnlyCompact);

		}

		private void OnTopmostChanged(Boolean topmost, Boolean onlyCompact)
		{
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				if (onlyCompact)
				{
					if (topmost)
					{
						if (settings.MainWindowMode != WindowMode.Regular)
						{
							Window.Topmost = topmost;
						}
						else
						{
							Window.Topmost = false;
						}
					}
					else
					{
						Window.Topmost = topmost;
					}
				}
				else
				{
					Window.Topmost = topmost;
				}
			}));
		}

		private void OnHideInTaskbarChanged(Boolean hideInTaskbar, Boolean onlyCompact)
		{

			Boolean showInTaskbar = !hideInTaskbar;

			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				if (onlyCompact)
				{
					if (hideInTaskbar)
					{
						if (settings.MainWindowMode != WindowMode.Regular)
						{
							Window.ShowInTaskbar = showInTaskbar;
						}
						else
						{
							Window.ShowInTaskbar = true;
						}
					}
					else
					{
						Window.ShowInTaskbar = showInTaskbar;
					}
				}
				else
				{
					Window.ShowInTaskbar = showInTaskbar;
				}
			}));

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