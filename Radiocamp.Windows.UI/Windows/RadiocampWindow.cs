using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32;

namespace Dartware.Radiocamp.Windows.UI.Windows
{
	[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public abstract partial class RadiocampWindow : Window
	{

		private const Int32 SC_KEYMENU = 0xf100;
		private const Int32 WM_SYSCOMMAND = 0x112;

		private Boolean isMouseButtonDown;
		private Boolean isManualDrag;
		private System.Windows.Point mouseDownPosition;
		private System.Windows.Point positionBeforeDrag;
		private System.Windows.Point previousScreenBounds;

		public Grid WindowRoot { get; private set; }
		public Grid LayoutRoot { get; private set; }
		public System.Windows.Controls.Button MinimizeButton { get; private set; }
		public System.Windows.Controls.Button MaximizeButton { get; private set; }
		public System.Windows.Controls.Button RestoreButton { get; private set; }
		public System.Windows.Controls.Button CloseButton { get; private set; }
		public System.Windows.Controls.Button CompactModeButton { get; private set; }
		public Grid HeaderBar { get; private set; }
		public Double HeightBeforeMaximize { get; private set; }
		public Double WidthBeforeMaximize { get; private set; }
		public WindowState PreviousState { get; private set; }

		public Boolean IsMaximized => WindowState == WindowState.Maximized;
		public Screen Screen => Screen.FromHandle(new WindowInteropHelper(this).Handle);

		public static readonly DependencyProperty MinimizeCommandProperty = DependencyProperty.Register(nameof(MinimizeCommand), typeof(ICommand), typeof(RadiocampWindow), new PropertyMetadata(default(ICommand)));

		public ICommand MinimizeCommand
		{
			get => (ICommand) GetValue(MinimizeCommandProperty);
			set => SetValue(MinimizeCommandProperty, value);
		}

		public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(RadiocampWindow), new PropertyMetadata(default(ICommand)));

		public ICommand CloseCommand
		{
			get => (ICommand) GetValue(CloseCommandProperty);
			set => SetValue(CloseCommandProperty, value);
		}

		static RadiocampWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RadiocampWindow), new FrameworkPropertyMetadata(typeof(RadiocampWindow)));
		}

		public RadiocampWindow()
		{

			Double currentDPIScaleFactor = (Double) SystemHelper.GetCurrentDPIScaleFactor();
			Screen screen = Screen.FromHandle((new WindowInteropHelper(this)).Handle);

			base.SizeChanged += new SizeChangedEventHandler(this.OnSizeChanged);
			base.StateChanged += new EventHandler(this.OnStateChanged);
			base.Loaded += new RoutedEventHandler(this.OnLoaded);

			Rectangle workingArea = screen.WorkingArea;

			base.MaxHeight = (Double) (workingArea.Height + 16) / currentDPIScaleFactor;

			SystemEvents.DisplaySettingsChanged += new EventHandler(this.SystemEvents_DisplaySettingsChanged);

			this.AddHandler(Window.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.OnMouseButtonUp), true);
			this.AddHandler(Window.MouseMoveEvent, new System.Windows.Input.MouseEventHandler(this.OnMouseMove));

		}

		public TypeDefinition GetRequiredTemplateChild<TypeDefinition>(String childName) where TypeDefinition : DependencyObject => (TypeDefinition) base.GetTemplateChild(childName);

		public override void OnApplyTemplate()
		{

			this.WindowRoot = this.GetRequiredTemplateChild<Grid>(nameof(WindowRoot));
			this.LayoutRoot = this.GetRequiredTemplateChild<Grid>(nameof(LayoutRoot));
			this.MinimizeButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>(nameof(MinimizeButton));
			this.MaximizeButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>(nameof(MaximizeButton));
			this.RestoreButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>(nameof(RestoreButton));
			this.CloseButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>(nameof(CloseButton));
			this.CompactModeButton = this.GetRequiredTemplateChild<System.Windows.Controls.Button>(nameof(CompactModeButton));
			this.HeaderBar = this.GetRequiredTemplateChild<Grid>("PART_HeaderBar");

			if (this.LayoutRoot != null && this.WindowState == WindowState.Maximized)
			{
				this.LayoutRoot.Margin = GetDefaultMarginForDPI();
			}

			if (this.CloseButton != null)
			{
				this.CloseButton.Click += CloseButton_Click;
			}

			if (this.MinimizeButton != null)
			{
				this.MinimizeButton.Click += MinimizeButton_Click;
			}

			if (this.RestoreButton != null)
			{
				this.RestoreButton.Click += RestoreButton_Click;
			}

			if (this.MaximizeButton != null)
			{
				this.MaximizeButton.Click += MaximizeButton_Click;
			}

			if (this.CompactModeButton != null)
			{
				this.CompactModeButton.Click += CompactModeButton_Click;
			}

			if (this.HeaderBar != null)
			{
				this.HeaderBar.AddHandler(Grid.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.OnHeaderBarMouseLeftButtonDown));
				this.HeaderBar.AddHandler(Grid.MouseRightButtonDownEvent, new MouseButtonEventHandler(this.OnHeaderBarMouseRightButtonDown));
			}

			base.OnApplyTemplate();

		}

		protected virtual void OnHeaderBarMouseLeftButtonDown(Object sender, MouseButtonEventArgs args)
		{

			if (isManualDrag)
			{
				return;
			}

			if (args.ClickCount == 2 && base.ResizeMode == ResizeMode.CanResize)
			{

				this.ToggleWindowState();

				return;

			}

			if (base.WindowState == WindowState.Maximized)
			{
				this.isMouseButtonDown = true;
				this.mouseDownPosition = args.GetPosition(this);
			}
			else
			{
				try
				{

					this.positionBeforeDrag = new System.Windows.Point(base.Left, base.Top);

					this.DragMove();

					args.Handled = true;

				}
				catch
				{
				}
			}

		}

		protected virtual void OnHeaderBarMouseRightButtonDown(Object sender, MouseButtonEventArgs args)
		{

			System.Windows.Point position = args.GetPosition(this);
			Int32 headerBarHeight = 22;
			Int32 rightNonClickableOffset = 92;

			if ((this.ActualWidth - position.X >= rightNonClickableOffset) && position.Y <= headerBarHeight)
			{

				if (args.ClickCount != 2)
				{
					this.OpenSystemContextMenu(args);
				}

				args.Handled = true;

				return;

			}

		}

		protected override void OnSourceInitialized(EventArgs args)
		{

			base.OnSourceInitialized(args);

			if (HwndSource.FromVisual(this) is HwndSource source)
			{
				source.AddHook(new HwndSourceHook(WinProc));
			}

		}

		protected void ToggleWindowState()
		{
			if (base.WindowState != WindowState.Maximized)
			{
				base.WindowState = WindowState.Maximized;
			}
			else
			{
				base.WindowState = WindowState.Normal;
			}
		}

		protected virtual Thickness GetDefaultMarginForDPI()
		{

			Int32 currentDPI = SystemHelper.GetCurrentDPI();
			Thickness thickness = new Thickness(8, 8, 8, 8);

			if (currentDPI == 120)
			{
				thickness = new Thickness(7, 7, 4, 5);
			}
			else if (currentDPI == 144)
			{
				thickness = new Thickness(7, 7, 3, 1);
			}
			else if (currentDPI == 168)
			{
				thickness = new Thickness(6, 6, 2, 0);
			}
			else if (currentDPI == 192)
			{
				thickness = new Thickness(6, 6, 0, 0);
			}
			else if (currentDPI == 240)
			{
				thickness = new Thickness(6, 6, 0, 0);
			}

			return thickness;

		}

		protected virtual Thickness GetFromMinimizedMarginForDPI()
		{

			Int32 currentDPI = SystemHelper.GetCurrentDPI();
			Thickness thickness = new Thickness(7, 7, 5, 7);

			if (currentDPI == 120)
			{
				thickness = new Thickness(6, 6, 4, 6);
			}
			else if (currentDPI == 144)
			{
				thickness = new Thickness(7, 7, 4, 4);
			}
			else if (currentDPI == 168)
			{
				thickness = new Thickness(6, 6, 2, 2);
			}
			else if (currentDPI == 192)
			{
				thickness = new Thickness(6, 6, 2, 2);
			}
			else if (currentDPI == 240)
			{
				thickness = new Thickness(6, 6, 0, 0);
			}

			return thickness;

		}

		private void MaximizeButton_Click(Object sender, RoutedEventArgs args)
		{
			this.ToggleWindowState();
		}

		private void RestoreButton_Click(Object sender, RoutedEventArgs args)
		{
			this.ToggleWindowState();
		}

		private void MinimizeButton_Click(Object sender, RoutedEventArgs args)
		{
			if (MinimizeCommand != null)
			{
				MinimizeCommand.Execute(null);
			}
			else
			{
				this.WindowState = WindowState.Minimized;
			}
		}

		private void CloseButton_Click(Object sender, RoutedEventArgs args)
		{
			if (CloseCommand != null)
			{
				CloseCommand.Execute(null);
			}
			else
			{
				this.Close();
			}
		}

		private void SetMaximizeButtonsVisibility(Visibility maximizeButtonVisibility, Visibility reverseMaximizeButtonVisiility)
		{

			if (this.MaximizeButton != null)
			{
				this.MaximizeButton.Visibility = maximizeButtonVisibility;
			}

			if (this.RestoreButton != null)
			{
				this.RestoreButton.Visibility = reverseMaximizeButtonVisiility;
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

		private void OnLoaded(Object sender, RoutedEventArgs args)
		{

			Screen screen = Screen.FromHandle((new WindowInteropHelper(this)).Handle);
			Double width = (Double) screen.WorkingArea.Width;
			Rectangle workingArea = screen.WorkingArea;

			this.previousScreenBounds = new System.Windows.Point(width, (Double)workingArea.Height);

		}

		private void SystemEvents_DisplaySettingsChanged(Object sender, EventArgs args)
		{

			Screen screen = Screen.FromHandle((new WindowInteropHelper(this)).Handle);
			Double width = (Double)screen.WorkingArea.Width;
			Rectangle workingArea = screen.WorkingArea;

			this.previousScreenBounds = new System.Windows.Point(width, (Double)workingArea.Height);

			this.RefreshWindowState();

		}

		private void OnSizeChanged(Object sender, SizeChangedEventArgs args)
		{

			if (base.WindowState == WindowState.Normal)
			{

				this.HeightBeforeMaximize = base.ActualHeight;
				this.WidthBeforeMaximize = base.ActualWidth;

				return;

			}

			if (base.WindowState == WindowState.Maximized)
			{

				Screen screen = Screen.FromHandle((new WindowInteropHelper(this)).Handle);

				if (this.previousScreenBounds.X != (Double)screen.WorkingArea.Width || this.previousScreenBounds.Y != (Double)screen.WorkingArea.Height)
				{

					Double width = (Double)screen.WorkingArea.Width;
					Rectangle workingArea = screen.WorkingArea;

					this.previousScreenBounds = new System.Windows.Point(width, (Double)workingArea.Height);

					this.RefreshWindowState();

				}

			}

		}

		private void OnStateChanged(Object sender, EventArgs args)
		{

			Screen screen = Screen.FromHandle((new WindowInteropHelper(this)).Handle);
			Thickness thickness = new Thickness(0);

			if (this.WindowState != WindowState.Maximized)
			{

				Double currentDPIScaleFactor = (Double)SystemHelper.GetCurrentDPIScaleFactor();
				Rectangle workingArea = screen.WorkingArea;

				this.MaxHeight = (Double)(workingArea.Height + 16) / currentDPIScaleFactor;
				this.MaxWidth = Double.PositiveInfinity;

				if (this.WindowState != WindowState.Maximized)
				{
					this.SetMaximizeButtonsVisibility(Visibility.Visible, Visibility.Collapsed);
				}

			}
			else
			{

				thickness = this.GetDefaultMarginForDPI();

				if (this.PreviousState == WindowState.Minimized || this.Left == this.positionBeforeDrag.X && this.Top == this.positionBeforeDrag.Y)
				{
					thickness = this.GetFromMinimizedMarginForDPI();
				}

				this.SetMaximizeButtonsVisibility(Visibility.Collapsed, Visibility.Visible);

			}

			this.LayoutRoot.Margin = thickness;
			this.PreviousState = this.WindowState;

		}

		private void OnMouseMove(Object sender, System.Windows.Input.MouseEventArgs args)
		{

			if (!this.isMouseButtonDown)
			{
				return;
			}

			Double currentDPIScaleFactor = (Double)SystemHelper.GetCurrentDPIScaleFactor();
			System.Windows.Point position = args.GetPosition(this);

			System.Diagnostics.Debug.WriteLine(position);

			System.Windows.Point screen = base.PointToScreen(position);
			Double x = this.mouseDownPosition.X - position.X;
			Double y = this.mouseDownPosition.Y - position.Y;

			if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) > 1)
			{

				Double actualWidth = this.mouseDownPosition.X;

				if (this.mouseDownPosition.X <= 0)
				{
					actualWidth = 0;
				}
				else if (this.mouseDownPosition.X >= base.ActualWidth)
				{
					actualWidth = this.WidthBeforeMaximize;
				}

				if (base.WindowState == WindowState.Maximized)
				{

					this.ToggleWindowState();

					this.Top = (screen.Y - position.Y) / currentDPIScaleFactor;
					this.Left = (screen.X - actualWidth) / currentDPIScaleFactor;

					this.CaptureMouse();

				}

				this.isManualDrag = true;
				this.Top = (screen.Y - this.mouseDownPosition.Y) / currentDPIScaleFactor;
				this.Left = (screen.X - actualWidth) / currentDPIScaleFactor;

			}

		}
		
		private void OnMouseButtonUp(Object sender, MouseButtonEventArgs args)
		{

			this.isMouseButtonDown = false;
			this.isManualDrag = false;

			this.ReleaseMouseCapture();

		}

		private void RefreshWindowState()
		{
			if (base.WindowState == WindowState.Maximized)
			{
				this.ToggleWindowState();
				this.ToggleWindowState();
			}
		}

		private void OpenSystemContextMenu(MouseButtonEventArgs e)
		{

			System.Windows.Point position = e.GetPosition(this);
			System.Windows.Point screen = this.PointToScreen(position);
			Int32 firstNum = 36;

			if (position.Y < (Double) firstNum)
			{

				IntPtr handle = (new WindowInteropHelper(this)).Handle;
				IntPtr systemMenu = NativeUtils.GetSystemMenu(handle, false);

				if (base.WindowState != WindowState.Maximized)
				{
					NativeUtils.EnableMenuItem(systemMenu, 61488, 0);
				}
				else
				{
					NativeUtils.EnableMenuItem(systemMenu, 61488, 1);
				}

				Int32 secondNum = NativeUtils.TrackPopupMenuEx(systemMenu, NativeUtils.TPM_LEFTALIGN | NativeUtils.TPM_RETURNCMD, Convert.ToInt32(screen.X + 2), Convert.ToInt32(screen.Y + 2), handle, IntPtr.Zero);

				if (secondNum == 0)
				{
					return;
				}

				NativeUtils.PostMessage(handle, 274, new IntPtr(secondNum), IntPtr.Zero);

			}

		}

	}
}