using System;
using System.Windows;

namespace Dartware.Radiocamp.Windows.UI.Resources.Icons
{
	public static class IconsResources
	{

		public static String SortingIcon => GetIcon(nameof(SortingIcon));
		public static String SortingDescendingIcon => GetIcon(nameof(SortingDescendingIcon));
		public static String SortingAscendingIcon => GetIcon(nameof(SortingAscendingIcon));

		public static String GetIcon(String resourceKey) => (String) Application.Current.FindResource(resourceKey);

	}
}