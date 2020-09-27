using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	internal sealed class HotkeyConfiguration : IEntityTypeConfiguration<Hotkey>
	{
		public void Configure(EntityTypeBuilder<Hotkey> builder)
		{

			builder.ToTable("Hotkeys");
			builder.HasKey(hotkey => hotkey.Id);

			IEnumerable<Hotkey> defaultHotkeys = new List<Hotkey>()
			{
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.PlayPause,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.StartStopRecord,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.MuteUnmute,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.VolumeUp,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.VolumeDown,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.ShowHideSwitch,
					IsEnabled = false,
					Key = Key.None,
					ModifierKey = ModifierKeys.None
				}
			};

			builder.HasData(defaultHotkeys);

		}
	}
}