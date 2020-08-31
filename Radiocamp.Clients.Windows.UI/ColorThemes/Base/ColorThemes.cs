using System;
using System.Windows;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.UI.ColorThemes
{
	public class ColorThemes
    {

		public static void SetTheme(ColorTheme theme)
		{
			SetTheme(theme.ToTheme());
		}

		private static void SetTheme(Theme theme)
        {
			Application.Current.Resources.MergedDictionaries[0].Source = new Uri(theme.Path, UriKind.RelativeOrAbsolute);
		}

	}
}