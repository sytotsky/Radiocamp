﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	public sealed class HotkeyConfiguration : IEntityTypeConfiguration<Hotkey>
	{
		public void Configure(EntityTypeBuilder<Hotkey> builder)
		{

			builder.ToTable("Hotkeys");
			builder.HasKey(hotkey => hotkey.Id);
			builder.HasAlternateKey(hotkey => hotkey.Command);

			IEnumerable<Hotkey> defaultHotkeys = new List<Hotkey>()
			{
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.PlayPause,
					IsEnabled = true,
					Key = Key.S,
					ModifierKey = ModifierKeys.Alt
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.StartStopRecord,
					IsEnabled = true,
					Key = Key.A,
					ModifierKey = ModifierKeys.Alt
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.MuteUnmute,
					IsEnabled = true,
					Key = Key.D,
					ModifierKey = ModifierKeys.Alt
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.VolumeUp,
					IsEnabled = true,
					Key = Key.Up,
					ModifierKey = ModifierKeys.Alt
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.VolumeDown,
					IsEnabled = true,
					Key = Key.Down,
					ModifierKey = ModifierKeys.Alt
				},
				new Hotkey()
				{
					Id = Guid.NewGuid(),
					Command = HotkeyCommand.ShowHideSwitch,
					IsEnabled = true,
					Key = Key.X,
					ModifierKey = ModifierKeys.Alt
				}
			};

			builder.HasData(defaultHotkeys);

		}
	}
}