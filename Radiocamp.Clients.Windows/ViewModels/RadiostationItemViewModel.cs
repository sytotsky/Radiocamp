using System;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Core.Models;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationItemViewModel : ViewModel
	{

		private readonly Guid id;

		[Reactive]
		public String Title { get; set; }

		[Reactive]
		public Genre Genre { get; set; }

		[Reactive]
		public Country Country { get; set; }

		[Reactive]
		public Boolean IsFavorite { get; set; }

		[Reactive]
		public Boolean IsCurrent { get; set; }

		[Reactive]
		public Boolean IsCustom { get; set; }

		public RadiostationItemViewModel(Guid id)
		{
			this.id = id;
		}

	}
}