using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Core;


namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class SelectorItem : UserControl
	{

		public static readonly DependencyProperty IsCurrentProperty = DependencyProperty.Register(nameof(IsCurrent), typeof(Boolean), typeof(SelectorItem), new PropertyMetadata(default(Boolean)));

		public Boolean IsCurrent
		{
			get => (Boolean) GetValue(IsCurrentProperty);
			set => SetValue(IsCurrentProperty, value);
		}

		public static readonly DependencyProperty LocalizationResourceKeyProperty = DependencyProperty.Register(nameof(LocalizationResourceKey), typeof(String), typeof(SelectorItem), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, LocalizationResourceKeyChanged));

		public String LocalizationResourceKey
		{
			get => (String) GetValue(LocalizationResourceKeyProperty);
			set => SetValue(LocalizationResourceKeyProperty, value);
		}

		public static readonly DependencyProperty HintLocalizationResourceKeyProperty = DependencyProperty.Register(nameof(HintLocalizationResourceKey), typeof(String), typeof(SelectorItem), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, HintLocalizationResourceKeyChanged));

		public String HintLocalizationResourceKey
		{
			get => (String) GetValue(HintLocalizationResourceKeyProperty);
			set => SetValue(HintLocalizationResourceKeyProperty, value);
		}

		public static readonly DependencyProperty HintProperty = DependencyProperty.Register(nameof(Hint), typeof(String), typeof(SelectorItem), new PropertyMetadata(default(String)));

		public String Hint
		{
			get => (String) GetValue(HintProperty);
			set => SetValue(HintProperty, value);
		}

		public SelectorItem()
		{
			InitializeComponent();
		}

		protected override void OnMouseDown(MouseButtonEventArgs args)
		{
			base.OnMouseDown(args);
			((SelectorValue) DataContext)?.Select();
		}

		private static void LocalizationResourceKeyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is SelectorItem selectorItem))
			{
				return;
			}

			String localizationResourceKey = args.NewValue as String;

			if (!localizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				selectorItem.SetResourceReference(SelectorItem.ContentProperty, localizationResourceKey);
			}

		}

		private static void HintLocalizationResourceKeyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is SelectorItem selectorItem))
			{
				return;
			}

			String hintLocalizationResourceKey = args.NewValue as String;

			if (!hintLocalizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				selectorItem.SetResourceReference(SelectorItem.HintProperty, hintLocalizationResourceKey);
			}

		}

	}
}