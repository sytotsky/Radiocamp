using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class ApplicationService : IApplication
	{

		public event Action ShutdownFast;
		public event Action ShutdownLong;

		public ApplicationService()
		{
			Application.Current.SessionEnding += OnSessionEnding;
		}

		public void Shutdown()
		{
			ShutdownFast?.Invoke();
			ShutdownLong?.Invoke();
			Application.Current.Shutdown();
		}

		private void OnSessionEnding(Object sender, SessionEndingCancelEventArgs args)
		{
			Shutdown();
		}

	}
}