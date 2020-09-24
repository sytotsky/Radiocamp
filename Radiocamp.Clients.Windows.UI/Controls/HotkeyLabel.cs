using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class HotkeyLabel : Label
	{
		
		public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(nameof(Key), typeof(Key), typeof(HotkeyLabel), new PropertyMetadata(default(Key)));

		public Key Key
		{
			get => (Key) GetValue(KeyProperty);
			set => SetValue(KeyProperty, value);
		}

		public static readonly DependencyProperty ModifierKeyProperty = DependencyProperty.Register(nameof(ModifierKey), typeof(ModifierKeys), typeof(HotkeyLabel), new PropertyMetadata(default(ModifierKeys)));

		public ModifierKeys ModifierKey
		{
			get => (ModifierKeys) GetValue(ModifierKeyProperty);
			set => SetValue(ModifierKeyProperty, value);
		}

	}
}