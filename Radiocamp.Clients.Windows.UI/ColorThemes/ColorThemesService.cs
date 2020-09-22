using System;
using System.Windows;
using Dartware.Radiocamp.Core;
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

			String path = colorTheme switch
			{
				ColorTheme.Light => "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/ColorThemes/LightTheme.xaml",
				ColorTheme.Dark => "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/ColorThemes/DarkTheme.xaml",
				_ => null
			};

			if (path.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			Application.Current.Resources.MergedDictionaries[0].Source = new Uri(path, UriKind.RelativeOrAbsolute);

		}

	}
}