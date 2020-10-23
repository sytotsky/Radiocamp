using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{
		Task<IObservable<IChangeSet<Radiostation, Guid>>> ConnectAsync();
		Task CreateAsync();
		Task ClearAsync();
		Task ImportAsync();
		Task ExportAsync(ExportArgs exportArgs);
	}
}