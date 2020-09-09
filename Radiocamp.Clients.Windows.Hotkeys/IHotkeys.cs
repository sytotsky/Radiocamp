using System;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public interface IHotkeys
	{

		event Action PlayPauseHotkeyPressed;
		event Action StartStopRecordHotkeyPressed;
		event Action MuteUnmuteHotkeyPressed;
		event Action VolumeUpHotkeyPressed;
		event Action VolumeDownHotkeyPressed;
		event Action ShowHideSwitchHotkeyPressed;
		
		void Initialize();
		void Update(Hotkey hotkey);
		void Enable(HotkeyCommand command);
		void Disable(HotkeyCommand command);

	}
}