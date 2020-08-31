using System;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	public sealed class Localization
	{

		public String Name { get; set; }
		public String Path { get; set; }

		public Localization(String name, String path)
		{
			Name = name;
			Path = path;
		}

	}
}