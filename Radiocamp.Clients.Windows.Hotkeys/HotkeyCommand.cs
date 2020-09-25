using System;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public enum HotkeyCommand : Int32
	{
		[Localization("Hotkeys_PlayPause")]
		PlayPause = 1,
		[Localization("Hotkeys_StartStopRecord")]
		StartStopRecord = 2,
		[Localization("Hotkeys_MuteUnmute")]
		MuteUnmute = 3,
		[Localization("Hotkeys_VolumeUp")]
		VolumeUp = 4,
		[Localization("Hotkeys_VolumeDown")]
		VolumeDown = 5,
		[Localization("Hotkeys_ShowHideSwitch")]
		ShowHideSwitch = 6
	}
}