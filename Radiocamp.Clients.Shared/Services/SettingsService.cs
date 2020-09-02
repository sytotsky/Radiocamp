using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public abstract class SettingsService<SettingsType, DatabaseContextType> : ISettings<SettingsType> where SettingsType : Settings where DatabaseContextType : DbContext
	{

		protected readonly DatabaseContextType databaseContext;

		protected SettingsService(DatabaseContextType databaseContext)
		{
			this.databaseContext = databaseContext;
		}

	}
}