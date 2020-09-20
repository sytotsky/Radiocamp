using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class RadiocampButton : Button
	{

		public static readonly DependencyProperty LocalizedContentProperty = DependencyProperty.Register(nameof(LocalizedContent), typeof(Object), typeof(RadiocampButton), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, LocalizedContentChanged));

		public Object LocalizedContent
		{
			get => (Object) GetValue(LocalizedContentProperty);
			set => SetValue(LocalizedContentProperty, value);
		}

		public static readonly DependencyProperty RightClickCommandProperty = DependencyProperty.Register(nameof(RightClickCommand), typeof(ICommand), typeof(RadiocampButton), new PropertyMetadata(default(ICommand)));

		public ICommand RightClickCommand
		{
			get => (ICommand) GetValue(RightClickCommandProperty);
			set => SetValue(RightClickCommandProperty, value);
		}

		public RadiocampButton()
		{

			Focusable = false;
			SnapsToDevicePixels = true;
			UseLayoutRounding = true;

			MouseRightButtonDown += OnMouseRightButtonDown;

		}

		protected virtual void OnMouseRightButtonDown(Object sender, MouseButtonEventArgs args)
		{
			RightClickCommand?.Execute(null);
		}

		private static void LocalizedContentChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is RadiocampButton button))
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

			button.SetResourceReference(RadioButton.ContentProperty, localizationResourceKey);

		}

	}
}