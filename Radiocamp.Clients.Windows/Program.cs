using System;
using System.Threading;
using Dartware.Radiocamp.Clients.Windows.UI.Native;

namespace Dartware.Radiocamp.Clients.Windows
{
	public sealed class Program
	{

		#if DEBUG
		private const String APPLICATION_HARDCODED_UNIQUE_IDENTIFIER = "Dartware.Radiocamp_DEBUG_D2C77DF4-BD2A-4B3A-9CCC-13D9FF666564";
		#else
        private const String APPLICATION_HARDCODED_UNIQUE_IDENTIFIER = "Dartware.Radiocamp_879A2FFB-823D-4A47-BD6B-00D6B37C2FE6";
		#endif

		private static readonly Mutex mutex;

		static Program()
		{
			mutex = new Mutex(true, APPLICATION_HARDCODED_UNIQUE_IDENTIFIER);
		}

		[STAThread]
		public static void Main(String[] args)
		{

			if (args is null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			if (mutex.WaitOne(TimeSpan.Zero, true))
			{

				App app = new App();

				app.InitializeComponent();
				app.Run();
				mutex.ReleaseMutex();

			}
			else
			{
				NativeUtils.PostMessage((IntPtr) NativeUtils.HWND_BROADCAST, NativeUtils.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
			}

		}

	}
}