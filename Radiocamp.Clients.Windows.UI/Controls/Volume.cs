using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class Volume : UserControl
	{

		private Timer timer;

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(Double), typeof(UserControl), new PropertyMetadata(0.5D, new PropertyChangedCallback(OnValueChanged)));

		public Double Value
		{
			get => (Double)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public static readonly DependencyProperty IsMutedProperty = DependencyProperty.Register(nameof(IsMuted), typeof(Boolean), typeof(UserControl), new PropertyMetadata(false));

		public Boolean IsMuted
		{
			get => (Boolean)GetValue(IsMutedProperty);
			set => SetValue(IsMutedProperty, value);
		}

		public static readonly DependencyProperty MuteUnmuteCommandProperty = DependencyProperty.Register(nameof(MuteUnmuteCommand), typeof(ICommand), typeof(UserControl), new PropertyMetadata(default(ICommand)));

		public ICommand MuteUnmuteCommand
		{
			get => (ICommand)GetValue(MuteUnmuteCommandProperty);
			set => SetValue(MuteUnmuteCommandProperty, value);
		}

		public static readonly DependencyProperty StepProperty = DependencyProperty.Register(nameof(Step), typeof(Int32), typeof(UserControl), new PropertyMetadata(4));

		public Int32 Step
		{
			get => (Int32)GetValue(StepProperty);
			set => SetValue(StepProperty, value);
		}

		public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(nameof(Level), typeof(Int32), typeof(UserControl), new PropertyMetadata(default(Int32)));

		public Int32 Level
		{
			get => (Int32)GetValue(LevelProperty);
			set => SetValue(LevelProperty, value);
		}

		public static readonly DependencyProperty IsValueModeProperty = DependencyProperty.Register(nameof(IsValueMode), typeof(Boolean), typeof(UserControl), new PropertyMetadata(default(Boolean)));

		public Boolean IsValueMode
		{
			get => (Boolean)GetValue(IsValueModeProperty);
			set => SetValue(IsValueModeProperty, value);
		}

		public override void OnApplyTemplate()
		{

			base.OnApplyTemplate();

			((TextBlock)GetTemplateChild("SoundIcon")).MouseLeftButtonDown += SoundValue_OnMouseLeftButtonDown;
			((TextBlock)GetTemplateChild("Value")).MouseLeftButtonDown += SoundValue_OnMouseLeftButtonDown;

		}

		protected override void OnMouseWheel(MouseWheelEventArgs args)
		{

			base.OnMouseWheel(args);

			if (args.Delta > 0)
			{
				Value += Step;
			}
			else
			{
				Value -= Step;
			}

			if (Value > 100)
			{
				Value = 100;
			}

			if (Value < 0)
			{
				Value = 0;
			}

			args.Handled = true;

		}

		private static void OnValueChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is Volume volume))
			{
				return;
			}

			volume.timer?.Dispose();

			Double newValue = (Double)args.NewValue;
			Double oldValue = (Double)args.OldValue;

			if (oldValue == newValue)
			{
				return;
			}

			volume.IsValueMode = true;
			volume.timer = new Timer(volume.SetIconMode, null, 1000, Timeout.Infinite);

			if (newValue == 0)
			{
				volume.IsMuted = true;
			}
			else
			{
				volume.IsMuted = false;
			}

			if (newValue > 0 && newValue <= 33)
			{
				volume.Level = 1;
			}
			else if (newValue > 33 && newValue <= 66)
			{
				volume.Level = 2;
			}
			else if (newValue > 66 && newValue <= 100)
			{
				volume.Level = 3;
			}

		}

		private void SetIconMode(Object state = null)
		{

			timer?.Dispose();

			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				IsValueMode = false;
			}));

		}

		private void SoundValue_OnMouseLeftButtonDown(Object sender, MouseButtonEventArgs args)
		{
			MuteUnmuteCommand?.Execute(null);
		}

	}
}