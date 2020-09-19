using System;
using System.Windows;
using Dartware.Radiocamp.Core.Extensions;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public partial class Selector : Dialog
	{

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(String), typeof(Selector), new PropertyMetadata(default(String)));

		public String Title
		{
			get => (String) GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public static readonly DependencyProperty TitleLocalizationResourceKeyProperty = DependencyProperty.Register(nameof(TitleLocalizationResourceKey), typeof(String), typeof(Selector), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.AffectsMeasure, TitleLocalizationResourceKeyChanged));

		public String TitleLocalizationResourceKey
		{
			get => (String) GetValue(TitleLocalizationResourceKeyProperty);
			set => SetValue(TitleLocalizationResourceKeyProperty, value);
		}

		private static void TitleLocalizationResourceKeyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			Selector selector = dependency as Selector;

			if (args.NewValue is String titleLocalizationResourceKey)
			{
				if (!titleLocalizationResourceKey.IsNullOrEmptyOrWhiteSpace())
				{
					selector.SetResourceReference(Selector.TitleProperty, titleLocalizationResourceKey);
				}
			}

		}

		public Selector()
		{
			InitializeComponent();
		}

	}
}