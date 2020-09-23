using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IRadiostations
	{
		Task ClearAsync();
		Task ImportAsync();
		Task ExportAsync(ExportArgs exportArgs);
	}
}