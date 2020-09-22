using System;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.UI.ColorThemes
{
	public interface IColorThemes
	{

		Boolean IsNightMode { get; set; }

		void Apply(ColorTheme colorTheme);

	}
}