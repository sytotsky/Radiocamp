﻿using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Dartware.NRadio;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;
using ReactiveUI;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class PlayerService : IPlayer, IDisposable
	{

		private readonly ISettings settings;
		private readonly IHotkeys hotkeys;
		private readonly IRadiostations radiostations;
		private readonly IRadioEngine radioEngine;
		private readonly IApplication application;

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
		private DateTime changeCurrentRadiostationTime;

		public IObservable<WindowsRadiostation> Radiostation => radiostationSubject;
		public IObservable<Double> Volume => volumeSubject;
		public IObservable<IMetadata> Metadata => metadataSubject;
		public IObservable<PlaybackStatus> PlaybackStatus => playbackStatusSubject;
		public IObservable<RecordingStatus> RecordingStatus => recordingStatusSubject;
		public IObservable<ConnectionState> ConnectionState => connectionStateSubject;
		public IObservable<Int64> BufferingProgress => bufferingProgressSubject;

		public PlayerService(ISettings settings, IHotkeys hotkeys, IRadiostations radiostations, IApplication application)
		{

			this.settings = settings;
			this.hotkeys = hotkeys;
			this.radiostations = radiostations;
			this.application = application;

			radioEngine = RadioEngineFactory.Default;
			radiostationSubject = new BehaviorSubject<WindowsRadiostation>(null);
			volumeSubject = new BehaviorSubject<Double>(50.0d);
			metadataSubject = new BehaviorSubject<IMetadata>(null);
			playbackStatusSubject = new BehaviorSubject<PlaybackStatus>(NRadio.PlaybackStatus.Pause);
			recordingStatusSubject = new BehaviorSubject<RecordingStatus>(NRadio.RecordingStatus.Stop);
			connectionStateSubject = new BehaviorSubject<ConnectionState>(NRadio.ConnectionState.None);
			bufferingProgressSubject = new BehaviorSubject<Int64>(0);
			changeCurrentRadiostationTime = DateTime.Now;

			Initialize();

		}

		private async void Initialize()
		{

			radioEngine.MetadataChanged += metadata => metadataSubject.OnNext(metadata);
			radioEngine.PlaybackStatusChanged += playbackStatus => playbackStatusSubject.OnNext(playbackStatus);
			radioEngine.RecordingStatusChanged += recordStatus => recordingStatusSubject.OnNext(recordStatus);
			radioEngine.ConnectionStateChanged += connectionState => connectionStateSubject.OnNext(connectionState);
			radioEngine.BufferingProgressChanged += bufferingProgress => bufferingProgressSubject.OnNext(bufferingProgress);
			hotkeys.VolumeUpHotkeyPressed += VolumeUp;
			hotkeys.VolumeDownHotkeyPressed += VolumeDown;
			hotkeys.MuteUnmuteHotkeyPressed += MuteUnmute;
			hotkeys.PlayPauseHotkeyPressed += PlayPause;
			application.ShutdownLong += OnShutdownLong;

			radiostations.Updated.WhereNotNull()
								 .Subscribe(OnRadiostationUpdated);
			
			radiostations.Removed.Subscribe(OnRadiostationRemoved);

			SetVolume(settings.Volume);

			WindowsRadiostation currentRadiostation = radiostations.GetCurrent();

			if (currentRadiostation != null)
			{
				await SetRadiostationAsync(currentRadiostation);
			}

		}

		public async Task SetRadiostationAsync(WindowsRadiostation radiostation)
		{

			await SaveListenTime();
			radiostationSubject.OnNext(radiostation);

			if (radiostation == null)
			{
				return;
			}

			if (this.radiostation?.Equals(radiostation) ?? false)
			{
				return;
			}

			await radiostations.SetLastPlaybackTimeAsync(radiostation.Id);

			this.radiostation = radiostation;
			changeCurrentRadiostationTime = DateTime.Now;

			await radiostations.SetCurrentAsync(radiostation);
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
				radiostations.SetIsPlay(radiostation, true);
			}
		}

		public void Pause()
		{
			if (radiostation != null)
			{
				radioEngine.Pause();
				radiostations.SetIsPlay(radiostation, false);
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
		
		

		public void Dispose()
		{

			radioEngine.Pause();
			
			radiostation = null;
			
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

		private async void OnShutdownLong()
		{
			await SaveListenTime();
		}

		private async Task SaveListenTime()
		{
			if (radiostation is not null)
			{
				await radiostations.AddListenTimeAsync(this.radiostation.Id, DateTime.Now - changeCurrentRadiostationTime);
			}
		}
		
		private void OnRadiostationUpdated(WindowsRadiostation radiostation)
		{
		}

		private void OnRadiostationRemoved(Guid id)
		{
			
			if (radiostation is null)
			{
				return;
			}
			
			if (radiostation.Id.Equals(id))
			{
				Dispose();
			}
			
		}
		
	}
}