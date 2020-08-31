using System;
using System.Windows;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.UI.Windows
{
	public partial class RadiocampWindow
	{

		private event Action<Boolean> isCompactChanged;
		private event Action<Boolean> isAdvancedCompactChanged;

		public event Action<Boolean> IsCompactChanged
		{
			add
			{

				isCompactChanged += value;

				isCompactChanged?.Invoke(IsCompact);

			}
			remove => isCompactChanged -= value;
		}

		public event Action<Boolean> IsAdvancedCompactChanged
		{
			add
			{

				isAdvancedCompactChanged += value;

				isAdvancedCompactChanged?.Invoke(IsAdvancedCompact);

			}
			remove => isAdvancedCompactChanged -= value;
		}

		public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(nameof(IsCompact), typeof(Boolean), typeof(RadiocampWindow), new PropertyMetadata(default(Boolean), new PropertyChangedCallback(OnIsCompactChanged)));

		public Boolean IsCompact
		{
			get => (Boolean )GetValue(IsCompactProperty);
			set => SetValue(IsCompactProperty, value);
		}

		public static readonly DependencyProperty IsAdvancedCompactProperty = DependencyProperty.Register(nameof(IsAdvancedCompact), typeof(Boolean), typeof(RadiocampWindow), new PropertyMetadata(default(Boolean), new PropertyChangedCallback(OnIsAdvancedCompactChanged)));

		public Boolean IsAdvancedCompact
		{
			get => (Boolean) GetValue(IsAdvancedCompactProperty);
			set => SetValue(IsAdvancedCompactProperty, value);
		}

		public static readonly DependencyProperty CompactButtonVisibleProperty = DependencyProperty.Register(nameof(CompactButtonVisible), typeof(Boolean), typeof(RadiocampWindow), new PropertyMetadata(default(Boolean)));

		public Boolean CompactButtonVisible
		{
			get => (Boolean) GetValue(CompactButtonVisibleProperty);
			set => SetValue(CompactButtonVisibleProperty, value);
		}

		public static readonly DependencyProperty CompactModeCommandProperty = DependencyProperty.Register(nameof(CompactModeCommand), typeof(ICommand), typeof(RadiocampWindow), new PropertyMetadata(default(ICommand)));

		public ICommand CompactModeCommand
		{
			get => (ICommand) GetValue(CompactModeCommandProperty);
			set => SetValue(CompactModeCommandProperty, value);
		}

		private static void OnIsCompactChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{
			if (dependency is RadiocampWindow radiocampWindow)
			{
				radiocampWindow.isCompactChanged?.Invoke(radiocampWindow.IsCompact);
			}
		}

		private static void OnIsAdvancedCompactChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{
			if (dependency is RadiocampWindow radiocampWindow)
			{
				radiocampWindow.isAdvancedCompactChanged?.Invoke(radiocampWindow.IsAdvancedCompact);
			}
		}

		private void CompactModeButton_Click(Object sender, RoutedEventArgs args)
		{
			if (CompactModeCommand != null)
			{
				CompactModeCommand?.Execute(null);
			}
			else
			{
				IsCompact = true;
			}
		}

	}
}