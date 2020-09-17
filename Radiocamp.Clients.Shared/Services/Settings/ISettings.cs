using System;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public interface ISettings<SettingsType> where SettingsType : Settings
	{

		Boolean ShowFavoritesAtStart { get; set; }
		Boolean ShowOnlyCustomAtStart { get; set; }

		void Initialize();
		void Reset();

	}
}