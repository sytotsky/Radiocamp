using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class PlayPauseButton : Button
	{

		public static readonly DependencyProperty PlayCommandProperty = DependencyProperty.Register(nameof(PlayCommand), typeof(ICommand), typeof(PlayPauseButton), new PropertyMetadata(default(ICommand)));

		public ICommand PlayCommand
		{
			get => (ICommand) GetValue(PlayCommandProperty);
			set => SetValue(PlayCommandProperty, value);
		}

		public static readonly DependencyProperty PauseCommandProperty = DependencyProperty.Register(nameof(PauseCommand), typeof(ICommand), typeof(PlayPauseButton), new PropertyMetadata(default(ICommand)));

		public ICommand PauseCommand
		{
			get => (ICommand) GetValue(PauseCommandProperty);
			set => SetValue(PauseCommandProperty, value);
		}

		public static readonly DependencyProperty IsPlayProperty = DependencyProperty.Register(nameof(IsPlay), typeof(Boolean), typeof(PlayPauseButton), new PropertyMetadata(default(Boolean)));

		public Boolean IsPlay
		{
			get => (Boolean) GetValue(IsPlayProperty);
			private set => SetValue(IsPlayProperty, value);
		}

		protected override void OnClick()
		{
			
			base.OnClick();

			if (IsPlay)
			{
				PauseCommand?.Execute(null);
			}
			else
			{
				PlayCommand?.Execute(null);
			}

			IsPlay = !IsPlay;

		}

	}
}