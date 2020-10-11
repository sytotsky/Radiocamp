using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

using WindowState = Dartware.Radiocamp.Clients.Windows.Settings.WindowState;

namespace Dartware.Radiocamp.Clients.Windows.UI.Windows
{
	public abstract partial class RadiocampWindow
	{

		private const Int32 STATE_CHANGED_TIMER_DUE_TIME = 300;

		private Timer stateChangedTimer;

		public event Action<WindowState> WindowStateChanged;

		private void OnStateSizeChanged(Object sender, SizeChangedEventArgs args)
		{

			stateChangedTimer?.Dispose();

			Double width = 0;
			Double height = 0;
			Double top = 0;
			Double left = 0;

			if (WindowState == System.Windows.WindowState.Maximized)
			{
				width = WidthBeforeMaximize;
				height = HeightBeforeMaximize;
				top = TopBeforeMaximize;
				left = LeftBeforeMaximize;
			}
			else
			{
				width = args.NewSize.Width;
				height = args.NewSize.Height;
				top = Top;
				left = Left;
			}

			WindowState windowState = new WindowState(width, height, left, top);

			stateChangedTimer = new Timer(ChangeState, windowState, STATE_CHANGED_TIMER_DUE_TIME, Timeout.Infinite);

		}

		private void OnStateLocationChanged(Object sender, EventArgs args)
		{

			stateChangedTimer?.Dispose();

			Double width = 0;
			Double height = 0;
			Double top = 0;
			Double left = 0;

			if (WindowState == System.Windows.WindowState.Maximized)
			{
				width = WidthBeforeMaximize;
				height = HeightBeforeMaximize;
				top = TopBeforeMaximize;
				left = LeftBeforeMaximize;
			}
			else
			{
				width = ActualWidth;
				height = ActualHeight;
				top = Top;
				left = Left;
			}

			WindowState windowState = new WindowState(width, height, left, top);

			stateChangedTimer = new Timer(ChangeState, windowState, STATE_CHANGED_TIMER_DUE_TIME, Timeout.Infinite);

		}

		private void ChangeState(Object state)
		{

			stateChangedTimer?.Dispose();

			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				if (state is WindowState windowState)
				{
					WindowStateChanged?.Invoke(windowState);
				}
			}));

		}

	}
}