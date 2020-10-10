using System;
using System.Windows;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.UI.Windows
{
	public partial class RadiocampWindow
	{

		public const Double COMPACT_HEIGHT = 50;

		public static readonly DependencyProperty ModeProperty = DependencyProperty.Register(nameof(Mode), typeof(WindowMode), typeof(RadiocampWindow), new PropertyMetadata(default(WindowMode)));

		public WindowMode Mode
		{
			get => (WindowMode) GetValue(ModeProperty);
			set => SetValue(ModeProperty, value);
		}

		public static readonly DependencyProperty CompactCommandProperty = DependencyProperty.Register(nameof(CompactCommand), typeof(ICommand), typeof(RadiocampWindow), new PropertyMetadata(default(ICommand)));

		public ICommand CompactCommand
		{
			get => (ICommand) GetValue(CompactCommandProperty);
			set => SetValue(CompactCommandProperty, value);
		}

		public static readonly DependencyProperty CompactHeightProperty = DependencyProperty.Register(nameof(CompactHeight), typeof(Double), typeof(RadiocampWindow), new PropertyMetadata(default(Double)));

		public Double CompactHeight
		{
			get => (Double) GetValue(CompactHeightProperty);
			set => SetValue(CompactHeightProperty, value);
		}

		public static readonly DependencyProperty CompactAdvancedHeightProperty = DependencyProperty.Register(nameof(CompactAdvancedHeight), typeof(Double), typeof(RadiocampWindow), new PropertyMetadata(default(Double)));

		public Double CompactAdvancedHeight
		{
			get => (Double) GetValue(CompactAdvancedHeightProperty);
			set => SetValue(CompactAdvancedHeightProperty, value);
		}

		private void CompactModeButton_Click(Object sender, RoutedEventArgs args)
		{
			CompactCommand?.Execute(null);
		}

	}
}