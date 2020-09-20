using System;
using System.Reactive;
using System.Windows;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.UI.Controls;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class ConfirmDialogViewModel : DialogViewModel<Boolean>
	{

		[Reactive]
		public String Text { get; set; }

		[Reactive]
		public String FirstButtonText { get; set; }

		[Reactive]
		public String SecondButtonText { get; set; }

		[Reactive]
		public TransparentButtonType FirstButtonType { get; set; }

		[Reactive]
		public TransparentButtonType SecondButtonType { get; set; }

		public ReactiveCommand<Unit, Unit> OkCommand { get; private set; }

		public override void Initialize()
		{
			
			base.Initialize();

			MaxWidth = 300;
			Padding = new Thickness(16);

			OkCommand = ReactiveCommand.Create(Ok);

			disposables.Add(OkCommand);

		}

		protected override void OnEnter()
		{
			base.OnEnter();
			Ok();
		}

		private void Ok()
		{
			
			Result = true;

			Close();

		}

	}
}