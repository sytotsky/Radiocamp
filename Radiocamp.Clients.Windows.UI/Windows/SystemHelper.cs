using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace Dartware.Radiocamp.Clients.Windows.UI.Windows
{
	public static class SystemHelper
	{

		public static Int32 GetCurrentDPI() => (Int32) typeof(SystemParameters).GetProperty("Dpi", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null);

		public static Double GetCurrentDPIScaleFactor() => (Double) SystemHelper.GetCurrentDPI() / 96;

		public static Point GetMouseScreenPosition()
		{

			System.Drawing.Point point = Control.MousePosition;

			return new Point(point.X, point.Y);

		}

	}
}