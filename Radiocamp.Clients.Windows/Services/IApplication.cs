using System;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IApplication
	{

		event Action ShutdownFast;
		event Action ShutdownLong;

		void Shutdown();

	}
}