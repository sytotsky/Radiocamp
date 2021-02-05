using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Dartware.NRadio;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class PlayerService : IPlayer
	{

		private readonly ISettings settings;
		private readonly IRadioEngine radioEngine;

		private readonly ISubject<WindowsRadiostation> radiostationSubject;
		private readonly ISubject<Double> volumeSubject;
		private readonly ISubject<IMetadata> metadataSubject;
		private readonly ISubject<PlaybackStatus> playbackStatusSubject;
		private readonly ISubject<RecordingStatus> recordingStatusSubject;
		private readonly ISubject<ConnectionState> connectionStateSubject;
		private readonly ISubject<Int64> bufferingProgressSubject;

		private WindowsRadiostation radiostation;
		private Double volumeBeforeMute;
		private Boolean isMuted;

		public IObservable<WindowsRadiostation> Radiostation => radiostationSubject;
		public IObservable<Double> Volume => volumeSubject;
		public IObservable<IMetadata> Metadata => metadataSubject;
		public IObservable<PlaybackStatus> PlaybackStatus => playbackStatusSubject;
		public IObservable<RecordingStatus> RecordingStatus => recordingStatusSubject;
		public IObservable<ConnectionState> ConnectionState => connectionStateSubject;
		public IObservable<Int64> BufferingProgress => bufferingProgressSubject;

		public PlayerService(ISettings settings, IHotkeys hotkeys)
		{

			this.settings = settings;
			radioEngine = RadioEngineFactory.Default;
			radiostationSubject = new BehaviorSubject<WindowsRadiostation>(null);
			volumeSubject = new BehaviorSubject<Double>(50.0d);
			metadataSubject = new BehaviorSubject<IMetadata>(null);
			playbackStatusSubject = new BehaviorSubject<PlaybackStatus>(NRadio.PlaybackStatus.Pause);
			recordingStatusSubject = new BehaviorSubject<RecordingStatus>(NRadio.RecordingStatus.Stop);
			connectionStateSubject = new BehaviorSubject<ConnectionState>(NRadio.ConnectionState.None);
			bufferingProgressSubject = new BehaviorSubject<Int64>(0);

			SetVolume(settings.Volume);

			radioEngine.MetadataChanged += metadata => metadataSubject.OnNext(metadata);
			radioEngine.PlaybackStatusChanged += playbackStatus => playbackStatusSubject.OnNext(playbackStatus);
			radioEngine.RecordingStatusChanged += recordStatus => recordingStatusSubject.OnNext(recordStatus);
			radioEngine.ConnectionStateChanged += connectionState => connectionStateSubject.OnNext(connectionState);
			radioEngine.BufferingProgressChanged += bufferingProgress => bufferingProgressSubject.OnNext(bufferingProgress);
			hotkeys.VolumeUpHotkeyPressed += VolumeUp;
			hotkeys.VolumeDownHotkeyPressed += VolumeDown;
			hotkeys.MuteUnmuteHotkeyPressed += MuteUnmute;
			hotkeys.PlayPauseHotkeyPressed += PlayPause;

		}

		public async Task SetRadiostationAsync(WindowsRadiostation radiostation)
		{

			radiostationSubject.OnNext(radiostation);

			if (radiostation == null)
			{
				return;
			}

			if (this.radiostation?.Equals(radiostation) ?? false)
			{
				return;
			}

			this.radiostation = radiostation;

			await radioEngine.SetURLAsync(radiostation.StreamURL);

		}

		public void SetVolume(Double volume)
		{

			volumeSubject.OnNext(volume);

			isMuted = volume == 0;
			radioEngine.Volume = volume;
			settings.Volume = volume;

		}

		public void Play()
		{
			if (radiostation != null)
			{
				radioEngine.Play();
			}
		}

		public void Pause()
		{
			if (radiostation != null)
			{
				radioEngine.Pause();
			}
		}

		public void PlayPause()
		{
			switch (radioEngine.PlaybackStatus)
			{
				case NRadio.PlaybackStatus.Play: Pause(); break;
				case NRadio.PlaybackStatus.Pause: Play(); break;
			}
		}

		public void VolumeUp()
		{

			Double newVolume = radioEngine.Volume + settings.VolumeStep;

			if (newVolume > 100)
			{
				newVolume = 100;
			}

			SetVolume(newVolume);

		}

		public void VolumeDown()
		{

			Double newVolume = radioEngine.Volume - settings.VolumeStep;

			if (newVolume < 0)
			{
				newVolume = 0;
			}

			SetVolume(newVolume);

		}

		public void Mute()
		{

			volumeBeforeMute = radioEngine.Volume;

			SetVolume(0);

		}

		public void Unmute()
		{
			
			SetVolume(volumeBeforeMute == 0 ? 50 : volumeBeforeMute);

			volumeBeforeMute = 0;

		}

		private void MuteUnmute()
		{
			if (isMuted)
			{
				Unmute();
			}
			else
			{
				Mute();
			}
		}

	}
}