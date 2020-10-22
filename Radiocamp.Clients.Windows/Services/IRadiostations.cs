using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{

		ISourceCache<Radiostation, Guid> All { get; }

		void Initialize();
		Task CreateAsync();
		Task ClearAsync();
		Task ImportAsync();
		Task ExportAsync(ExportArgs exportArgs);

	}
}