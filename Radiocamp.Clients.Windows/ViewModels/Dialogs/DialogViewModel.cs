using System;
using System.Reactive;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public abstract class DialogViewModel : ViewModel, IDialogViewModel
	{

		protected readonly BaseWindow owner;
		protected readonly Object parameter;

		private Boolean isInitialized;
		private DialogWindow dialogWindow;

		protected Boolean CloseOnEscape { get; set; }
		protected Boolean AutoCenter { get; set; }

		public DialogWindow DialogWindow
		{
			get => dialogWindow;
			set
			{

				dialogWindow = value;

				if (dialogWindow != null)
				{
					dialogWindow.KeyDown += OnKeyDown;
				}

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

		public DialogViewModel(DialogArgs args)
		{
			owner = args?.Owner ?? Application.Current.MainWindow as BaseWindow;
			parameter = args?.Parameter;
		}

		public override void Initialize()
		{

			owner.OverlayVisible = true;

			if (isInitialized)
			{
				return;
			}

			AutoCenter = true;
			MaxWidth = Double.MaxValue;
			MaxHeight = Double.MaxValue;
			MinWidth = 0;
			MinHeight = 0;
			Padding = new Thickness(0);

			CloseOnEscape = true;
			CloseCommand = ReactiveCommand.Create(Close);

			disposables.Add(CloseCommand);

			Dependencies.Get<IMainWindow>().HideEvent += Close;

			dialogWindow.SizeChanged += OnDialogWindowSizeChanged;

			isInitialized = true;

		}

		public override void Dispose()
		{

			base.Dispose();

			Dependencies.Get<IMainWindow>().HideEvent -= Close;
			dialogWindow.KeyDown -= OnKeyDown;
			dialogWindow.SizeChanged -= OnDialogWindowSizeChanged;

			owner.OverlayVisible = false;

		}

		protected virtual void Close()
		{
			DialogWindow?.Close();
		}

		protected virtual void OnKeyDown(KeyEventArgs args)
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

		private void OnKeyDown(Object sender, KeyEventArgs args)
		{

			if (args.Key == Key.Escape)
			{
				
				OnEscape();

				args.Handled = true;

			}

			if (args.Key == Key.Enter)
			{
				OnEnter();
			}

			OnKeyDown(args);

		}

		private void OnDialogWindowSizeChanged(Object sender, SizeChangedEventArgs args)
		{
			if (AutoCenter)
			{
				dialogWindow.Left = owner.Left + (owner.Width - dialogWindow.ActualWidth) / 2;
				dialogWindow.Top = owner.Top + (owner.Height - dialogWindow.ActualHeight) / 2;
			}
		}

	}

	public abstract class DialogViewModel<ResultType> : DialogViewModel, IDialogViewModel<ResultType>
	{

		[Reactive]
		public ResultType Result { get; set; }

		public DialogViewModel(DialogArgs args) : base(args)
		{
		}

	}

}