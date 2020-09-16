using System;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IMainWindow
	{

		event Action EscapeEvent;
		event Action HideEvent;

		void Initialize();

	}
}