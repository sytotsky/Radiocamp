using System;

namespace Dartware.Radiocamp.Clients.Windows.Core.Models
{
	public sealed class WindowState
	{

		public Double Width { get; }
		public Double Height { get; }
		public Double Left { get; }
		public Double Top { get; }

		public WindowState(Double width, Double height, Double left, Double top)
		{
			Width = width;
			Height = height;
			Left = left;
			Top = top;
		}

	}
}