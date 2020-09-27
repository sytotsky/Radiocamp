using System;
using System.Windows;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class LocalizationTextBlock : TextBlock
	{

		public static readonly DependencyProperty LocalizationTextProperty = DependencyProperty.Register(nameof(LocalizationText), typeof(Object), typeof(LocalizationTextBlock), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, LocalizedContentChanged));

		public Object LocalizationText
		{
			get => (Object) GetValue(LocalizationTextProperty);
			set => SetValue(LocalizationTextProperty, value);
		}

		private static void LocalizedContentChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is LocalizationTextBlock localizationTextBlock))
			{
				return;
			}

			Object value = args.NewValue;
			String localizationResourceKey = value.GetLocalizationResourceKey();

			if (localizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			localizationTextBlock.SetResourceReference(LocalizationTextBlock.TextProperty, localizationResourceKey);

		}

	}
}