using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class WindowsSettingsService : SettingsService<WindowsSettings, DatabaseContext>, ISettings
	{
		public WindowsSettingsService(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}