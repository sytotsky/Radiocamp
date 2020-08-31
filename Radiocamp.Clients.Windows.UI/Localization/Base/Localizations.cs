using System;
using System.Windows;
using Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	public static class Localizations
	{

		public static void SetLocalization(ApplicationLocalization localization)
		{
			SetLocalization(localization.ToLocalization());
		}

		private static void SetLocalization(Localization localization)
		{
			Application.Current.Resources.MergedDictionaries[1].Source = new Uri(localization.Path, UriKind.RelativeOrAbsolute);
		}

	}
}