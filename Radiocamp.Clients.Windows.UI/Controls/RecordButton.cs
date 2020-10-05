using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class RecordButton : Button
	{

		public static readonly DependencyProperty StartCommandProperty = DependencyProperty.Register(nameof(StartCommand), typeof(ICommand), typeof(RecordButton), new PropertyMetadata(default(ICommand)));

		public ICommand StartCommand
		{
			get => (ICommand) GetValue(StartCommandProperty);
			set => SetValue(StartCommandProperty, value);
		}

		public static readonly DependencyProperty StopCommandProperty = DependencyProperty.Register(nameof(StopCommand), typeof(ICommand), typeof(RecordButton), new PropertyMetadata(default(ICommand)));

		public ICommand StopCommand
		{
			get => (ICommand) GetValue(StopCommandProperty);
			set => SetValue(StopCommandProperty, value);
		}

		public static readonly DependencyProperty IsRecordProperty = DependencyProperty.Register(nameof(IsRecord), typeof(Boolean), typeof(RecordButton), new PropertyMetadata(default(Boolean)));

		public Boolean IsRecord
		{
			get => (Boolean) GetValue(IsRecordProperty);
			private set => SetValue(IsRecordProperty, value);
		}

		protected override void OnClick()
		{
			
			base.OnClick();

			if (IsRecord)
			{
				StopCommand?.Execute(null);
			}
			else
			{
				StartCommand?.Execute(null);
			}

			IsRecord = !IsRecord;

		}

	}
}