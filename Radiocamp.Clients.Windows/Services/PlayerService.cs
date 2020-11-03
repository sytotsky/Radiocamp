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

		private WindowsRadiostation radiostation;

		public ISubject<WindowsRadiostation> RadiostationSubject { get; }
		public ISubject<Double> VolumeSubject { get; }
		public ISubject<IMetadata> MetadataSubject { get; }

		public PlayerService(ISettings settings, IHotkeys hotkeys)
		{

			this.settings = settings;
			radioEngine = RadioEngineFactory.Default;
			RadiostationSubject = new BehaviorSubject<WindowsRadiostation>(null);
			VolumeSubject = new BehaviorSubject<Double>(50.0d);
			MetadataSubject = new BehaviorSubject<IMetadata>(null);

			SetVolume(settings.Volume);

			radioEngine.MetadataChanged += metadata => MetadataSubject.OnNext(metadata);
			hotkeys.VolumeUpHotkeyPressed += VolumeUp;
			hotkeys.VolumeDownHotkeyPressed += VolumeDown;

		}

		public async Task SetRadiostationAsync(WindowsRadiostation radiostation)
		{

			RadiostationSubject.OnNext(radiostation);

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

			VolumeSubject.OnNext(volume);

			radioEngine.Volume = volume;
			settings.Volume = volume;

		}

		public void Play()
		{
			radioEngine.Play();
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

	}
}