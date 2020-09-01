using System;
using System.Runtime.InteropServices;

namespace Dartware.Radiocamp.Clients.Windows.UI.Native
{
	public sealed class NativeUtils
	{

		public const Int32 HWND_BROADCAST = 0xffff;

		public static readonly Int32 WM_SHOWME;
		public static UInt32 TPM_LEFTALIGN;
		public static UInt32 TPM_RETURNCMD;

		static NativeUtils()
		{
			WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
			TPM_LEFTALIGN = 0;
			TPM_RETURNCMD = 256;
		}

		[DllImport("user32")]
		public static extern Boolean PostMessage(IntPtr hwnd, Int32 msg, IntPtr wparam, IntPtr lparam);

		[DllImport("user32")]
		public static extern Int32 RegisterWindowMessage(String message);

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false, SetLastError = true)]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, Boolean bRevert);

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern Boolean EnableMenuItem(IntPtr hMenu, UInt32 uIDEnableItem, UInt32 uEnable);

		[DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern Int32 TrackPopupMenuEx(IntPtr hmenu, UInt32 fuFlags, Int32 x, Int32 y, IntPtr hwnd, IntPtr lptpm);

	}
}