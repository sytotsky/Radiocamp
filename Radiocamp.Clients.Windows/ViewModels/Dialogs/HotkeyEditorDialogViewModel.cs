using System;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;

using KeyType = System.Windows.Input.Key;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class HotkeyEditorDialogViewModel : DialogViewModel<Hotkey>
	{

		private readonly IHotkeys hotkeys;

		[Reactive]
		public Key CurrentKey { get; private set; }

		[Reactive]
		public ModifierKeys CurrentModifierKey { get; set; }

		[Reactive]
		public HotkeyCommand Command { get; private set; }

		[Reactive]
		public KeyType Key { get; set; }

		[Reactive]
		public ModifierKeys ModifierKey { get; set; }

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

			Key = DetectKey();
			ModifierKey = DetectModifierKey();

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
				Key = Key.None,
				ModifierKey = ModifierKeys.None,
				IsEnabled = false
			};

			Close();

		}

		private KeyType DetectKey()
		{
			if (Keyboard.IsKeyDown(KeyType.A)) return KeyType.A;
			else if (Keyboard.IsKeyDown(KeyType.B)) return KeyType.B;
			else if (Keyboard.IsKeyDown(KeyType.C)) return KeyType.C;
			else if (Keyboard.IsKeyDown(KeyType.D)) return KeyType.D;
			else if (Keyboard.IsKeyDown(KeyType.E)) return KeyType.E;
			else if (Keyboard.IsKeyDown(KeyType.F)) return KeyType.F;
			else if (Keyboard.IsKeyDown(KeyType.G)) return KeyType.G;
			else if (Keyboard.IsKeyDown(KeyType.H)) return KeyType.H;
			else if (Keyboard.IsKeyDown(KeyType.I)) return KeyType.I;
			else if (Keyboard.IsKeyDown(KeyType.J)) return KeyType.J;
			else if (Keyboard.IsKeyDown(KeyType.K)) return KeyType.K;
			else if (Keyboard.IsKeyDown(KeyType.L)) return KeyType.L;
			else if (Keyboard.IsKeyDown(KeyType.M)) return KeyType.M;
			else if (Keyboard.IsKeyDown(KeyType.N)) return KeyType.N;
			else if (Keyboard.IsKeyDown(KeyType.O)) return KeyType.O;
			else if (Keyboard.IsKeyDown(KeyType.P)) return KeyType.P;
			else if (Keyboard.IsKeyDown(KeyType.Q)) return KeyType.Q;
			else if (Keyboard.IsKeyDown(KeyType.R)) return KeyType.R;
			else if (Keyboard.IsKeyDown(KeyType.S)) return KeyType.S;
			else if (Keyboard.IsKeyDown(KeyType.T)) return KeyType.T;
			else if (Keyboard.IsKeyDown(KeyType.U)) return KeyType.U;
			else if (Keyboard.IsKeyDown(KeyType.V)) return KeyType.V;
			else if (Keyboard.IsKeyDown(KeyType.W)) return KeyType.W;
			else if (Keyboard.IsKeyDown(KeyType.X)) return KeyType.X;
			else if (Keyboard.IsKeyDown(KeyType.Y)) return KeyType.Y;
			else if (Keyboard.IsKeyDown(KeyType.Z)) return KeyType.Z;
			else if (Keyboard.IsKeyDown(KeyType.D0)) return KeyType.D0;
			else if (Keyboard.IsKeyDown(KeyType.D1)) return KeyType.D1;
			else if (Keyboard.IsKeyDown(KeyType.D2)) return KeyType.D2;
			else if (Keyboard.IsKeyDown(KeyType.D3)) return KeyType.D3;
			else if (Keyboard.IsKeyDown(KeyType.D4)) return KeyType.D4;
			else if (Keyboard.IsKeyDown(KeyType.D5)) return KeyType.D5;
			else if (Keyboard.IsKeyDown(KeyType.D6)) return KeyType.D6;
			else if (Keyboard.IsKeyDown(KeyType.D7)) return KeyType.D7;
			else if (Keyboard.IsKeyDown(KeyType.D8)) return KeyType.D8;
			else if (Keyboard.IsKeyDown(KeyType.D9)) return KeyType.D9;
			else if (Keyboard.IsKeyDown(KeyType.NumPad0)) return KeyType.NumPad0;
			else if (Keyboard.IsKeyDown(KeyType.NumPad1)) return KeyType.NumPad1;
			else if (Keyboard.IsKeyDown(KeyType.NumPad2)) return KeyType.NumPad2;
			else if (Keyboard.IsKeyDown(KeyType.NumPad3)) return KeyType.NumPad3;
			else if (Keyboard.IsKeyDown(KeyType.NumPad4)) return KeyType.NumPad4;
			else if (Keyboard.IsKeyDown(KeyType.NumPad5)) return KeyType.NumPad5;
			else if (Keyboard.IsKeyDown(KeyType.NumPad6)) return KeyType.NumPad6;
			else if (Keyboard.IsKeyDown(KeyType.NumPad7)) return KeyType.NumPad7;
			else if (Keyboard.IsKeyDown(KeyType.NumPad8)) return KeyType.NumPad8;
			else if (Keyboard.IsKeyDown(KeyType.NumPad9)) return KeyType.NumPad9;
			else if (Keyboard.IsKeyDown(KeyType.Up)) return KeyType.Up;
			else if (Keyboard.IsKeyDown(KeyType.Down)) return KeyType.Down;
			else if (Keyboard.IsKeyDown(KeyType.Left)) return KeyType.Left;
			else if (Keyboard.IsKeyDown(KeyType.Right)) return KeyType.Right;
			else if (Keyboard.IsKeyDown(KeyType.Add)) return KeyType.Add;
			else if (Keyboard.IsKeyDown(KeyType.Subtract)) return KeyType.Subtract;
			else if (Keyboard.IsKeyDown(KeyType.F1)) return KeyType.F1;
			else if (Keyboard.IsKeyDown(KeyType.F2)) return KeyType.F2;
			else if (Keyboard.IsKeyDown(KeyType.F3)) return KeyType.F3;
			else if (Keyboard.IsKeyDown(KeyType.F4)) return KeyType.F4;
			else if (Keyboard.IsKeyDown(KeyType.F5)) return KeyType.F5;
			else if (Keyboard.IsKeyDown(KeyType.F6)) return KeyType.F6;
			else if (Keyboard.IsKeyDown(KeyType.F7)) return KeyType.F7;
			else if (Keyboard.IsKeyDown(KeyType.F8)) return KeyType.F8;
			else if (Keyboard.IsKeyDown(KeyType.F9)) return KeyType.F9;
			else if (Keyboard.IsKeyDown(KeyType.F10)) return KeyType.F10;
			else if (Keyboard.IsKeyDown(KeyType.F11)) return KeyType.F11;
			else if (Keyboard.IsKeyDown(KeyType.F12)) return KeyType.F12;
			else if (Keyboard.IsKeyDown(KeyType.Home)) return KeyType.Home;
			else if (Keyboard.IsKeyDown(KeyType.End)) return KeyType.End;
			else if (Keyboard.IsKeyDown(KeyType.PageUp)) return KeyType.PageUp;
			else if (Keyboard.IsKeyDown(KeyType.PageDown)) return KeyType.PageDown;
			else return KeyType.None;
		}

		private ModifierKeys DetectModifierKey()
		{
			if (Keyboard.IsKeyDown(KeyType.LeftAlt) || Keyboard.IsKeyDown(KeyType.RightAlt)) return ModifierKeys.Alt;
			else if (Keyboard.IsKeyDown(KeyType.LeftCtrl) || Keyboard.IsKeyDown(KeyType.RightCtrl)) return ModifierKeys.Control;
			else if (Keyboard.IsKeyDown(KeyType.LeftShift) || Keyboard.IsKeyDown(KeyType.RightShift)) return ModifierKeys.Shift;
			else return ModifierKeys.None;
		}

	}
}