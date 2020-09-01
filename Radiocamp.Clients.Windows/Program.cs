using System;

namespace Dartware.Radiocamp.Clients.Windows
{
	public sealed class Program
	{
		[STAThread]
		public static void Main(String[] args)
		{

			if (args is null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			App app = new App();

			app.InitializeComponent();
			app.Run();

		}
	}
}