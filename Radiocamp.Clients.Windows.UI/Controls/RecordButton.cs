using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class RecordButton : Button
	{

		public static readonly DependencyProperty IsRecordProperty = DependencyProperty.Register(nameof(IsRecord), typeof(Boolean), typeof(RecordButton), new PropertyMetadata(default(Boolean)));

		public Boolean IsRecord
		{
			get => (Boolean) GetValue(IsRecordProperty);
			set => SetValue(IsRecordProperty, value);
		}

		protected override void OnClick()
		{
			
			base.OnClick();

			IsRecord = !IsRecord;

		}

	}
}