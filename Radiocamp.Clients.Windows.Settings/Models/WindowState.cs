using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed class WindowState
	{

		public Double Width { get; }
		public Double Height { get; }
		public Double Left { get; }
		public Double Top { get; }
		public Double CompactAdvancedHeight { get; set; }

		public Boolean IsZero => Width == 0 && Height == 0 && Left == 0 && Top == 0;

		public WindowState(Double width, Double height, Double left, Double top, Double compactAdvancedHeight)
		{
			Width = width;
			Height = height;
			Left = left;
			Top = top;
			CompactAdvancedHeight = compactAdvancedHeight;
		}

	}
}