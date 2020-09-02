using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

using WindowState = Dartware.Radiocamp.Clients.Windows.Core.Models.WindowState;

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

			WindowState windowState = new WindowState(args.NewSize.Width, args.NewSize.Height, Left, Top);

			stateChangedTimer = new Timer(ChangeState, windowState, STATE_CHANGED_TIMER_DUE_TIME, Timeout.Infinite);

		}

		private void OnStateLocationChanged(Object sender, EventArgs args)
		{

			stateChangedTimer?.Dispose();

			WindowState windowState = new WindowState(ActualWidth, ActualHeight, Left, Top);

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