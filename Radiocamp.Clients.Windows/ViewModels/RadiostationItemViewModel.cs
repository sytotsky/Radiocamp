using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationItemViewModel : ViewModel
	{

		private readonly Guid id;
		private readonly IPlayer player;
		private readonly IRadiostations radiostations;
		private readonly IDialogs dialogs;

		public String StreamURL { get; set; }
		public DateTime Created { get; set; }
		public TimeSpan ListenTime { get; set; }
		public DateTime LastPlayTime { get; set; }

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

		[Reactive]
		public Boolean IsPlay { get; set; }

		public RadiostationItemViewModel(Guid id)
		{
			
			this.id = id;
			player = Dependencies.Get<IPlayer>();
			radiostations = Dependencies.Get<IRadiostations>();
			dialogs = Dependencies.Get<IDialogs>();

			this.WhenAnyValue(viewModel => viewModel.IsFavorite)
				.Skip(1)
				.Subscribe(OnIsFavoriteChanged);

		}

		public void AddToFavorites()
		{
			IsFavorite = true;
		}

		public void RemoveFromFavorites()
		{
			IsFavorite = false;
		}

		public async Task StartPlayback()
		{
			await player.SetRadiostationAsync(radiostations.Get(id));
			player.Play();
		}

		public void StopPlayback()
		{
			player.Pause();
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

		public async void Remove()
		{
			await radiostations.RemoveAsync(id);
		}

		public async void Edit()
		{

			WindowsRadiostation currentRadiostation = radiostations.Get(id);

			if (currentRadiostation is not null)
			{

				RadiostationEditorArgs radiostationEditorArgs = new RadiostationEditorArgs(null, currentRadiostation)
				{
					Mode = RadiostationEditorMode.Edit
				};

				WindowsRadiostation radiostation = await dialogs.Show<WindowsRadiostation, RadiostationEditorDialog, RadiostationEditorDialogViewModel>(radiostationEditorArgs);

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


		public void CopyName()
		{
			Clipboard.Clear();
			Clipboard.SetText(Title);
		}

		public void CopyStreamURL()
		{
			Clipboard.Clear();
			Clipboard.SetText(StreamURL);
		}

	}
}