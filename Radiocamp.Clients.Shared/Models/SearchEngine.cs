using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Selector]
	public enum SearchEngine : Int32
	{
		[Localization("Google")]
		Google = 0,
		[Localization("Spotify")]
		Spotify = 1,
		[Localization("SoundCloud")]
		SoundCloud = 2,
		[Localization("Deezer")]
		Deezer = 3,
		[Localization("Tidal")]
		Tidal = 4,
		[Localization("Yandex")]
		Yandex = 5,
		[Localization("DuckDuckGo")]
		DuckDuckGo = 6,
		[Localization("YouTube")]
		YouTube = 7,
		[Localization("Bing")]
		Bing = 8,
		[Localization("Yahoo")]
		Yahoo = 9,
		[Localization("LastFm")]
		LastFm = 10,
		[Localization("Beatport")]
		Beatport = 11
	}
}