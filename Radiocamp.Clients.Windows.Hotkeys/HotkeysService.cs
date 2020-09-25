using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using DynamicData;
using NHotkey;
using NHotkey.Wpf;
using Dartware.Radiocamp.Desktop.Settings;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public sealed class HotkeysService<DatabaseContextType> : IHotkeys where DatabaseContextType : DbContext
	{

		private readonly DatabaseContextType databaseContext;
		private readonly ISettings settings;
		private readonly IDictionary<HotkeyCommand, Boolean> registered;

		public ISourceCache<Hotkey, HotkeyCommand> All { get; private set; }

		public event Action PlayPauseHotkeyPressed;
		public event Action StartStopRecordHotkeyPressed;
		public event Action MuteUnmuteHotkeyPressed;
		public event Action VolumeUpHotkeyPressed;
		public event Action VolumeDownHotkeyPressed;
		public event Action ShowHideSwitchHotkeyPressed;

		public HotkeysService(DatabaseContextType databaseContext, ISettings settings)
		{
			this.databaseContext = databaseContext;
			this.settings = settings;
			registered = new ConcurrentDictionary<HotkeyCommand, Boolean>();
			All = new SourceCache<Hotkey, HotkeyCommand>(hotkey => hotkey.Command);
		}

		public void Initialize()
		{

			All.AddOrUpdate(databaseContext.Set<Hotkey>().AsNoTracking().ToList());

			foreach (Hotkey hotkey in All.Items)
			{
				registered[hotkey.Command] = false;
			}

			if (settings.HotkeysIsEnabled)
			{
				RegisterAll();
			}

			settings.HotkeysIsEnabledChanged += OnHotkeysIsEnabledChanged;

		}

		public async Task UpdateAsync(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			Unregister(hotkey.Command);
			Register(hotkey);
			All.AddOrUpdate(hotkey);

			Hotkey hotkeyFromStorage = await databaseContext.Set<Hotkey>().AsTracking().FirstOrDefaultAsync(hotkeyItem => hotkeyItem.Command.Equals(hotkey.Command));

			if (hotkeyFromStorage != null)
			{

				hotkeyFromStorage.Key = hotkey.Key;
				hotkeyFromStorage.ModifierKey = hotkey.ModifierKey;
				hotkeyFromStorage.IsEnabled = hotkey.IsEnabled;

				await databaseContext.SaveChangesAsync();

			}

		}

		public async Task EnableAsync(HotkeyCommand command)
		{
			await EnableAsync(Get(command));
		}

		public async Task DisableAsync(HotkeyCommand command)
		{
			await DisableAsync(Get(command));
		}

		public void RegisterAll()
		{

			if (!settings.HotkeysIsEnabled)
			{
				return;
			}

			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				foreach (Hotkey hotkey in All.Items)
				{
					Register(hotkey);
				}
			}));

		}

		public void UnregisterAll()
		{
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				foreach (Hotkey hotkey in All.Items)
				{
					Unregister(hotkey.Command);
				}
			}));
		}

		public Boolean Any(Key key, ModifierKeys modifierKey) => All.Items.Any(hotkey => hotkey.Key == key && hotkey.ModifierKey == modifierKey);

		private async Task EnableAsync(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			hotkey.IsEnabled = true;

			await UpdateAsync(hotkey);

		}

		private async Task DisableAsync(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			hotkey.IsEnabled = false;

			await UpdateAsync(hotkey);

		}

		private Hotkey Get(HotkeyCommand command) => All.Items.FirstOrDefault(hotkey => hotkey.Command == command);

		private void Register(Hotkey hotkey)
		{

			if (!settings.HotkeysIsEnabled)
			{
				return;
			}

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			if (!hotkey.IsEnabled)
			{
				return;
			}

			if (hotkey.Key == Key.None || hotkey.ModifierKey == ModifierKeys.None)
			{
				return;
			}

			EventHandler<HotkeyEventArgs> handler = null;

			switch (hotkey.Command)
			{
				case HotkeyCommand.PlayPause: handler = (sender, args) => PlayPauseHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.StartStopRecord: handler = (sender, args) => StartStopRecordHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.MuteUnmute: handler = (sender, args) => MuteUnmuteHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.VolumeUp: handler = (sender, args) => VolumeUpHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.VolumeDown: handler = (sender, args) => VolumeDownHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.ShowHideSwitch: handler = (sender, args) => ShowHideSwitchHotkeyPressed?.Invoke(); break;
			}

			registered.TryGetValue(hotkey.Command, out Boolean isRegistered);

			if (handler != null && !isRegistered)
			{
				
				HotkeyManager.Current.AddOrReplace(Enum.GetName(typeof(HotkeyCommand), hotkey.Command), hotkey.Key, hotkey.ModifierKey, handler);
				
				registered[hotkey.Command] = true;

			}

		}

		private void Unregister(HotkeyCommand command)
		{
			
			registered.TryGetValue(command, out Boolean isRegistered);

			if (isRegistered)
			{

				HotkeyManager.Current.Remove(Enum.GetName(typeof(HotkeyCommand), command));

				registered[command] = false;

			}

		}

		private void OnHotkeysIsEnabledChanged(Boolean hotkeysIsEnabled)
		{
			if (hotkeysIsEnabled)
			{
				RegisterAll();
			}
			else
			{
				UnregisterAll();
			}
		}

	}
}