using System;

namespace Dartware.Radiocamp.Clients.Windows.UI.ColorThemes
{
	public sealed class Theme
	{

		public String Name { get; set; }
		public String Path { get; set; }

		public Theme(String name, String path)
		{
			Name = name;
			Path = path;
		}

	}
}