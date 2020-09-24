using System;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class HotkeyEditorDialogViewModel : DialogViewModel<Hotkey>
	{

		private readonly IHotkeys hotkeys;

		[Reactive]
		public Key? CurrentKey { get; private set; }

		[Reactive]
		public ModifierKeys? CurrentModifierKey { get; set; }

		[Reactive]
		public HotkeyCommand Command { get; private set; }

		[Reactive]
		public Key? Key { get; set; }

		[Reactive]
		public ModifierKeys? ModifierKey { get; set; }

		[Reactive]
		public Boolean IsEnabled { get; set; }

		public ReactiveCommand<Unit, Unit> SaveCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> RemoveCommand { get; private set; }

		public HotkeyEditorDialogViewModel(DialogArgs args) : base(args)
		{
			hotkeys = Dependencies.Get<IHotkeys>();
		}

		public override void Initialize()
		{

			base.Initialize();
			hotkeys.UnregisterAll();

			Width = 300;

			if (parameter is Hotkey hotkey)
			{
				Command = hotkey.Command;
				Key = CurrentKey = hotkey.Key;
				ModifierKey = CurrentModifierKey = hotkey.ModifierKey;
				IsEnabled = hotkey.IsEnabled;
			}

			SaveCommand = ReactiveCommand.Create(Save);
			RemoveCommand = ReactiveCommand.Create(Remove);

		}

		protected override void OnKeyDown(KeyEventArgs args)
		{
			base.OnKeyDown(args);
		}

		protected override void OnEnter()
		{
			base.OnEnter();
			Save();
		}

		public override void Dispose()
		{
			base.Dispose();
			hotkeys.RegisterAll();
		}

		private void Save()
		{

			Result = new Hotkey()
			{
				Command = Command,
				Key = Key,
				ModifierKey = ModifierKey,
				IsEnabled = IsEnabled
			};

			Close();

		}

		private void Remove()
		{

			Result = new Hotkey()
			{
				Command = Command,
				Key = null,
				ModifierKey = null,
				IsEnabled = false
			};

			Close();

		}

	}
}