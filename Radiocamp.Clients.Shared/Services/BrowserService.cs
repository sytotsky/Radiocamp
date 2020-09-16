using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

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

		public void Telegram()
		{
			OpenURL(TELEGRAM_URL);
		}

		public void YouTube()
		{
			OpenURL(YOUTUBE_URL);
		}

	}
}