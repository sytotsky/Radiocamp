using System.Windows;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class MainWindowService : IMainWindow
	{

		public RadiocampWindow Window
		{
			get => Application.Current.MainWindow as RadiocampWindow;
			private set => Application.Current.MainWindow = value;
		}

		public void Initialize()
		{

			Window = new MainWindow();

			Window.Show();

		}

	}
}