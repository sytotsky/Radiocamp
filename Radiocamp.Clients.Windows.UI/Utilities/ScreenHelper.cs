using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dartware.Radiocamp.Clients.Windows.UI.Utilities
{
	public sealed class ScreenHelper
	{

		public IEnumerable<Screen> Screens => Screen.AllScreens;
		public Int32 TotalWorkAreaWidth => GetTotalWorkAreaWidth();
		public Screen PrimaryScreen => GetPrimaryScreen();

		private Int32 GetTotalWorkAreaWidth()
		{

			Int32 result = 0;

			foreach (Screen screen in Screens)
			{
				result += screen.WorkingArea.Width;
			}

			return result;

		}

		private Screen GetPrimaryScreen()
		{

			foreach (Screen screen in Screens)
			{
				if (screen.Primary)
				{
					return screen;
				}
			}

			return null;

		}

	}
}