using System;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public sealed class Hotkey
	{
		public Guid Id { get; set; }
		public HotkeyCommand Command { get; set; }
		public Key Key { get; set; }
		public ModifierKeys ModifierKey { get; set; }
		public Boolean IsEnabled { get; set; }
	}
}