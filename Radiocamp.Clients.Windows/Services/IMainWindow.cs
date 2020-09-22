using System;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IMainWindow
	{

		RadiocampWindow Window { get; }

		event Action EscapeEvent;
		event Action HideEvent;

		void Initialize();

	}
}