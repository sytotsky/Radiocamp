using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class ButtonWithDescription : RadiocampButton
	{

		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(String), typeof(ButtonWithDescription), new PropertyMetadata(default(String)));

		public String Description
		{
			get => (String) GetValue(DescriptionProperty);
			set => SetValue(DescriptionProperty, value);
		}

	}
}