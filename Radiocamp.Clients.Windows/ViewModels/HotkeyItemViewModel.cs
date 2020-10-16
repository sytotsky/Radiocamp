using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class HotkeyItemViewModel : ViewModel
	{

		private readonly IHotkeys hotkeys;
		private readonly IDialogs dialogs;
		private readonly Guid id;

		[Reactive]
		public HotkeyCommand Command { get; set; }

		[Reactive]
		public Key Key { get; set; }

		[Reactive]
		public ModifierKeys ModifierKey { get; set; }

		[Reactive]
		public Boolean IsEnabled { get; set; }

		[Reactive]
		public Boolean IsEnabledCheckBoxEnabled { get; private set; }

		public ReactiveCommand<Unit, Unit> EditCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> RemoveCommand { get; private set; }

		public HotkeyItemViewModel(Hotkey hotkey)
		{

			hotkeys = Dependencies.Get<IHotkeys>();
			dialogs = Dependencies.Get<IDialogs>();

			id = hotkey.Id;
			Command = hotkey.Command;
			Key = hotkey.Key;
			ModifierKey = hotkey.ModifierKey;
			IsEnabled = hotkey.IsEnabled;
			IsEnabledCheckBoxEnabled = !(hotkey.ModifierKey == ModifierKeys.None && hotkey.Key == Key.None);

		}

		public override void Initialize()
		{
			
			base.Initialize();

			EditCommand = ReactiveCommand.CreateFromTask(Edit);
			RemoveCommand = ReactiveCommand.CreateFromTask(Remove);

			this.WhenAnyValue(viewModel => viewModel.IsEnabled)
				.Skip(1)
				.Subscribe(OnIsEnabledChanged);

		}

		private async Task Edit()
		{

			BaseWindow ownerWindow = Dependencies.Get<SettingsViewModel>().DialogWindow;

			Hotkey currentHotkey = new Hotkey()
			{
				Id = id,
				Command = Command,
				Key = Key,
				ModifierKey = ModifierKey,
				IsEnabled = IsEnabled
			};

			Hotkey newHotkey = await dialogs.Show<Hotkey, HotkeyEditorDialog, HotkeyEditorDialogViewModel>(new DialogArgs(ownerWindow, currentHotkey));

			if (newHotkey == null)
			{
				return;
			}

			Key = newHotkey.Key;
			ModifierKey = newHotkey.ModifierKey;
			IsEnabled = newHotkey.IsEnabled;

			await hotkeys.UpdateAsync(newHotkey);

		}

		private async Task Remove()
		{

			Key = Key.None;
			ModifierKey = ModifierKeys.None;
			IsEnabled = false;

			Hotkey hotkey = new Hotkey()
			{
				Id = id,
				Command = Command,
				Key = Key,
				ModifierKey = ModifierKey,
				IsEnabled = IsEnabled
			};

			await hotkeys.UpdateAsync(hotkey);

		}

		private async void OnIsEnabledChanged(Boolean isEnabled)
		{
			if (isEnabled)
			{
				await hotkeys.EnableAsync(id);
			}
			else
			{
				await hotkeys.DisableAsync(id);
			}
		}

	}
}