using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class RecordButton : Button
	{

		public static readonly DependencyProperty IsRecordingProperty = DependencyProperty.Register(nameof(IsRecording), typeof(Boolean), typeof(RecordButton), new PropertyMetadata(default(Boolean)));

		public Boolean IsRecording
		{
			get => (Boolean) GetValue(IsRecordingProperty);
			set => SetValue(IsRecordingProperty, value);
		}

		protected override void OnClick()
		{
			
			base.OnClick();

			IsRecording = !IsRecording;

		}

	}
}