using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{
		Task CreateAsync();
		Task ClearAsync();
		Task ImportAsync();
		Task ExportAsync(ExportArgs exportArgs);
	}
}