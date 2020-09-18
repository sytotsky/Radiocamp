using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Selector]
	public enum SearchEngine : Int32
	{
		Google = 0,
		Spotify = 1,
		SoundCloud = 2,
		Deezer = 3,
		Tidal = 4,
		Yandex = 5,
		DuckDuckGo = 6,
		YouTube = 7,
		Bing = 8,
		Yahoo = 9,
		LastFm = 10,
		Beatport = 11
	}
}