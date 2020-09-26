using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public interface IHotkeys
	{

		ISourceCache<Hotkey, HotkeyCommand> All { get; }

		event Action PlayPauseHotkeyPressed;
		event Action StartStopRecordHotkeyPressed;
		event Action MuteUnmuteHotkeyPressed;
		event Action VolumeUpHotkeyPressed;
		event Action VolumeDownHotkeyPressed;
		event Action ShowHideSwitchHotkeyPressed;
		
		void Initialize();
		Task UpdateAsync(Hotkey hotkey);
		Task EnableAsync(Guid id);
		Task DisableAsync(Guid id);
		void RegisterAll();
		void UnregisterAll();
		Boolean Any(Key key, ModifierKeys modifierKey);

	}
}