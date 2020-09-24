using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

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
		void Enable(HotkeyCommand command);
		void Disable(HotkeyCommand command);
		void RegisterAll();
		void UnregisterAll();

	}
}