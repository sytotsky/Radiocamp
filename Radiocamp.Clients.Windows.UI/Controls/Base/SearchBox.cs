using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class SearchBox : RadiocampTextBox
	{

		private Button clearButton;

		public SearchBox()
		{
			Loaded += OnLoaded;
		}

		protected override void OnKeyDown(KeyEventArgs args)
		{

			base.OnKeyDown(args);

			if (args.Key == Key.Escape && !Text.IsNullOrEmpty())
			{

				Clear();

				args.Handled = true;

			}

		}

		public override void OnApplyTemplate()
		{
			
			base.OnApplyTemplate();

			clearButton = GetTemplateChild("ClearButton") as Button;

			if (clearButton != null)
			{
				clearButton.Click += ClearButton_OnClick;
			}

		}

		protected void ClearButton_OnClick(Object sender, RoutedEventArgs args)
		{
			Clear();
		}

		private void OnLoaded(Object sender, RoutedEventArgs args)
		{
			Focus();
		}

	}
}