using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public interface ISettings<SettingsType> where SettingsType : Settings
	{

		Boolean ShowFavoritesAtStart { get; set; }
		Boolean ShowOnlyCustomAtStart { get; set; }

		void Initialize();
		Task ResetAsync();

	}
}