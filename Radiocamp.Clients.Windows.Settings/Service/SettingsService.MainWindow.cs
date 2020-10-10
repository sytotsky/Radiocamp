using System;
using System.Linq;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Double mainWindowWidth;
		private Double mainWindowHeight;
		private Double mainWindowLeft;
		private Double mainWindowTop;
		private Double mainWindowCompactAdvancedHeight;
		private WindowMode mainWindowMode;
		private AdvancedCompactPosition mainWindowAdvancedCompactPosition;

#pragma warning restore 0649

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

		[Field(nameof(mainWindowCompactAdvancedHeight))]
		public Double MainWindowCompactAdvancedHeight
		{
			get => mainWindowCompactAdvancedHeight;
			set => SetValue(value);
		}

		[Field(nameof(mainWindowMode))]
		[Event(nameof(MainWindowModeChanged))]
		public WindowMode MainWindowMode
		{
			get => mainWindowMode;
			set => SetValue(value);
		}

		[Field(nameof(mainWindowAdvancedCompactPosition))]
		public AdvancedCompactPosition MainWindowAdvancedCompactPosition
		{
			get => mainWindowAdvancedCompactPosition;
			set => SetValue(value);
		}

#pragma warning disable 0067

		public event Action<WindowMode> MainWindowModeChanged;

#pragma warning restore 0067

		public WindowState GetSetMainWindowState() => new WindowState(MainWindowWidth, MainWindowHeight, MainWindowLeft, MainWindowTop);

		public void SetMainWindowState(WindowState windowState)
		{
			
			if (windowState == null)
			{
				return;
			}

			if (windowState.Width == MainWindowWidth && windowState.Height == MainWindowHeight && windowState.Left == MainWindowLeft && windowState.Top == MainWindowTop)
			{
				return;
			}

			if (MainWindowMode == WindowMode.Regular)
			{
				mainWindowHeight = windowState.Height;
			}
			else if (MainWindowMode == WindowMode.CompactAdvanced)
			{
				mainWindowCompactAdvancedHeight = windowState.Height;
			}

			mainWindowWidth = windowState.Width;
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

					if (MainWindowMode == WindowMode.Regular)
					{
						settings.MainWindowHeight = windowState.Height;
					}
					else
					{
						settings.MainWindowCompactAdvancedHeight = windowState.Height;
					}

					settings.MainWindowWidth = windowState.Width;
					settings.MainWindowLeft = windowState.Left;
					settings.MainWindowTop = windowState.Top;

					databaseContext.SaveChanges();

				}
			});

		}

	}
}