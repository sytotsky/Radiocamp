using System;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public interface IBrowser
	{
		void OpenURL(String url);
		void Telegram();
		void YouTube();
	}
}