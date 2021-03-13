using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Localization("Sorting")]
	public enum SortingType : Int32
	{
		[Localization("Sorting_None")]
		None = 0,
		[Localization("Sorting_NameAscending")]
		NameAscending = 1,
		[Localization("Sorting_NameDescending")]
		NameDescending = 2,
		[Localization("Sorting_FavoritesFirst")]
		FavoritesFirst = 3,
		[Localization("Sorting_PopularFirst")]
		PopularFirst = 4,
		[Localization("Sorting_DateAddedAscending")]
		DateAddedAscending = 5,
		[Localization("Sorting_DateAddedDescending")]
		DateAddedDescending = 6,
		[Localization("Sorting_PlaybackOrder")]
		PlaybackOrder = 7,
		[Localization("Sorting_CustomFirst")]
		CustomFirst = 8
	}
}