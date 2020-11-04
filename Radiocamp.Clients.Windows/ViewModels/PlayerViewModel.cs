using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.NRadio;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class PlayerViewModel : ViewModel
	{

		private readonly ISettings settings;
		private readonly IBrowser browser;
		private readonly IPlayer player;

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

		[Reactive]
		public Boolean ControlsIsEnabled { get; private set; }

		[Reactive]
		public Boolean IsPlay { get; set; }

		[Reactive]
		public Boolean IsRecording { get; set; }

		public ReactiveCommand<Unit, Unit> SearchSongCommand { get; }
		public ReactiveCommand<Unit, Unit> AudioSettingsCommand { get; }
		public ReactiveCommand<Unit, Unit> PlaybackHistoryCommand { get; }

		public PlayerViewModel(IBrowser browser, ISettings settings, IPlayer player)
		{

			this.browser = browser;
			this.settings = settings;
			this.player = player;

			VolumeStep = settings.VolumeStep;

			settings.VolumeStepChanged += volumeStep => VolumeStep = volumeStep;

			SearchSongCommand = ReactiveCommand.Create(SearchSong);
			AudioSettingsCommand = ReactiveCommand.CreateFromTask(AudioSettingsAsync);
			PlaybackHistoryCommand = ReactiveCommand.CreateFromTask(PlaybackHistoryAsync);

			this.WhenAnyValue(viewModel => viewModel.Volume)
				.Skip(1)
				.Subscribe(volume => this.player.SetVolume(volume));

			this.WhenAnyValue(viewModel => viewModel.IsPlay)
				.Skip(1)
				.Subscribe(isPlay =>
				{
					if (isPlay)
					{
						player.Play();
					}
					else
					{
						player.Pause();
					}
				});

			this.player.VolumeSubject.DistinctUntilChanged()
									 .Subscribe(volume => Volume = volume);

			this.player.RadiostationSubject.Do(radiostation => ControlsIsEnabled = radiostation != null)
										   .Where(radiostation => radiostation != null)
										   .Subscribe(OnNewRadiostation);

			this.player.MetadataSubject.Where(metadata => metadata != null)
									   .Subscribe(OnNewMetadata);

			this.player.PlaybackStatusSubject.Subscribe(playbackStatus => IsPlay = playbackStatus == PlaybackStatus.Play);

		}

		public void OnMouseWheel(MouseWheelEventArgs args)
		{
			if (args.Delta > 0)
			{
				player.VolumeUp();
			}
			else
			{
				player.VolumeDown();
			}
		}

		private void SearchSong()
		{
			browser.Search(SongName, settings.SearchEngine);
		}

		private Task AudioSettingsAsync()
		{
			throw new NotImplementedException();
		}

		private Task PlaybackHistoryAsync()
		{
			throw new NotImplementedException();
		}

		private void OnNewRadiostation(WindowsRadiostation radiostation)
		{
			Title = radiostation.Title;
		}

		private void OnNewMetadata(IMetadata metadata)
		{
			SongName = metadata.SongName;
			Format = metadata.Format;
			Bitrate = metadata.Bitrate;
		}

	}
}