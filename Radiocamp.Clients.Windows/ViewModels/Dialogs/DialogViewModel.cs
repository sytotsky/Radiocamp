using System;
using System.Reactive;
using System.Windows;
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

		private Boolean isInitialized;
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

		[Reactive]
		public Double Width { get; protected set; }

		[Reactive]
		public Double Height { get; protected set; }

		[Reactive]
		public Double MaxWidth { get; protected set; }

		[Reactive]
		public Double MaxHeight { get; protected set; }

		[Reactive]
		public Double MinWidth { get; protected set; }

		[Reactive]
		public Double MinHeight { get; protected set; }

		[Reactive]
		public Thickness Padding { get; protected set; }

		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }

		public virtual void Initialize()
		{

			if (isInitialized)
			{
				return;
			}

			MaxWidth = Double.MaxValue;
			MaxHeight = Double.MaxValue;
			MinWidth = 0;
			MinHeight = 0;
			Padding = new Thickness(0);

			CloseOnEscape = true;
			CloseCommand = ReactiveCommand.Create(Close);

			disposables.Add(CloseCommand);

			Dependencies.Get<IMainWindow>().HideEvent += OnMainWindowHide;

			isInitialized = true;

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

		protected virtual void OnEnter()
		{
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

			if (args.Key == Key.Enter)
			{
				OnEnter();
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