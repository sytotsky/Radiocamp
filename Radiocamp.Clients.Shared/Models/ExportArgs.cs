using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	public sealed class ExportArgs
	{
		public Boolean All { get; set; }
		public Boolean OnlyFavoritesOrCustom { get; set; }
		public Boolean FavoritesOnly { get; set; }
		public Boolean CustomOnly { get; set; }
		public Boolean SaveSoundSettings { get; set; }
		public Boolean SaveFavoritesTags { get; set; }
		public String FilePath { get; set; }
		public ExportFormat Format { get; set; }
	}
}