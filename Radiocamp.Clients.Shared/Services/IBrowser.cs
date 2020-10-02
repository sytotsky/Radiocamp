using System;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public interface IBrowser
	{
		void Search(String query, SearchEngine searchEngine);
		void OpenURL(String url);
		void Telegram();
		void YouTube();
	}
}