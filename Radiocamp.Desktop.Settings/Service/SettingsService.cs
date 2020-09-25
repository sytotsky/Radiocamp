using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Desktop.Settings
{
	[SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
	[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public sealed partial class SettingsService<DatabaseContextType> : ISettings where DatabaseContextType : DbContext
	{

		private readonly DatabaseContextType databaseContext;
		
		public SettingsService(DatabaseContextType databaseContext)
		{
			this.databaseContext = databaseContext;
		}

	}
}