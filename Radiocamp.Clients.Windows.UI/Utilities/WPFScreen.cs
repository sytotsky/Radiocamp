using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Dartware.Radiocamp.Clients.Windows.UI.Utilities
{
	public sealed class WPFScreen
	{

		private readonly Screen screen;

		public static WPFScreen Primary => new WPFScreen(Screen.PrimaryScreen);
		public Rect DeviceBounds => GetRect(screen.Bounds);
		public Rect WorkingArea => GetRect(screen.WorkingArea);
		public Boolean IsPrimary => screen.Primary;
		public String DeviceName => screen.DeviceName;
		public Screen Screen => screen;

		internal WPFScreen(Screen screen)
		{
			this.screen = screen;
		}

		public static IEnumerable<WPFScreen> AllScreens()
		{
			foreach (Screen screen in Screen.AllScreens)
			{
				yield return new WPFScreen(screen);
			}
		}

		public static WPFScreen GetScreenFrom(Window window)
		{

			WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
			Screen screen = Screen.FromHandle(windowInteropHelper.Handle);
			WPFScreen wpfScreen = new WPFScreen(screen);

			return wpfScreen;

		}

		public static WPFScreen GetScreenFrom(System.Windows.Point point)
		{

			Int32 x = (Int32) Math.Round(point.X);
			Int32 y = (Int32) Math.Round(point.Y);
			System.Drawing.Point drawingPoint = new System.Drawing.Point(x, y);
			Screen screen = Screen.FromPoint(drawingPoint);
			WPFScreen wpfScreen = new WPFScreen(screen);

			return wpfScreen;
		}

		private Rect GetRect(Rectangle rectangle)
		{
			return new Rect
			{
				X = rectangle.X,
				Y = rectangle.Y,
				Width = rectangle.Width,
				Height = rectangle.Height
			};
		}

	}
}