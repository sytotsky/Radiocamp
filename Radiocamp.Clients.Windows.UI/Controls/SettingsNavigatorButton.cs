using System;
using System.ComponentModel;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class SettingsNavigatorButton : OverButton
	{

		public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(Object), typeof(SettingsNavigatorButton), new PropertyMetadata(default(Object)));

		[Bindable(true)]
		public Object Icon
		{
			get => (Object) GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

		public static readonly DependencyProperty IconFontSizeProperty = DependencyProperty.Register(nameof(IconFontSize), typeof(Double), typeof(SettingsNavigatorButton), new PropertyMetadata(default(Double)));

		public Double IconFontSize
		{
			get => (Double) GetValue(IconFontSizeProperty);
			set => SetValue(IconFontSizeProperty, value);
		}

		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(String), typeof(SettingsNavigatorButton), new PropertyMetadata(default(String)));

		public String Description
		{
			get => (String) GetValue(DescriptionProperty);
			set => SetValue(DescriptionProperty, value);
		}

		public static readonly DependencyProperty IconRotateAngleProperty = DependencyProperty.Register(nameof(IconRotateAngle), typeof(Double), typeof(SettingsNavigatorButton), new PropertyMetadata(default(Double)));

		public Double IconRotateAngle
		{
			get => (Double) GetValue(IconRotateAngleProperty);
			set => SetValue(IconRotateAngleProperty, value);
		}

		public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(SettingsNavigatorButton), new PropertyMetadata(default(Thickness)));

		public Thickness IconMargin
		{
			get => (Thickness) GetValue(IconMarginProperty);
			set => SetValue(IconMarginProperty, value);
		}

	}
}