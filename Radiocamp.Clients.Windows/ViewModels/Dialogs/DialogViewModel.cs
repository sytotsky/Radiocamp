using System;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public abstract class DialogViewModel : ViewModel
	{

		private DialogWindow dialogWindow;

		protected Boolean CloseOnEscape { get; set; }

		public DialogWindow DialogWindow
		{
			get => dialogWindow;
			set
			{

				dialogWindow = value;

				if (dialogWindow != null)
				{
					dialogWindow.KeyDown += OnDialogWindowKeyDown;
				}

			}
		}

		public Boolean OverlayVisible
		{
			get
			{

				if (DialogWindow is null)
				{
					return false;
				}

				return DialogWindow.OverlayVisible;

			}
			set
			{

				if (DialogWindow is null)
				{
					return;
				}

				DialogWindow.OverlayVisible = value;

			}
		}

		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }

		public virtual void Initialize()
		{

			CloseOnEscape = true;
			CloseCommand = ReactiveCommand.Create(Close);

			disposables.Add(CloseCommand);

			Dependencies.Get<IMainWindow>().HideEvent += OnMainWindowHide;

		}

		public override void Dispose()
		{

			base.Dispose();

			Dependencies.Get<IMainWindow>().HideEvent -= OnMainWindowHide;
			dialogWindow.KeyDown -= OnDialogWindowKeyDown;

		}

		protected virtual void Close()
		{
			DialogWindow?.Close();
		}

		protected virtual void OnDialogWindowKeyDown(KeyEventArgs args)
		{
		}

		protected virtual void OnEscape()
		{
			if (CloseOnEscape)
			{
				Close();
			}
		}

		private void OnMainWindowHide()
		{
			Close();
		}

		private void OnDialogWindowKeyDown(Object sender, KeyEventArgs args)
		{

			if (args.Key == Key.Escape)
			{
				OnEscape();
			}

			OnDialogWindowKeyDown(args);

			args.Handled = true;

		}

	}

	public abstract class DialogViewModel<ResultTypeDefenition> : DialogViewModel
	{
		[Reactive]
		public ResultTypeDefenition Result { get; set; }
	}

}