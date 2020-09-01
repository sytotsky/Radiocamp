using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public abstract class SettingsService<SettingsType, DatabaseContext> : ISettings<SettingsType> where SettingsType : Settings where DatabaseContext : DbContext
	{

		private readonly DatabaseContext databaseContext;

		protected SettingsService(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

	}
}