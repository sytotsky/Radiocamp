using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class WindowsSettingsService : SettingsService<WindowsSettings, WindowsDatabaseContext>, ISettings
	{
		public WindowsSettingsService(WindowsDatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}