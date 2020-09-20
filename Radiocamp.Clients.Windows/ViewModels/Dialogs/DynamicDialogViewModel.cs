﻿using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Input;
using DynamicData.Binding;
using Dartware.Radiocamp.Clients.Windows.Windows;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public abstract class DynamicDialogViewModel : AbstractNotifyPropertyChanged, IDialogViewModel
	{

		private Boolean isInitialized;
		private DialogWindow dialogWindow;

		private Double width;
		private Double height;
		private Double maxWidth;
		private Double maxHeight;
		private Double minWidth;
		private Double minHeight;
		private Thickness padding;

		protected readonly CompositeDisposable disposables;

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

		public Double Width
		{
			get => width;
			protected set => SetAndRaise(ref width, value);
		}

		public Double Height
		{
			get => height;
			protected set => SetAndRaise(ref height, value);
		}

		public Double MaxWidth
		{
			get => maxWidth;
			protected set => SetAndRaise(ref maxWidth, value);
		}

		public Double MaxHeight
		{
			get => maxHeight;
			protected set => SetAndRaise(ref maxHeight, value);
		}

		public Double MinWidth
		{
			get => minWidth;
			protected set => SetAndRaise(ref minWidth, value);
		}

		public Double MinHeight
		{
			get => minHeight;
			protected set => SetAndRaise(ref minHeight, value);
		}

		public Thickness Padding
		{
			get => padding;
			protected set => SetAndRaise(ref padding, value);
		}

		public ICommand CloseCommand { get; private set; }

		public DynamicDialogViewModel()
		{
			disposables = new CompositeDisposable();
		}

		public virtual void Initialize()
		{

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
			CloseCommand = new RelayCommand(Close);

			Dependencies.Get<IMainWindow>().HideEvent += OnMainWindowHide;

			dialogWindow.SizeChanged += OnDialogWindowSizeChanged;

			isInitialized = true;

		}

		public virtual void Dispose()
		{
			Dependencies.Get<IMainWindow>().HideEvent -= OnMainWindowHide;
			dialogWindow.KeyDown -= OnDialogWindowKeyDown;
			dialogWindow.SizeChanged -= OnDialogWindowSizeChanged;
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

				args.Handled = true;

			}

			if (args.Key == Key.Enter)
			{
				OnEnter();
			}

			OnDialogWindowKeyDown(args);

		}

		private void OnDialogWindowSizeChanged(Object sender, SizeChangedEventArgs args)
		{
			if (AutoCenter)
			{

				Window ownerWindow = DialogWindow.Owner;

				dialogWindow.Left = ownerWindow.Left + (ownerWindow.Width - dialogWindow.ActualWidth) / 2;
				dialogWindow.Top = ownerWindow.Top + (ownerWindow.Height - dialogWindow.ActualHeight) / 2;

			}
		}

	}

	public abstract class DynamicDialogViewModel<ResultType> : DynamicDialogViewModel, IDialogViewModel<ResultType>
	{

		private ResultType result;

		public ResultType Result
		{
			get => result;
			set => SetAndRaise(ref result, value);
		}

	}

}