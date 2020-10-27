using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class PlayPauseButton : Button
	{

		public static readonly DependencyProperty IsPlayProperty = DependencyProperty.Register(nameof(IsPlay), typeof(Boolean), typeof(PlayPauseButton), new PropertyMetadata(default(Boolean)));

		public Boolean IsPlay
		{
			get => (Boolean) GetValue(IsPlayProperty);
			set => SetValue(IsPlayProperty, value);
		}

		protected override void OnClick()
		{
			
			base.OnClick();

			IsPlay = !IsPlay;

		}

	}
}