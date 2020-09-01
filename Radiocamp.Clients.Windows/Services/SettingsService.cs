using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class SettingsService : SettingsService<Settings, DatabaseContext>, ISettings
	{
		public SettingsService(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}