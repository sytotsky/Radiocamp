using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		private Double mainWindowWidth;
		private Double mainWindowHeight;
		private Double mainWindowLeft;
		private Double mainWindowTop;

		[Field(nameof(mainWindowWidth))]
		public Double MainWindowWidth
		{
			get => mainWindowWidth;
			set => SetValue(value);
		}

		[Field(nameof(mainWindowHeight))]
		public Double MainWindowHeight
		{
			get => mainWindowHeight;
			set => SetValue(value);
		}

		[Field(nameof(mainWindowLeft))]
		public Double MainWindowLeft
		{
			get => mainWindowLeft;
			set => SetValue(value);
		}

		[Field(nameof(mainWindowTop))]
		public Double MainWindowTop
		{
			get => mainWindowTop;
			set => SetValue(value);
		}

		public WindowState MainWindowState
		{
			get => new WindowState(MainWindowWidth, MainWindowHeight, MainWindowLeft, MainWindowTop);
			set => SetMainWindowState(value);
		}

		private void SetMainWindowState(WindowState windowState)
		{
			
			if (windowState == null)
			{
				return;
			}

			if (windowState.Width == MainWindowWidth && windowState.Height == MainWindowHeight && windowState.Left == MainWindowLeft && windowState.Top == MainWindowTop)
			{
				return;
			}

			mainWindowWidth = windowState.Width;
			mainWindowHeight = windowState.Height;
			mainWindowLeft = windowState.Left;
			mainWindowTop = windowState.Top;

			Task.Run(() =>
			{
				lock (databaseContext)
				{

					Settings settings = databaseContext.Set<Settings>().AsTracking().FirstOrDefault();

					if (settings == null)
					{
						return;
					}

					settings.MainWindowWidth = windowState.Width;
					settings.MainWindowHeight = windowState.Height;
					settings.MainWindowLeft = windowState.Left;
					settings.MainWindowTop = windowState.Top;

					databaseContext.SaveChanges();

				}
			});

		}

	}
}