using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Native
{
	public struct RECT
	{

		public Int32 Left;
		public Int32 Top;
		public Int32 Right;
		public Int32 Bottom;

		public Point Position => new Point((Double) this.Left, (Double) this.Top);
		public Size Size => new Size((Double) this.Width, (Double) this.Height);

		public Int32 Height
		{
			get => this.Bottom - this.Top;
			set => this.Bottom = this.Top + value;
		}

		public Int32 Width
		{
			get => this.Right - this.Left;
			set => this.Right = this.Left + value;
		}

		public RECT(Int32 left, Int32 top, Int32 right, Int32 bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		public RECT(Rect rect)
		{
			this.Left = (Int32) rect.Left;
			this.Top = (Int32) rect.Top;
			this.Right = (Int32) rect.Right;
			this.Bottom = (Int32) rect.Bottom;
		}

		public void Offset(Int32 dx, Int32 dy)
		{
			this.Left += dx;
			this.Right += dx;
			this.Top += dy;
			this.Bottom += dy;
		}

		public Int32Rect ToInt32Rect() => new Int32Rect(this.Left, this.Top, this.Width, this.Height);

	}
}