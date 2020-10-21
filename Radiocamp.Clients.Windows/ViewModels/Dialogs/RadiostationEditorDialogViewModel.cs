using System;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationEditorDialogViewModel : DialogViewModel<Radiostation>
	{

		[Reactive]
		public String Title { get; set; }

		[Reactive]
		public String StreamURL { get; set; }

		[Reactive]
		public Genre Genre { get; set; }

		[Reactive]
		public Country Country { get; set; }

		[Reactive]
		public Boolean AddToFavorites { get; set; }

		[Reactive]
		public Boolean StartPlayback { get; set; }

		public RadiostationEditorDialogViewModel(DialogArgs args) : base(args)
		{
		}

		public override void Initialize()
		{
			
			base.Initialize();

			Width = 360;
			Height = 250;

		}

	}
}