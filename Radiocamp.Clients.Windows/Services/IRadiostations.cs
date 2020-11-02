using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{
		Task<IObservable<IChangeSet<WindowsRadiostation, Guid>>> ConnectAsync();
		WindowsRadiostation Get(Guid id);
		Task CreateAsync();
		Task ClearAsync();
		Task ImportAsync();
		Task ExportAsync(ExportArgs exportArgs);
	}
}