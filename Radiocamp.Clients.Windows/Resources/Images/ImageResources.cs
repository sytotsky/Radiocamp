using System;
using System.Windows;
using System.Windows.Media;

namespace Radiocamp.Desktop.Resources
{
	public static class ImageResources
	{

		public static DrawingImage TaskbarPlay => GetDrawingImage(nameof(TaskbarPlay));
		public static DrawingImage TaskbarPause => GetDrawingImage(nameof(TaskbarPause));
		public static DrawingImage TaskbarRecordStop => GetDrawingImage(nameof(TaskbarRecordStop));
		public static DrawingImage TaskbarRecordStart => GetDrawingImage(nameof(TaskbarRecordStart));

		private static DrawingImage GetDrawingImage(String resourceKey) => (DrawingImage) Application.Current.FindResource(resourceKey);

	}
}