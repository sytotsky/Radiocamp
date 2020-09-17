using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	public abstract class Settings
	{
		
		[Ignore]
		public Guid Id { get; set; }

		public Boolean ShowFavoritesAtStart { get; set; }
		public Boolean ShowOnlyCustomAtStart { get; set; }

	}
}