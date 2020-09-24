using System;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class HotkeyItemViewModel : ViewModel
	{

		private readonly BaseWindow ownerWindow;
		private readonly IHotkeys hotkeys;
		private readonly IDialogs dialogs;

		[Reactive]
		public HotkeyCommand Command { get; set; }

		[Reactive]
		public Key? Key { get; set; }

		[Reactive]
		public ModifierKeys? ModifierKey { get; set; }

		[Reactive]
		public Boolean IsEnabled { get; set; }

		public ReactiveCommand<Unit, Unit> EditCommand { get; private set; }

		public HotkeyItemViewModel(BaseWindow ownerWindow)
		{

			this.ownerWindow = ownerWindow;
			hotkeys = Dependencies.Get<IHotkeys>();
			dialogs = Dependencies.Get<IDialogs>();

			Initialize();

		}

		public override void Initialize()
		{
			
			base.Initialize();

			EditCommand = ReactiveCommand.CreateFromTask(Edit);

		}

		private async Task Edit()
		{

			Hotkey hotkey = await dialogs.Show<Hotkey, HotkeyEditorDialog, HotkeyEditorDialogViewModel>(new DialogArgs(ownerWindow, new Hotkey()
			{
				Command = Command,
				Key = Key,
				ModifierKey = ModifierKey,
				IsEnabled = IsEnabled
			}));

			if (hotkey == null)
			{
				return;
			}

			Key = hotkey.Key;
			ModifierKey = hotkey.ModifierKey;
			IsEnabled = hotkey.IsEnabled;

			await hotkeys.UpdateAsync(hotkey);

		}

	}
}