using Dartware.Radiocamp.Clients.Windows.Database;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public sealed class HotkeysService : IHotkeys
	{

		private readonly DatabaseContext databaseContext;

		public HotkeysService(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public void Initialize()
		{
		}

	}
}