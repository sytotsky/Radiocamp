using System;
using System.Reactive;
using Dartware.Radiocamp.Clients.Windows.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public abstract class DialogViewModel : ViewModel
	{

		[Reactive]
		public DialogWindow DialogWindow { get; set; }

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

		public ReactiveCommand<Unit, Unit> CloseCommand { get; }

		public DialogViewModel()
		{

			CloseCommand = ReactiveCommand.Create(Close);

			disposables.Add(CloseCommand);

			Dependencies.Get<IMainWindow>().HideEvent += OnMainWindowHide;

		}

		public override void Dispose()
		{

			base.Dispose();

			Dependencies.Get<IMainWindow>().HideEvent -= OnMainWindowHide;

		}

		protected virtual void Close()
		{
			DialogWindow?.Close();
		}

		private void OnMainWindowHide()
		{
			Close();
		}

	}

	public abstract class DialogViewModel<ResultTypeDefenition> : DialogViewModel
	{
		[Reactive]
		public ResultTypeDefenition Result { get; set; }
	}

}