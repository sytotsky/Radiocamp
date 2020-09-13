using System;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IMainWindow
	{

		event Action EscapeEvent;

		void Initialize();

	}
}