using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Windows
{
	public partial class DialogWindow : Window
	{

		private const Int32 SC_KEYMENU = 0xf100;
		private const Int32 WM_SYSCOMMAND = 0x112;

		private DialogWindowViewModel viewModel;

		public DialogWindowViewModel ViewModel
		{
			get => viewModel;
			set
			{

				viewModel = value;

				if (!DesignerProperties.GetIsInDesignMode(this))
				{
					DataContext = viewModel;
				}

			}
		}

		public static readonly DependencyProperty OverlayVisibleProperty = DependencyProperty.Register(nameof(OverlayVisible), typeof(Boolean), typeof(DialogWindow), new PropertyMetadata(default(Boolean)));

		public Boolean OverlayVisible
		{
			get => (Boolean) GetValue(OverlayVisibleProperty);
			set => SetValue(OverlayVisibleProperty, value);
		}

		public DialogWindow()
		{
			InitializeComponent();
		}

		protected override void OnInitialized(EventArgs args)
		{
			Dependencies.Get<DialogDimmableOverlayViewModel>().Show();
		}

		protected override void OnClosing(CancelEventArgs args)
		{
			Dependencies.Get<DialogDimmableOverlayViewModel>().Hide();
		}

		protected override void OnSourceInitialized(EventArgs args)
		{

			base.OnSourceInitialized(args);

			if (HwndSource.FromVisual(this) is HwndSource source)
			{
				source.AddHook(new HwndSourceHook(WinProc));
			}

		}

		private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
		{

			switch (msg)
			{
				case WM_SYSCOMMAND:
				{

					Int32 sc = (LOWORD(wParam.ToInt32()) & 0xFFF0);

					handled = sc == SC_KEYMENU;

					break;

				}
			}

			return new IntPtr(1);

		}

		private Int32 LOWORD(Int32 value) => (value & 0xffff);

	}
}