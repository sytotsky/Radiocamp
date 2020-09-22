using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	public abstract class Settings
	{
		public Guid Id { get; set; }
		public Boolean ShowFavoritesAtStart { get; set; }
		public Boolean ShowOnlyCustomAtStart { get; set; }
		public SearchEngine SearchEngine { get; set; }
		public Localization Localization { get; set; }
		public Boolean IsNightMode { get; set; }

	}
}