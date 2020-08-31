using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class WindowButton : OverButton
	{

		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(nameof(Size), typeof(Double), typeof(WindowButton), new PropertyMetadata(default(Double)));

		public Double Size
		{
			get => (Double) GetValue(SizeProperty);
			set => SetValue(SizeProperty, value);
		}

		public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(String), typeof(WindowButton), new PropertyMetadata(default(String)));

		public String Icon
		{
			get => (String) GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

		public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(WindowButton), new PropertyMetadata(default(Thickness)));

		public Thickness IconMargin
		{
			get => (Thickness) GetValue(IconMarginProperty);
			set => SetValue(IconMarginProperty, value);
		}

		public static readonly DependencyProperty IconRotateAngleProperty = DependencyProperty.Register(nameof(IconRotateAngle), typeof(Double), typeof(WindowButton), new PropertyMetadata(default(Double)));

		public Double IconRotateAngle
		{
			get => (Double) GetValue(IconRotateAngleProperty);
			set => SetValue(IconRotateAngleProperty, value);
		}

	}
}