using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	public static class LocalizationResources
	{
		public static String GetLocalizationString(String resourceKey) => (String) Application.Current.FindResource(resourceKey);
	}
}