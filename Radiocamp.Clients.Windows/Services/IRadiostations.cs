using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Shared.Models;
using System.Collections.Generic;
using System.Reactive;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{

		IObservable<WindowsRadiostation> Updated { get; }
		IObservable<Guid> Removed { get; }
		IObservable<Unit> Cleared { get; }

		Task InitializeAsync();
		IObservable<IChangeSet<WindowsRadiostation, Guid>> Connect();
		WindowsRadiostation Get(Guid id);
		WindowsRadiostation GetCurrent();
		Task CreateAsync(WindowsRadiostation radiostation);
		Task CreateAsync(WindowsRadiostation radiostation, Boolean isCustom);
		Task CreateRangeAsync(IEnumerable<WindowsRadiostation> radiostations);
		Task UpdateAsync(WindowsRadiostation radiostation);
		Task RemoveAsync(Guid id);
		Task SetCurrentAsync(WindowsRadiostation radiostation);
		Task TogglePinnedAsync(Guid id);
		Task ClearAsync();
		Task ImportAsync(String filePath);
		Task ExportAsync(ExportArgs exportArgs);
		void SetIsPlay(WindowsRadiostation radiostation, Boolean isPlay);
		Task AddListenTimeAsync(Guid id, TimeSpan listenTime);
		Task SetLastPlaybackTimeAsync(Guid id);

	}
}