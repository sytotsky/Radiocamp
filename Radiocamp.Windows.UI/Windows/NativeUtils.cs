using System;
using System.Runtime.InteropServices;

namespace Dartware.Radiocamp.Windows.UI.Windows
{
	public static class NativeUtils
	{

		public static UInt32 TPM_LEFTALIGN;
		public static UInt32 TPM_RETURNCMD;

		static NativeUtils()
		{
			NativeUtils.TPM_LEFTALIGN = 0;
			NativeUtils.TPM_RETURNCMD = 256;
		}

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false, SetLastError = true)]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

	}
}