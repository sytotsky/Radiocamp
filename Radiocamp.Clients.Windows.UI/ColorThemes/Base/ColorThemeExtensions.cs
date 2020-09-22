using System.Diagnostics.CodeAnalysis;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.UI.ColorThemes
{
	[SuppressMessage("Style", "IDE0066:Convert switch statement to expression", Justification = "<Pending>")]
	public static class ColorThemeExtensions
	{
		public static Theme ToTheme(this ColorTheme colorTheme)
		{
			switch (colorTheme)
			{
				case ColorTheme.Light: return new Theme("Light", "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/ColorThemes/LightTheme.xaml");
				case ColorTheme.Dark: return new Theme("Dark", "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/ColorThemes/DarkTheme.xaml");
				default: return null;
			}
		}
	}
}