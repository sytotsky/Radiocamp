using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class IconCheckBox : CheckBox
	{

		public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(String), typeof(IconCheckBox), new PropertyMetadata(default(String)));

		public String Icon
		{
			get => (String) GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

		public static readonly DependencyProperty CheckedIconProperty = DependencyProperty.Register(nameof(CheckedIcon), typeof(String), typeof(IconCheckBox), new PropertyMetadata(default(String)));

		public String CheckedIcon
		{
			get => (String) GetValue(CheckedIconProperty);
			set => SetValue(CheckedIconProperty, value);
		}

		public static readonly DependencyProperty OverForegroundProperty = DependencyProperty.Register(nameof(OverForeground), typeof(SolidColorBrush), typeof(IconCheckBox), new PropertyMetadata(default(SolidColorBrush)));

		public SolidColorBrush OverForeground
		{
			get => (SolidColorBrush) GetValue(OverForegroundProperty);
			set => SetValue(OverForegroundProperty, value);
		}

	}
}