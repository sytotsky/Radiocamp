using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{
	}
}