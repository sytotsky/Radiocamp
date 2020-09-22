using System;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.UI.ColorThemes
{
	public sealed class ColorThemesService : IColorThemes
	{

		private Boolean isNightMode;

		public Boolean IsNightMode
		{
			get => isNightMode;
			set
			{

				isNightMode = value;

				Apply(isNightMode ? ColorTheme.Dark : ColorTheme.Light);

			}
		}

		public ColorThemesService(ISettings settings)
		{
			settings.IsNightModeChanged += isNightMode => IsNightMode = isNightMode;
		}

		public void Apply(ColorTheme colorTheme)
		{
			ColorThemes.SetTheme(colorTheme);
		}

	}
}