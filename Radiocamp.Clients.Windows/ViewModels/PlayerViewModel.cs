using System;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class PlayerViewModel : ViewModel
	{

		private readonly ISettings settings;
		private readonly IBrowser browser;

		[Reactive]
		public String Title { get; private set; }

		[Reactive]
		public String SongName { get; private set; }

		[Reactive]
		public Format Format { get; private set; }

		[Reactive]
		public Int32 Bitrate { get; private set; }

		[Reactive]
		public Double Volume { get; set; }

		[Reactive]
		public Int32 VolumeStep { get; private set; }

		public ReactiveCommand<Unit, Unit> SearchSongCommand { get; }

		public PlayerViewModel(IBrowser browser, ISettings settings)
		{

			this.browser = browser;
			this.settings = settings;

			SearchSongCommand = ReactiveCommand.Create(SearchSong);

			Title = "NRK MP3 97.0 FM Oslo";
			SongName = "Alan Walker - Faded";
			Format = Format.MP3;
			Bitrate = 256;
			Volume = 50;
			VolumeStep = 4;

		}

		public void OnMouseWheel(MouseWheelEventArgs args)
		{
			if (args.Delta > 0)
			{

				Double newVolume = Volume + settings.VolumeStep;

				if (newVolume > 100)
				{
					newVolume = 100;
				}

				Volume = newVolume;

			}
			else
			{

				Double newVolume = Volume - settings.VolumeStep;

				if (newVolume < 0)
				{
					newVolume = 0;
				}

				Volume = newVolume;

			}
		}

		private void SearchSong()
		{
			browser.Search(SongName, settings.SearchEngine);
		}

	}
}