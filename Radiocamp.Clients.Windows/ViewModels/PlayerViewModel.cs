using System;
using System.Reactive;
using System.Threading.Tasks;
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
		public ReactiveCommand<Unit, Unit> MuteUnmuteCommand { get; }
		public ReactiveCommand<Unit, Unit> PlayCommand { get; }
		public ReactiveCommand<Unit, Unit> PauseCommand { get; }
		public ReactiveCommand<Unit, Unit> StartRecordingCommand { get; }
		public ReactiveCommand<Unit, Unit> StopRecordingCommand { get; }
		public ReactiveCommand<Unit, Unit> AudioSettingsCommand { get; }
		public ReactiveCommand<Unit, Unit> PlaybackHistoryCommand { get; }

		public PlayerViewModel(IBrowser browser, ISettings settings)
		{

			this.browser = browser;
			this.settings = settings;

			VolumeStep = settings.VolumeStep;

			settings.VolumeStepChanged += volumeStep => VolumeStep = volumeStep;

			SearchSongCommand = ReactiveCommand.Create(SearchSong);
			MuteUnmuteCommand = ReactiveCommand.Create(MuteUnmute);
			PlayCommand = ReactiveCommand.Create(Play);
			PauseCommand = ReactiveCommand.Create(Pause);
			StartRecordingCommand = ReactiveCommand.Create(StartRecording);
			StopRecordingCommand = ReactiveCommand.Create(StopRecording);
			AudioSettingsCommand = ReactiveCommand.CreateFromTask(AudioSettingsAsync);
			PlaybackHistoryCommand = ReactiveCommand.CreateFromTask(PlaybackHistoryAsync);

			Title = "Vocal Trance Radio";
			SongName = "Stargazers & Katty Heath - Be Here With Me (Extended Mix) Amsterdam Trance";
			Format = Format.MP3;
			Bitrate = 256;
			Volume = 50;

		}

		public void OnMouseWheel(MouseWheelEventArgs args)
		{
			if (args.Delta > 0)
			{

				Double newVolume = Volume + VolumeStep;

				if (newVolume > 100)
				{
					newVolume = 100;
				}

				Volume = newVolume;

			}
			else
			{

				Double newVolume = Volume - VolumeStep;

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

		private void MuteUnmute()
		{
			throw new NotImplementedException();
		}

		private void Play()
		{
			throw new NotImplementedException();
		}

		private void Pause()
		{
			throw new NotImplementedException();
		}

		private void StartRecording()
		{
			throw new NotImplementedException();
		}

		private void StopRecording()
		{
			throw new NotImplementedException();
		}

		private Task AudioSettingsAsync()
		{
			throw new NotImplementedException();
		}

		private Task PlaybackHistoryAsync()
		{
			throw new NotImplementedException();
		}

	}
}