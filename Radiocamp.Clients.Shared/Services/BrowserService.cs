using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using Dartware.Radiocamp.Core;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public sealed class BrowserService : IBrowser
	{

		private const String TELEGRAM_URL = "https://t.me/dartware";
		private const String YOUTUBE_URL = "https://www.youtube.com/channel/UCciMvxhDduf2-5tTGsoGEnQ";

		public void OpenURL(String url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{

					url = url.Replace("&", "^&");
					
					Process.Start(new ProcessStartInfo("cmd", $"/c start {url}")
					{
						CreateNoWindow = true
					});

				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
        }

		public void Search(String query, SearchEngine searchEngine)
		{

			if (query.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			query = NormalizeSearchQuery(query);
			query = WebUtility.UrlEncode(query);

			String formatLink = GetFormatLink(searchEngine);

			if (formatLink.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			String url = String.Format(formatLink, query);

			OpenURL(url);

		}

		public void Telegram()
		{
			OpenURL(TELEGRAM_URL);
		}

		public void YouTube()
		{
			OpenURL(YOUTUBE_URL);
		}

		private String NormalizeSearchQuery(String searchQuery)
		{

			searchQuery = searchQuery.Replace("\\", " ");
			searchQuery = searchQuery.Replace("\"", " ");
			searchQuery = searchQuery.Replace("\0", " ");
			searchQuery = searchQuery.Replace("/", " ");

			return searchQuery;

		}

		private String GetFormatLink(SearchEngine searchEngine)
		{
			switch (searchEngine)
			{
				case SearchEngine.Google: return "https://www.google.com/search?q={0}";
				case SearchEngine.Spotify: return "https://open.spotify.com/search/{0}";
				case SearchEngine.SoundCloud: return "https://soundcloud.com/search?q={0}";
				case SearchEngine.Deezer: return "https://www.deezer.com/search/{0}";
				case SearchEngine.Tidal: return "https://listen.tidal.com/search?q={0}";
				case SearchEngine.Yandex: return "https://yandex.ru/search/?text={0}";
				case SearchEngine.DuckDuckGo: return "https://duckduckgo.com/?q={0}";
				case SearchEngine.YouTube: return "https://www.youtube.com/results?search_query={0}";
				case SearchEngine.Bing: return "https://www.bing.com/search?q={0}";
				case SearchEngine.Yahoo: return "https://search.yahoo.com/search?p={0}";
				case SearchEngine.LastFm: return "https://www.last.fm/search?q={0}";
				case SearchEngine.Beatport: return "https://www.beatport.com/search?q={0}";
				default: return null;
			}
		}

	}
}