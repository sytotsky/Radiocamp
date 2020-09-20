using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class RadiocampTextBox : TextBox
	{

		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(String), typeof(RadiocampTextBox), new PropertyMetadata(default(String)));

		public String Placeholder
		{
			get => (String) GetValue(PlaceholderProperty);
			set => SetValue(PlaceholderProperty, value);
		}

	}
}