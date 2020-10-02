using System;
using System.Windows;
using System.Windows.Controls;
using Dartware.NRadio.Meta;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class FormatBitrate : Label
	{

		public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(nameof(Format), typeof(Format), typeof(FormatBitrate), new PropertyMetadata(default(Format)));

		public Format Format
		{
			get => (Format) GetValue(FormatProperty);
			set => SetValue(FormatProperty, value);
		}

		public static readonly DependencyProperty BitrateProperty = DependencyProperty.Register(nameof(Bitrate), typeof(Int32), typeof(FormatBitrate), new PropertyMetadata(default(Int32)));

		public Int32 Bitrate
		{
			get => (Int32) GetValue(BitrateProperty);
			set => SetValue(BitrateProperty, value);
		}

	}
}