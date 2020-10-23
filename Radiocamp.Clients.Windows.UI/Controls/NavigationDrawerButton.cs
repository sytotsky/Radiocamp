using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class NavigationDrawerButton : OverButton
	{

		public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(String), typeof(NavigationDrawerButton), new PropertyMetadata(default(String)));

		public String Icon
		{
			get => (String) GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

	}
}