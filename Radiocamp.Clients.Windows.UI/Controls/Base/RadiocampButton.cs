using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class RadiocampButton : Button
	{

		public static readonly DependencyProperty RightClickCommandProperty = DependencyProperty.Register(nameof(RightClickCommand), typeof(ICommand), typeof(RadiocampButton), new PropertyMetadata(default(ICommand)));

		public ICommand RightClickCommand
		{
			get => (ICommand) GetValue(RightClickCommandProperty);
			set => SetValue(RightClickCommandProperty, value);
		}

		public RadiocampButton()
		{

			Focusable = false;
			SnapsToDevicePixels = true;
			UseLayoutRounding = true;

			MouseRightButtonDown += OnMouseRightButtonDown;

		}

		protected virtual void OnMouseRightButtonDown(Object sender, MouseButtonEventArgs args)
		{
			RightClickCommand?.Execute(null);
		}

	}
}