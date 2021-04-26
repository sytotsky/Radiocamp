using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Services;

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

		[Reactive]
		public Boolean IsPinned { get; set; }

		public RadiostationItemViewModel(Guid id)
		{
			
			this.id = id;
			player = Dependencies.Get<IPlayer>();
			radiostations = Dependencies.Get<IRadiostations>();

			this.WhenAnyValue(viewModel => viewModel.IsFavorite)
				.Skip(1)
				.Subscribe(OnIsFavoriteChanged);

		}

		public async Task Click()
		{
			await player.SetRadiostationAsync(radiostations.Get(id));
			player.Play();
		}

		private async void OnIsFavoriteChanged(Boolean isFavorite)
		{

			WindowsRadiostation radiostation = radiostations.Get(id);

			if (radiostation != null)
			{
				
				radiostation.IsFavorite = isFavorite;

				await radiostations.UpdateAsync(radiostation);

			}

		}

		public async void UnpinFromTop()
		{
			await radiostations.TogglePinnedAsync(id);
		}

		public async void PinToTop()
		{
			await radiostations.TogglePinnedAsync(id);
		}

	}
}