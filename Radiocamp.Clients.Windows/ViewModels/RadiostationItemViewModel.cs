using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Core;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationItemViewModel : ViewModel
	{

		private readonly Guid id;
		private readonly IPlayer player;
		private readonly IRadiostations radiostations;

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
			player = Dependencies.Get<IPlayer>();
			radiostations = Dependencies.Get<IRadiostations>();
		}

		public async Task Click()
		{
			await player.SetRadiostationAsync(radiostations.Get(id));
			player.Play();
		}

	}
}