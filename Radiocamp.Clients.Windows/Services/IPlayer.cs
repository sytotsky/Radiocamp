using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Dartware.NRadio;
using Dartware.NRadio.Meta;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IPlayer
	{

		ISubject<WindowsRadiostation> RadiostationSubject { get; }
		ISubject<Double> VolumeSubject { get; }
		ISubject<IMetadata> MetadataSubject { get; }
		ISubject<PlaybackStatus> PlaybackStatusSubject { get; }
		ISubject<RecordingStatus> RecordingStatusSubject { get; }

		Task SetRadiostationAsync(WindowsRadiostation radiostation);
		void SetVolume(Double volume);
		void Play();
		void Pause();
		void PlayPause();
		void VolumeUp();
		void VolumeDown();

	}
}