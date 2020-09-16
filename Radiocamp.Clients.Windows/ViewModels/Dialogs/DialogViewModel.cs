using System;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Windows;
using ReactiveUI;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public abstract class DialogViewModel : ViewModel, IDisposable
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

		public ICommand CloseCommand { get; }

		public DialogViewModel()
		{

			CloseCommand = ReactiveCommand.Create(Close);

			Dependencies.Get<IMainWindow>().HideEvent += OnMainWindowHide;

		}

		public virtual void Dispose()
		{
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