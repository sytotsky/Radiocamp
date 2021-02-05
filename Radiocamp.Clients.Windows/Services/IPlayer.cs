using System;
using System.Threading.Tasks;
using Dartware.NRadio;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IPlayer
	{

		IObservable<WindowsRadiostation> Radiostation { get; }
		IObservable<Double> Volume { get; }
		IObservable<IMetadata> Metadata { get; }
		IObservable<PlaybackStatus> PlaybackStatus { get; }
		IObservable<RecordingStatus> RecordingStatus { get; }
		IObservable<ConnectionState> ConnectionState { get; }
		IObservable<Int64> BufferingProgress { get; }

		Task SetRadiostationAsync(WindowsRadiostation radiostation);
		void SetVolume(Double volume);
		void Play();
		void Pause();
		void PlayPause();
		void VolumeUp();
		void VolumeDown();
		void Mute();
		void Unmute();

	}
}