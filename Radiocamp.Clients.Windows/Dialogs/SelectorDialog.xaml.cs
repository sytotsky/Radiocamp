using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public partial class SelectorDialog : Dialog
	{

		private ListBox mainListBox;

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

		public override void OnApplyTemplate()
		{
			
			base.OnApplyTemplate();
			
			mainListBox = GetTemplateChild("MainListBox") as ListBox;

			if (mainListBox is not null)
			{
				if (mainListBox.Items is INotifyCollectionChanged notifyCollectionChanged)
				{
					notifyCollectionChanged.CollectionChanged += OnCollectionChanged;
				}
			}

		}

		private void OnCollectionChanged(Object sender, NotifyCollectionChangedEventArgs args)
		{
			
			SelectorDialogValue currentValue = mainListBox.Items.Cast<SelectorDialogValue>().FirstOrDefault(value => value.IsCurrent);

			if (currentValue is not null)
			{
				mainListBox.ScrollIntoView(currentValue);
			}

		}

		protected override void OnPreviewKeyDown(KeyEventArgs args)
		{
			
			base.OnPreviewKeyDown(args);

			SelectorDialogValue currentValue = mainListBox.Items.Cast<SelectorDialogValue>().FirstOrDefault(value => value.IsCurrent);

			if (args.Key.Equals(Key.Down))
			{
				if (currentValue is null)
				{
				
					SelectorDialogValue firstValue = mainListBox.Items.Cast<SelectorDialogValue>().FirstOrDefault();
				
					if (firstValue != null)
					{
						firstValue.Select();
						mainListBox.ScrollIntoView(firstValue);
					}
				
				}
				else
				{

					
					SelectorDialogValue nextValue = null;

					try
					{

						Int32 currentIndex = mainListBox.Items.IndexOf(currentValue);

						nextValue = mainListBox.Items.GetItemAt(currentIndex + 1) as SelectorDialogValue;

					}
					catch
					{
					}

					if (nextValue is not null)
					{
						nextValue.Select();
						mainListBox.ScrollIntoView(nextValue);
					}

				}
			}
			else if (args.Key.Equals(Key.Up))
			{
				if (currentValue is not null)
				{

					SelectorDialogValue previousValue = null;

					try
					{

						Int32 currentIndex = mainListBox.Items.IndexOf(currentValue);

						previousValue = mainListBox.Items.GetItemAt(currentIndex - 1) as SelectorDialogValue;

					}
					catch
					{
					}

					if (previousValue is not null)
					{
						previousValue.Select();
						mainListBox.ScrollIntoView(previousValue);
					}
					
				}
			}

		}

		private static void TitleLocalizationResourceKeyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			SelectorDialog selectorDialog = dependency as SelectorDialog;

			if (args.NewValue is not String titleLocalizationResourceKey)
			{
				return;
			}
			
			if (!titleLocalizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				selectorDialog?.SetResourceReference(SelectorDialog.TitleProperty, titleLocalizationResourceKey);
			}

		}

	}
}