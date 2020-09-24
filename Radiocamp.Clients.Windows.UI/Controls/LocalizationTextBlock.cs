using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class LocalizationTextBlock : TextBlock
	{

		public static readonly DependencyProperty LocalizationContentProperty = DependencyProperty.Register(nameof(LocalizationContent), typeof(Object), typeof(LocalizationTextBlock), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, LocalizedContentChanged));

		public Object LocalizationContent
		{
			get => (Object) GetValue(LocalizationContentProperty);
			set => SetValue(LocalizationContentProperty, value);
		}

		private static void LocalizedContentChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is LocalizationTextBlock localizationTextBlock))
			{
				return;
			}

			Object value = args.NewValue;
			Type valueType = value.GetType();
			LocalizationAttribute localizationAttribute = null;

			if (valueType.IsEnum)
			{

				FieldInfo field = valueType.GetField(value.ToString());

				if (field != null)
				{
					if (Attribute.IsDefined(field, typeof(LocalizationAttribute)))
					{
						localizationAttribute = Attribute.GetCustomAttribute(field, typeof(LocalizationAttribute)) as LocalizationAttribute;
					}
				}

			}

			if (localizationAttribute == null)
			{
				return;
			}

			String localizationResourceKey = localizationAttribute.Key;

			if (localizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			localizationTextBlock.SetResourceReference(LocalizationTextBlock.TextProperty, localizationResourceKey);

		}

	}
}