using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Core.Extensions;


namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class SelectorItem : UserControl
	{

		public static readonly DependencyProperty LocalizedContentProperty = DependencyProperty.Register(nameof(LocalizedContent), typeof(Object), typeof(SelectorItem), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, LocalizedContentChanged));

		public Object LocalizedContent
		{
			get => (Object) GetValue(LocalizedContentProperty);
			set => SetValue(LocalizedContentProperty, value);
		}

		public static readonly DependencyProperty IsCurrentProperty = DependencyProperty.Register(nameof(IsCurrent), typeof(Boolean), typeof(SelectorItem), new PropertyMetadata(default(Boolean)));

		public Boolean IsCurrent
		{
			get => (Boolean) GetValue(IsCurrentProperty);
			set => SetValue(IsCurrentProperty, value);
		}

		public SelectorItem()
		{
			InitializeComponent();
		}

		private static void LocalizedContentChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is SelectorItem selectorItem))
			{
				return;
			}

			Object value = args.NewValue;

			if (value == null)
			{
				return;
			}

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

			selectorItem.SetResourceReference(RadioButton.ContentProperty, localizationResourceKey);

		}

	}
}