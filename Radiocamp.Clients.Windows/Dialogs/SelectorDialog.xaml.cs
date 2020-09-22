using System;
using System.Windows;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public partial class SelectorDialog : Dialog
	{

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(String), typeof(SelectorDialog), new PropertyMetadata(default(String)));

		public String Title
		{
			get => (String) GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public static readonly DependencyProperty TitleLocalizationResourceKeyProperty = DependencyProperty.Register(nameof(TitleLocalizationResourceKey), typeof(String), typeof(SelectorDialog), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, TitleLocalizationResourceKeyChanged));

		public String TitleLocalizationResourceKey
		{
			get => (String) GetValue(TitleLocalizationResourceKeyProperty);
			set => SetValue(TitleLocalizationResourceKeyProperty, value);
		}

		public SelectorDialog()
		{
			InitializeComponent();
		}

		private static void TitleLocalizationResourceKeyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			SelectorDialog selectorDialog = dependency as SelectorDialog;

			if (args.NewValue is String titleLocalizationResourceKey)
			{
				if (!titleLocalizationResourceKey.IsNullOrEmptyOrWhiteSpace())
				{
					selectorDialog.SetResourceReference(SelectorDialog.TitleProperty, titleLocalizationResourceKey);
				}
			}

		}

	}
}