using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Selector]
	[Localization("SelectSearchEngineDialog_Header")]
	public enum SearchEngine : Int32
	{
		[Localization("Google")]
		[HintLocalization("Google_SearchLink")]
		Google = 0,
		[Localization("Spotify")]
		[HintLocalization("Spotify_SearchLink")]
		Spotify = 1,
		[Localization("SoundCloud")]
		[HintLocalization("SoundCloud_SearchLink")]
		SoundCloud = 2,
		[Localization("Deezer")]
		[HintLocalization("Deezer_SearchLink")]
		Deezer = 3,
		[Localization("Tidal")]
		[HintLocalization("Tidal_SearchLink")]
		Tidal = 4,
		[Localization("Yandex")]
		[HintLocalization("Yandex_SearchLink")]
		Yandex = 5,
		[Localization("DuckDuckGo")]
		[HintLocalization("DuckDuckGo_SearchLink")]
		DuckDuckGo = 6,
		[Localization("YouTube")]
		[HintLocalization("YouTube_SearchLink")]
		YouTube = 7,
		[Localization("Bing")]
		[HintLocalization("Bing_SearchLink")]
		Bing = 8,
		[Localization("Yahoo")]
		[HintLocalization("Yahoo_SearchLink")]
		Yahoo = 9,
		[Localization("LastFm")]
		[HintLocalization("LastFm_SearchLink")]
		LastFm = 10,
		[Localization("Beatport")]
		[HintLocalization("Beatport_SearchLink")]
		Beatport = 11
	}
}