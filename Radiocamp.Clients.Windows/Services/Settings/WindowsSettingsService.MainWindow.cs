using System;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed partial class WindowsSettingsService
	{

		private Double mainWindowWidth;
		private Double mainWindowHeight;
		private Double mainWindowLeft;
		private Double mainWindowTop;

		public Double MainWindowWidth
		{
			get => mainWindowWidth;
			set => SetValue(value);
		}

		public Double MainWindowHeight
		{
			get => mainWindowHeight;
			set => SetValue(value);
		}

		public Double MainWindowLeft
		{
			get => mainWindowLeft;
			set => SetValue(value);
		}

		public Double MainWindowTop
		{
			get => mainWindowTop;
			set => SetValue(value);
		}

	}
}